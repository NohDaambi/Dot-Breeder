using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;

//기능
//SQLite의 DB를 Parsing함.

//Quest Db에서 파싱 -> ID, Name, Des ec.. ->
public class QuestDataLoader : MonoBehaviour
{
    public GameObject questlist; 
    public GameObject contentprefab;
    public GameObject detail; //새끼 퀘스트 있는 경우 detail의 하위목록으로 instantiate.
    public GameObject detailprefab;

    //퀘스트 정보 DataList.
    public List<GameObject> QuestList = new List<GameObject>(); //나중에 private으로 선언한 예정.

    public GameManager Manager;

    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(QuestDataLoad());      
    }
    
    public IEnumerator QuestDataLoad()
    {
        yield return StartCoroutine(QuestDbParsing("QuestDb.sqlite")); //아이템 정보 파싱코루틴이 null값이 되면 아래로 진행.
           //yield return StartCoroutine(UploadQuest()); //UI에 퀘스트를 업로드 한다.
    }

    //Coroutine_멀티스레드 같은 효과를 낼 수 있는 것.
    public IEnumerator QuestDbParsing(string p)
    {
        string Filepath = Application.dataPath + "/" + p;
                            //위는 PC일 경우.
        //Application.persistentDataPath+"/"+p  -> 캐시메모리의 데이터를 불러오는 경로/안드로이드일 경우

        if(!File.Exists(Filepath))
        {
            Debug.LogWarning("File \""+Filepath+"\" does not exist. Attempting to create from \"" + Application.dataPath + "!/assets/"+p);
            Filepath = Application.dataPath + "/" + p;
            if(!File.Exists(Filepath)){
                File.Copy(Application.streamingAssetsPath + "/" + p , Filepath);
            }
        }

        string connectionString = "URI=file:" + Filepath;

        QuestList.Clear(); //리스트 한번 초기화; 데이터가 쌓이는 것 방지!

        //using을 사용함으로써 비정상적인 예외가 발생할 경우에도 반드시 파일을 닫히도록 할 수 있다.
        using(IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //파일 열기
            dbConnection.Open();

            using(IDbCommand dbCmd = dbConnection.CreateCommand()) // EnterSqL에 명령 할 수 있다.
            {
              string sqlQuery = "SELECT * FROM QuestTable";
                                 //어떠한 Table을 불러오겠다는 말.
              dbCmd.CommandText = sqlQuery;

              using (IDataReader reader = dbCmd.ExecuteReader())
              {
                  //Data 읽는 동안 할일
                  while(reader.Read())
                  {
                      //현재 Map 대상의 퀘스트만 가져온다.
                      //if(reader.GetString(4)!=Manager.currentMap.ToString()) continue;

                      //Debug.Log(reader.GetInt32(1)); //타입명, (몇 열에 있는 것을 볼 것인가?)
                      //TestText.text = reader.GetString(2);
                      try
                      {
                        
                        QuestList.Add(CreatQuest(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),reader.GetString(4), reader.GetString(5),reader.GetString(7), reader.GetInt32(8),reader.GetInt32(9), reader.GetInt32(10)));
                        //Debug.Log(reader.GetInt32(0)); //타입명, (몇 열에 있는 것을 볼 것인가?)
                        //QuestList.Add(new Quest(reader.GetInt32(0), reader.GetString(3), reader.GetString(4),reader.GetString(6), reader.GetInt32(7),reader.GetInt32(8), reader.GetInt32(9)));
                      }
                      catch(Exception exception)
                      {
                        
                        SaveSibligQuest(reader.GetInt32(3),reader.GetInt32(1), reader.GetString(4) , reader.GetString(5) ,reader.GetInt32(9), reader.GetInt32(10));
                        //Debug.Log(reader.GetInt32(3)+reader.GetInt32(1)+reader.GetString(4)+reader.GetString(5)+reader.GetInt32(9)+reader.GetInt32(10));
                        Debug.Log("새끼퀘스트는 이때 다른 파일에 저장");
                      }
                      
                  }

                  //파일 닫기
                  dbConnection.Close();
              reader.Close();
              }
              
              
            }
        }

        yield return null;
    }


    //해시코드를 인자로 받아 자신에게 해당하는 퀘스트를 return 값으로 받는다. 1가지 퀘스트만 불러올 수 있음.
    public Quest GetMyQuest(int hash)
    {
      Quest me=null; //지역변수 초기화.
      for(int i=0;i<QuestList.Count;i++)
        {
            Quest quest = QuestList[i].GetComponent<Quest>();
           //자신과 맞는 해시코드에 해당되는 퀘스트를 리턴한다.
           if(quest.Hash == hash && quest.Clear == 0) return QuestList[i].GetComponent<Quest>();
           
        }
      return me;
    }

    //외부에서 다음 함수를 이용해서 해당 퀘스트를 발생시킨다. 인자로는 해쉬코드를 받음.
    public IEnumerator MatchHash(int hashcode)
    {
        for (int i=0; i<QuestList.Count; i++)
        {
            //지역변수 선언한 이유: data만 잠깐 가져올거라서.
            Quest data = QuestList[i].GetComponent<Quest>();
            Debug.Log("Load HashCode Num in 매개변수:"+hashcode);
            Debug.Log("Load HashCode Num in 멤버변수:"+data.Hash);

            if(data.Hash!=hashcode) continue; //hashcode가 같지 않을 경우 아래는 시행하지 않고 다시 탐색.

            QuestList[i].SetActive(true); //해당 퀘스트 UI에 오픈.

            // if(data.DesList != null) //세부 퀘스트가 있는 경우
            // {
            //    for(int j =0;i<data.DesList.Count;j++)
            //    {
            //        //data.DesList 는 gameobject이고 text컴포넌트를 가지고 있다.
            //        data.DesList[i].SetActive(true);
            //    }
            // }
            
        }

        yield return null;
    }

    //데이터에서 퀘스트를 불러 프리팹을 생성한다.
    private GameObject CreatQuest(int id, int hash, int sibcount, string reg, string title,string des, int prev, int count,int clear)
    {
        //퀘스트 버튼인 content프리팹을 이용하여 questBtn를 만든다.
        GameObject questBtn=Instantiate(contentprefab, questlist.transform.position, questlist.transform.rotation);
        //부모지정
        questBtn.transform.SetParent(questlist.transform);
        //스테일조정
        questBtn.transform.localScale=questlist.transform.localScale;
        //생성된 contentprefab안에는 Quest.cs가 있고 생성자 초기화 해야함.
        //member initialize
        questBtn.GetComponent<Quest>().ID=id;
        questBtn.GetComponent<Quest>().Siblig=sibcount;
        questBtn.GetComponent<Quest>().Region=reg;
        questBtn.GetComponent<Quest>().Title=title;
        questBtn.GetComponent<Quest>().Des=des;
        questBtn.GetComponent<Quest>().Prev=prev;
        questBtn.GetComponent<Quest>().Count=count;
        questBtn.GetComponent<Quest>().Clear=clear;
        questBtn.GetComponent<Quest>().Hash=hash;
        questBtn.GetComponent<Quest>().GetComponentInChildren<Text>().text=title; //Update the title of "Quest Button UI"
        Debug.Log(id+"::"+title);
        questBtn.SetActive(false);

        return questBtn; //부모 obj반환.
    }


    //Text or String return
    //detail은 prefab으로 관리해서 추가에 용의하도록 한다.
    private void SaveSibligQuest(int id,int hash, string reg, string title,int count, int clear)
    {    
        int virtualID=id/100; //100을 나눈 몫
        Debug.Log(virtualID);
        Quest parentinfo = QuestList[virtualID].GetComponent<Quest>();
        if(parentinfo.ID==virtualID)
        {
            //R은 몇개, G는 몇개..등등 알려주는거.
           GameObject detailCount = Instantiate(detailprefab, this.transform.position, this.transform.rotation); 
           detailCount.transform.SetParent(detail.transform);   
           detailCount.transform.localScale=detail.transform.localScale;       
           //detailCount.transform.SetParent(detail.);   
           parentinfo.DesList.Add(detailCount);
           Debug.Log(id+"/"+"/"+hash+"/"+"/"+reg+"/"+"/"+title+"/"+count+"/"+clear);
           Debug.Log(detailCount.GetComponent<Text>().text);
           Debug.Log(count.ToString());
           Debug.Log(Manager.Rcount.ToString());
           //일단 첫번째 맵 구현하기 위해서 임시로 여기다가 작성.
           //추후에 함수로 분리할 예정임. ID_1번 퀘스트 관련.
          switch(title)
           {
               case "R": //index num 0
               detailCount.GetComponent<Text>().text=title+": ("+Manager.Rcount.ToString()+"/"+count.ToString()+")";
               break;
               case "G": //index num 1
               detailCount.GetComponent<Text>().text=title+": ("+Manager.Gcount.ToString()+"/"+count.ToString()+")";
               break;
               case "B": //index num 2
               detailCount.GetComponent<Text>().text=title+": ("+Manager.Bcount.ToString()+"/"+count.ToString()+")";
               break;
           }
           
           detailCount.SetActive(false);

        }

        //sibling id형식은 ParentID*100+num
        //siblingquest는 형식없고 데이터만 있음.
    }


    //Test용 Save 버튼
    public void SaveBtn()
    {
        StartCoroutine(SaveQuestDb("QuestDb.sqlite"));
    }

    private IEnumerator SaveQuestDb(string p)
    {
        string Filepath = Application.dataPath + "/" + p;
                            //위는 PC일 경우.
        //Application.persistentDataPath+"/"+p  -> 캐시메모리의 데이터를 불러오는 경로/안드로이드일 경우

        if(!File.Exists(Filepath))
        {
            Debug.LogWarning("File \""+Filepath+"\" does not exist. Attempting to create from \"" + Application.dataPath + "!/assets/"+p);
            Filepath = Application.dataPath + "/" + p;
            if(!File.Exists(Filepath)){
                File.Copy(Application.streamingAssetsPath + "/" + p , Filepath);
            }
        }

        string connectionString = "URI=file:" + Filepath;

        QuestList.Clear(); //리스트 한번 초기화; 데이터가 쌓이는 것 방지!

        //using을 사용함으로써 비정상적인 예외가 발생할 경우에도 반드시 파일을 닫히도록 할 수 있다.
        using(IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //파일 열기
            dbConnection.Open();

            using(IDbCommand dbCmd = dbConnection.CreateCommand()) // EnterSqL에 명령 할 수 있다.
            {
              //수정예정
              string ID = "1";
              string Name="2";
              string Discription = "2";
              
              //UPDATE -> 기존에 있는 것을 바꾸는 명령어ㅐ.
              //QuestTable --> DB테이블 명 
              //SET -> Sqlite 명령어
              //ID -> 필드 이름
              string sqlQuery = "UPDATE QuestTable SET ID =" + ID
                + ",NAME=" + "'" + Name + "'"                    //string 값은 '' 따옴표가 꼭 필요하다~~!!
                  + ",Desc =" + Discription + " "
                + "WHERE ID = 1"; //WHERE을 붙인 이유는 테이블 전체를 돌기 때문에 해당 아이디만 수정하게 선택한것.->WHERE ID는 db 표의 행 번호를 의미. 나는 0부터 시작해서 ID+1로 계산해줘야됨.
            //sqpQery에 들어가는 명령어 풀 문장
            //UPDATE QUestTable SET ID = '1', NAME = '2', DISCRIPTION = '2'
              Debug.Log(sqlQuery);

              dbCmd.CommandText = sqlQuery;
              using (IDataReader reader = dbCmd.ExecuteReader()) //테이블에 있는 데이터들이 들어간다.
              {

              }
              
            }
        }

        yield return null;
    }
}
