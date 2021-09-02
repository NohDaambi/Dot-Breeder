using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;

public enum GROWTH_CONDITION
{
  TOTAL_PIXEL = -1890605083,
  BUILDING = -615027362,
  SKILL_STAT = -1484964110,
  GROWTH_ITEM = 1928637619
}

public class DoteStateManager : MonoBehaviour
{
  public GameObject Conditions; //���� �θ� ���� ������Ʈ. db������ ���� ��Ͽ� ���� ��.
  public GameObject CondPrefab; //�������� ������.
  private GameManager Manager;
  private PieManager PieManager;
  private BarManager BarManager;
  private GameObject DotInfo;
  private GameObject DotCondition;
  private GameObject PixelChart;
  private GameObject TotalChart;
  private GameObject ExpectedLv;

  public List<GameObject> GrowCondList = new List<GameObject>(); //�������� ����Ʈ

  void Start()
  {
    //���ӸŴ��� �ҷ�����.
    Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    PieManager = transform.Find("PixelChart").Find("FullCircle").GetComponent<PieManager>();
    BarManager = transform.Find("TotalChart").Find("FullBar").GetComponent<BarManager>();
    //private���� ���� �� ��Ʈ���� ���� ���� ���ӿ�����Ʈ �ʱ�ȭ.
    DotInfo = transform.Find("DotInfo").gameObject;
    DotCondition = transform.Find("DotCondition").gameObject;
    PixelChart = transform.Find("PixelChart").gameObject;
    TotalChart = transform.Find("TotalChart").gameObject;
    ExpectedLv = transform.Find("ExpectedLv").gameObject;      
  }

  void Update()
  {
      
        
  }


//01. DotInfo GameObject Functions
  // * ���� �޴������� ��Ʈ ���������� �ҷ��� UI�� ������Ʈ ��Ų��.

  //- ��ü ��Ʈ������ ���ε� �Ѵ�.
  public void LoadAllDoteInfo()
  {
    UpdatetDoteInfo("DotName");
    UpdatetDoteInfo("DotLevel");
    UpdatetDoteInfo("DotStat");
    UpdatetDoteInfo("DotHobby");
  }


  //- �׸񺰷� ��Ʈ������ ���ε� �� �� �ִ�.(�̸�, ����, ����, ���)
  public void UpdatetDoteInfo(string infocontent) //�Ű�����: incontent=DoteName,DoteLevel..etc
  {
    GameObject info = DotInfo.transform.Find(infocontent).gameObject;
    switch(infocontent)
    {
      case "DotName":
      info.transform.GetChild(0).GetComponent<Text>().text = Manager.DotName;
      //GetChild().GetComponentInChildren<Text>().text= Manager.DotName;
      break;
      case "DotLevel":
      info.transform.GetChild(0).GetComponent<Text>().text = Manager.DotLevel.ToString();
      break;
      case "DotStat":
      info.transform.GetChild(0).GetComponent<Text>().text = Manager.DotStat.ToString();
      // Debug.Log("[!] Dote Stat: "+Manager.DotStat);
      break;
      case "DotHobby":
      info.transform.GetChild(0).GetComponent<Text>().text = Manager.Hobby;
      break;
    }
    //info.GetComponentInChildren<Text>().text= Manager.DoteName;
  }
    

//02. DotCondition DataBase Pharsing and Update on TAB UI
  public IEnumerator GrowthDataLoad()
  {
    yield return StartCoroutine(GrowthDbParsing("GrowthDb.sqlite")); //������ ���� �Ľ��ڷ�ƾ�� null���� �Ǹ� �Ʒ��� ����.
    //yield return StartCoroutine(UploadQuest()); //UI�� ����Ʈ�� ���ε� �Ѵ�.
  }

  //DataParding Coroutine_
  public IEnumerator GrowthDbParsing(string p)
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

    GrowCondList.Clear(); //����Ʈ �ѹ� �ʱ�ȭ; �����Ͱ� ���̴� �� ����!

