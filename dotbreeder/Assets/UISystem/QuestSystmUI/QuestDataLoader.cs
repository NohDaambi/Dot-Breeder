using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;

//���
//SQLite�� DB�� Parsing��.

//Quest Db���� �Ľ� -> ID, Name, Des ec.. ->
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
        yield return StartCoroutine(QuestDbParsing("QuestDb.sqlite")); //������ ���� �Ľ��ڷ�ƾ�� null���� �Ǹ� �Ʒ��� ����.
           //yield return StartCoroutine(UploadQuest()); //UI�� ����Ʈ�� ���ε� �Ѵ�.
    }

    //Coroutine_��Ƽ������ ���� ȿ���� �� �� �ִ� ��.
    IEnumerator QuestDbParsing(string p)
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
                      Debug.Log(reader.GetInt32(1)); //Ÿ�Ը�, (�� ���� �ִ� ���� �� ���ΰ�?)
                      //TestText.text = reader.GetString(2);
                      try
                      {
                        CreatQuest(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(4), reader.GetString(5),reader.GetString(7), reader.GetInt32(8),reader.GetInt32(9), reader.GetInt32(10));
                        //QuestList.Add(new Quest(reader.GetInt32(0), reader.GetString(3), reader.GetString(4),reader.GetString(6), reader.GetInt32(7),reader.GetInt32(8), reader.GetInt32(9)));
                      }
                      catch(Exception exception)
                      {
                        //Debug.Log("��������Ʈ�� �̶� �ٸ� ���Ͽ� ����");
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

    IEnumerator UploadQuest()
    {
        for (int i=0; i<QuestList.Count; i++)
        {
            Debug.Log(QuestList[i].ID+"::"+QuestList[i].Title);
            //Instantiate(QuestList[i].QuestBtn, this.transform.position, this.transform.rotation);
            //QuestList[i].QuestBtn.transform.SetParent(transform);
            //����Ʈ�� �� ��.->�� ��ü ����.
        }

        yield return null;
    }

    //�����Ϳ��� ����Ʈ�� �ҷ� �������� �����Ѵ�.
    private void CreatQuest(int id, int hash, string reg, string title,string des, int prev, int count,int clear)
    {
        //����Ʈ ��ư�� content�������� �̿��Ͽ� questBtn�� �����.
        GameObject questBtn=Instantiate(contentprefab, this.transform.position, this.transform.rotation);
        //�θ�����
        questBtn.transform.SetParent(this.transform);
        //����������
        questBtn.transform.localScale=this.transform.localScale;
        //������ contentprefab�ȿ��� Quest.cs�� �ְ� ������ �ʱ�ȭ �ؾ���.
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
