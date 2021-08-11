using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;

//기능
//SQLite의 DB를 Parsing함.

//Quest Db에서 파싱 -> ID, Name, Des ec.. ->
public class QuestDataLoader : MonoBehaviour
{
    public GameObject contentprefab;
    public List<Quest> QuestList = new List<Quest>();

    void Start()
    {
        StartCoroutine(Main());
    }
    
    IEnumerator Main()
    {
        yield return StartCoroutine(QuestDbParsing("QuestDb.sqlite")); //아이템 정보 파싱코루틴이 null값이 되면 아래로 진행.
           //yield return StartCoroutine(UploadQuest()); //UI에 퀘스트를 업로드 한다.
    }

    //Coroutine_멀티스레드 같은 효과를 낼 수 있는 것.
    IEnumerator QuestDbParsing(string p)
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
                      Debug.Log(reader.GetInt32(1)); //타입명, (몇 열에 있는 것을 볼 것인가?)
                      //TestText.text = reader.GetString(2);
                      try
                      {
                        CreatQuest(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(4), reader.GetString(5),reader.GetString(7), reader.GetInt32(8),reader.GetInt32(9), reader.GetInt32(10));
                        //QuestList.Add(new Quest(reader.GetInt32(0), reader.GetString(3), reader.GetString(4),reader.GetString(6), reader.GetInt32(7),reader.GetInt32(8), reader.GetInt32(9)));
                      }
                      catch(Exception exception)
                      {
                        //Debug.Log("새끼퀘스트는 이때 다른 파일에 저장");
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

    IEnumerator UploadQuest()
    {
        for (int i=0; i<QuestList.Count; i++)
        {
            Debug.Log(QuestList[i].ID+"::"+QuestList[i].Title);
            //Instantiate(QuestList[i].QuestBtn, this.transform.position, this.transform.rotation);
            //QuestList[i].QuestBtn.transform.SetParent(transform);
            //리스트에 잘 들어감.->후 객체 생성.
        }

        yield return null;
    }

    //데이터에서 퀘스트를 불러 프리팹을 생성한다.
    private void CreatQuest(int id, int hash, string reg, string title,string des, int prev, int count,int clear)
    {
        //퀘스트 버튼인 content프리팹을 이용하여 questBtn를 만든다.
        GameObject questBtn=Instantiate(contentprefab, this.transform.position, this.transform.rotation);
        //부모지정
        questBtn.transform.SetParent(this.transform);
        //스테일조정
        questBtn.transform.localScale=this.transform.localScale;
        //생성된 contentprefab안에는 Quest.cs가 있고 생성자 초기화 해야함.
        //member initialize
        questBtn.GetComponent<Quest>().ID=id;
        questBtn.GetComponent<Quest>().Region=reg;
        questBtn.GetComponent<Quest>().Title=title;
        questBtn.GetComponent<Quest>().Des=des;
        questBtn.GetComponent<Quest>().Prev=prev;
        questBtn.GetComponent<Quest>().Count=count;
        questBtn.GetComponent<Quest>().Clear=clear;
        questBtn.GetComponent<Quest>().Hash=hash;
        questBtn.GetComponent<Quest>().UpdateText();
        Debug.Log(id+"::"+title);
    }
}