    //using�� ��������ν� ���������� ���ܰ� �߻��� ��쿡�� �ݵ�� ������ �������� �� �� �ִ�.
    using(IDbConnection dbConnection = new SqliteConnection(connectionString))
    {
      //���� ����
      dbConnection.Open();

      using(IDbCommand dbCmd = dbConnection.CreateCommand()) // EnterSqL�� ��� �� �� �ִ�.
      {
        string sqlQuery = "SELECT * FROM QrowthTable";
        //��� Table�� �ҷ����ڴٴ� ��.
        dbCmd.CommandText = sqlQuery;

        using (IDataReader reader = dbCmd.ExecuteReader())
        {
          //Data �д� ���� ����
          while(reader.Read())
          {                    
            //Load Current DoteLevel [FROM GameManager]
            //���� ��Ʈ ������ �´� �������Ǹ� �����´�.
            //reader.GetInt32(0) = level DB;
            if(reader.GetInt32(0)!=Manager.DotLevel) continue;

            Debug.Log("[!]GrowthDb_Pharsing...:"); //Ÿ�Ը�, (�� ���� �ִ� ���� �� ���ΰ�?)
            GrowCondList.Add(CreatCondition(reader.GetInt32(0),reader.GetString(2),reader.GetInt32(3),reader.GetInt32(4),reader.GetInt32(5)));
            
            Debug.Log("[DotLevel]"+reader.GetInt32(0));
            Debug.Log("[Index]"+reader.GetInt32(1));
            Debug.Log("[Condition]"+reader.GetString(2));
            Debug.Log("[Goal_Count]"+reader.GetInt32(3));
            Debug.Log("[Clear]"+reader.GetInt32(5));

          }             
          //���� �ݱ�
          dbConnection.Close();
          reader.Close();
                                    
        }
      }
    }
     yield return null;
  }

  // �������� ������ ���� �Լ�.
  private GameObject CreatCondition(int lv, string cond, int count, int hash, int clear)
  {
    //creat condition gameobject
    GameObject condition=Instantiate(CondPrefab,Conditions.transform.position,Conditions.transform.rotation );
    condition.transform.SetParent(Conditions.transform);
    condition.transform.localScale=Conditions.transform.localScale;

    //memeber initialize
    condition.GetComponent<ConditionDb>().level=lv;
    condition.GetComponent<ConditionDb>().condition=cond;
    condition.GetComponent<ConditionDb>().level=count;
    condition.GetComponent<ConditionDb>().count=count;
    condition.GetComponent<ConditionDb>().IsClear=clear;
    condition.GetComponent<ConditionDb>().hash=hash;

    condition.transform.Find("Title").gameObject.GetComponent<Text>().text=cond;

    return condition;
  }
  
  
//03. Pixel Count player have.(Show Up as PieChart)
  // �� �������� �ʿ��� ��ǥ �ȼ� ���� ���� �ҷ��´�.
  public void PixelDataLoad()
  {
    PieManager.PixelDataLoad();
  }

  public int GetGoalOfPixel(int hash)
  {
    // ���� ���� ����Ʈ�� ��ȸ�Ѵ�.
    for(int i  = 0;i<GrowCondList.Count;i++)
    {
       //Hash�ڵ�� Ư�� ������ ��ȸ �� �� �ִ�.
       ConditionDb db = GrowCondList[i].GetComponent<ConditionDb>();
       if(db.hash != hash) continue;
       return db.count;
    }

    return 0;
  }

  // �÷��̾ ȹ���� �� �ȼ� ���� ���� �ҷ��´�.
  public void GetTotalPixelInfo()
  {
    //GameMAnager���� �ҷ����ų� GameManager ��Ʈ��Ʈ�� �̵���ų �� ����.
  }


//04.
  public void BarDataLoad()
  {
    BarManager.BarDataLoad();
  }
  

























}
