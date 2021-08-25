using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;

//���
//SQLite�� DB�� Parsing��.

//Quest Db���� �Ľ� -> ID, Name, Des ec.. ->
public class QuestDataLoader : MonoBehaviour
{
    public GameObject questlist; 
    public GameObject contentprefab;
    public GameObject detail; //���� ����Ʈ �ִ� ��� detail�� ����������� instantiate.
    public GameObject detailprefab;

    //����Ʈ ���� DataList.
    public List<GameObject> QuestList = new List<GameObject>(); //���߿� private���� ������ ����.

    public GameManager Manager;

    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(QuestDataLoad());      
    }
    
    public IEnumerator QuestDataLoad()
    {
        yield return StartCoroutine(QuestDbParsing("QuestDb.sqlite")); //������ ���� �Ľ��ڷ�ƾ�� null���� �Ǹ� �Ʒ��� ����.
           //yield return StartCoroutine(UploadQuest()); //UI�� ����Ʈ�� ���ε� �Ѵ�.
    }

    //Coroutine_��Ƽ������ ���� ȿ���� �� �� �ִ� ��.
    public IEnumerator QuestDbParsing(string p)
    {
        string Filepath = Application.dataPath + "/" + p;
                            //���� PC�� ���.
        //Application.persistentDataPath+"/"+p  -> ĳ�ø޸��� �����͸� �ҷ����� ���/�ȵ���̵��� ���

        if(!File.Exists(Filepath))
        {
            Debug.LogWarning("File \""+Filepath+"\" does not exist. Attempting to create from \"" + Application.dataPath + "!/assets/"+p);
            Filepath = Application.dataPath + "/" + p;
            if(!File.Exists(Filepath)){
                File.Copy(Application.streamingAssetsPath + "/" + p , Filepath);
            }
        }

        string connectionString = "URI=file:" + Filepath;

        QuestList.Clear(); //����Ʈ �ѹ� �ʱ�ȭ; �����Ͱ� ���̴� �� ����!

        //using�� ��������ν� ���������� ���ܰ� �߻��� ��쿡�� �ݵ�� ������ �������� �� �� �ִ�.
        using(IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //���� ����
            dbConnection.Open();

            using(IDbCommand dbCmd = dbConnection.CreateCommand()) // EnterSqL�� ��� �� �� �ִ�.
            {
              string sqlQuery = "SELECT * FROM QuestTable";
                                 //��� Table�� �ҷ����ڴٴ� ��.
              dbCmd.CommandText = sqlQuery;

              using (IDataReader reader = dbCmd.ExecuteReader())
              {
                  //Data �д� ���� ����
                  while(reader.Read())
                  {
                      //���� Map ����� ����Ʈ�� �����´�.
                      //if(reader.GetString(4)!=Manager.currentMap.ToString()) continue;

                      //Debug.Log(reader.GetInt32(1)); //Ÿ�Ը�, (�� ���� �ִ� ���� �� ���ΰ�?)
                      //TestText.text = reader.GetString(2);
                      try
                      {
                        
                        QuestList.Add(CreatQuest(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),reader.GetString(4), reader.GetString(5),reader.GetString(7), reader.GetInt32(8),reader.GetInt32(9), reader.GetInt32(10)));
                        //Debug.Log(reader.GetInt32(0)); //Ÿ�Ը�, (�� ���� �ִ� ���� �� ���ΰ�?)
                        //QuestList.Add(new Quest(reader.GetInt32(0), reader.GetString(3), reader.GetString(4),reader.GetString(6), reader.GetInt32(7),reader.GetInt32(8), reader.GetInt32(9)));
                      }
                      catch(Exception exception)
                      {
                        
                        SaveSibligQuest(reader.GetInt32(3),reader.GetInt32(1), reader.GetString(4) , reader.GetString(5) ,reader.GetInt32(9), reader.GetInt32(10));
                        //Debug.Log(reader.GetInt32(3)+reader.GetInt32(1)+reader.GetString(4)+reader.GetString(5)+reader.GetInt32(9)+reader.GetInt32(10));
                        Debug.Log("��������Ʈ�� �̶� �ٸ� ���Ͽ� ����");
                      }
                      
                  }

                  //���� �ݱ�
                  dbConnection.Close();
              reader.Close();
              }
              
              
            }
        }

        yield return null;
    }


    //�ؽ��ڵ带 ���ڷ� �޾� �ڽſ��� �ش��ϴ� ����Ʈ�� return ������ �޴´�. 1���� ����Ʈ�� �ҷ��� �� ����.
    public Quest GetMyQuest(int hash)
    {
      Quest me=null; //�������� �ʱ�ȭ.
      for(int i=0;i<QuestList.Count;i++)
        {
            Quest quest = QuestList[i].GetComponent<Quest>();
           //�ڽŰ� �´� �ؽ��ڵ忡 �ش�Ǵ� ����Ʈ�� �����Ѵ�.
           if(quest.Hash == hash && quest.Clear == 0) return QuestList[i].GetComponent<Quest>();
           
        }
      return me;
    }

    //�ܺο��� ���� �Լ��� �̿��ؼ� �ش� ����Ʈ�� �߻���Ų��. ���ڷδ� �ؽ��ڵ带 ����.
    public IEnumerator MatchHash(int hashcode)
    {
        for (int i=0; i<QuestList.Count; i++)
        {
            //�������� ������ ����: data�� ��� �����ðŶ�.
            Quest data = QuestList[i].GetComponent<Quest>();
            Debug.Log("Load HashCode Num in �Ű�����:"+hashcode);
            Debug.Log("Load HashCode Num in �������:"+data.Hash);

            if(data.Hash!=hashcode) continue; //hashcode�� ���� ���� ��� �Ʒ��� �������� �ʰ� �ٽ� Ž��.

            QuestList[i].SetActive(true); //�ش� ����Ʈ UI�� ����.

            // if(data.DesList != null) //���� ����Ʈ�� �ִ� ���
            // {
            //    for(int j =0;i<data.DesList.Count;j++)
            //    {
            //        //data.DesList �� gameobject�̰� text������Ʈ�� ������ �ִ�.
            //        data.DesList[i].SetActive(true);
            //    }
            // }
            
        }

        yield return null;
    }

    //�����Ϳ��� ����Ʈ�� �ҷ� �������� �����Ѵ�.
    private GameObject CreatQuest(int id, int hash, int sibcount, string reg, string title,string des, int prev, int count,int clear)
    {
        //����Ʈ ��ư�� content�������� �̿��Ͽ� questBtn�� �����.
        GameObject questBtn=Instantiate(contentprefab, questlist.transform.position, questlist.transform.rotation);
        //�θ�����
        questBtn.transform.SetParent(questlist.transform);
        //����������
        questBtn.transform.localScale=questlist.transform.localScale;
        //������ contentprefab�ȿ��� Quest.cs�� �ְ� ������ �ʱ�ȭ �ؾ���.
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

        return questBtn; //�θ� obj��ȯ.
    }


    //Text or String return
    //detail�� prefab���� �����ؼ� �߰��� �����ϵ��� �Ѵ�.
    private void SaveSibligQuest(int id,int hash, string reg, string title,int count, int clear)
    {    
        int virtualID=id/100; //100�� ���� ��
        Debug.Log(virtualID);
        Quest parentinfo = QuestList[virtualID].GetComponent<Quest>();
        if(parentinfo.ID==virtualID)
        {
            //R�� �, G�� �..��� �˷��ִ°�.
           GameObject detailCount = Instantiate(detailprefab, this.transform.position, this.transform.rotation); 
           detailCount.transform.SetParent(detail.transform);   
           detailCount.transform.localScale=detail.transform.localScale;       
           //detailCount.transform.SetParent(detail.);   
           parentinfo.DesList.Add(detailCount);
           Debug.Log(id+"/"+"/"+hash+"/"+"/"+reg+"/"+"/"+title+"/"+count+"/"+clear);
           Debug.Log(detailCount.GetComponent<Text>().text);
           Debug.Log(count.ToString());
           Debug.Log(Manager.Rcount.ToString());
           //�ϴ� ù��° �� �����ϱ� ���ؼ� �ӽ÷� ����ٰ� �ۼ�.
           //���Ŀ� �Լ��� �и��� ������. ID_1�� ����Ʈ ����.
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

        //sibling id������ ParentID*100+num
        //siblingquest�� ���ľ��� �����͸� ����.
    }


    //Test�� Save ��ư
    public void SaveBtn()
    {
        StartCoroutine(SaveQuestDb("QuestDb.sqlite"));
    }

    private IEnumerator SaveQuestDb(string p)
    {
        string Filepath = Application.dataPath + "/" + p;
                            //���� PC�� ���.
        //Application.persistentDataPath+"/"+p  -> ĳ�ø޸��� �����͸� �ҷ����� ���/�ȵ���̵��� ���

        if(!File.Exists(Filepath))
        {
            Debug.LogWarning("File \""+Filepath+"\" does not exist. Attempting to create from \"" + Application.dataPath + "!/assets/"+p);
            Filepath = Application.dataPath + "/" + p;
            if(!File.Exists(Filepath)){
                File.Copy(Application.streamingAssetsPath + "/" + p , Filepath);
            }
        }

        string connectionString = "URI=file:" + Filepath;

        QuestList.Clear(); //����Ʈ �ѹ� �ʱ�ȭ; �����Ͱ� ���̴� �� ����!

        //using�� ��������ν� ���������� ���ܰ� �߻��� ��쿡�� �ݵ�� ������ �������� �� �� �ִ�.
        using(IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //���� ����
            dbConnection.Open();

            using(IDbCommand dbCmd = dbConnection.CreateCommand()) // EnterSqL�� ��� �� �� �ִ�.
            {
              //��������
              string ID = "1";
              string Name="2";
              string Discription = "2";
              
              //UPDATE -> ������ �ִ� ���� �ٲٴ� ��ɾ��.
              //QuestTable --> DB���̺� �� 
              //SET -> Sqlite ��ɾ�
              //ID -> �ʵ� �̸�
              string sqlQuery = "UPDATE QuestTable SET ID =" + ID
                + ",NAME=" + "'" + Name + "'"                    //string ���� '' ����ǥ�� �� �ʿ��ϴ�~~!!
                  + ",Desc =" + Discription + " "
                + "WHERE ID = 1"; //WHERE�� ���� ������ ���̺� ��ü�� ���� ������ �ش� ���̵� �����ϰ� �����Ѱ�.->WHERE ID�� db ǥ�� �� ��ȣ�� �ǹ�. ���� 0���� �����ؼ� ID+1�� �������ߵ�.
            //sqpQery�� ���� ��ɾ� Ǯ ����
            //UPDATE QUestTable SET ID = '1', NAME = '2', DISCRIPTION = '2'
              Debug.Log(sqlQuery);

              dbCmd.CommandText = sqlQuery;
              using (IDataReader reader = dbCmd.ExecuteReader()) //���̺� �ִ� �����͵��� ����.
              {

              }
              
            }
        }

        yield return null;
    }
}
