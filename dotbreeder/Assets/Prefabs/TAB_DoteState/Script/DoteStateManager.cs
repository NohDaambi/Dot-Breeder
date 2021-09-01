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
  public GameObject Conditions; //조건 부모 게임 오브젝트. db내용은 하위 목록에 생성 됨.
  public GameObject CondPrefab; //성장조건 프리팹.
  private GameManager Manager;
  private PieManager PieManager;
  private BarManager BarManager;
  private GameObject DotInfo;
  private GameObject DotCondition;
  private GameObject PixelChart;
  private GameObject TotalChart;
  private GameObject ExpectedLv;

  public List<GameObject> GrowCondList = new List<GameObject>(); //성장조건 리스트

  void Start()
  {
    //게임매니저 불러오기.
    Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    PieManager = transform.Find("PixelChart").Find("FullCircle").GetComponent<PieManager>();
    BarManager = transform.Find("TotalChart").Find("FullBar").GetComponent<BarManager>();
    //private으로 선언 한 도트상태 탭의 구성 게임오브젝트 초기화.
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
  // * 게임 메니저에서 도트 인포정보를 불러와 UI에 업데이트 시킨다.

  //- 전체 도트정보를 업로드 한다.
  public void LoadAllDoteInfo()
  {
    UpdatetDoteInfo("DotName");
    UpdatetDoteInfo("DotLevel");
    UpdatetDoteInfo("DotStat");
    UpdatetDoteInfo("DotHobby");
  }


  //- 항목별로 도트정보를 업로드 할 수 있다.(이름, 레벨, 스탯, 취미)
  public void UpdatetDoteInfo(string infocontent) //매개변수: incontent=DoteName,DoteLevel..etc
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
    yield return StartCoroutine(GrowthDbParsing("GrowthDb.sqlite")); //아이템 정보 파싱코루틴이 null값이 되면 아래로 진행.
    //yield return StartCoroutine(UploadQuest()); //UI에 퀘스트를 업로드 한다.
  }

  //DataParding Coroutine_
  public IEnumerator GrowthDbParsing(string p)
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

    GrowCondList.Clear(); //리스트 한번 초기화; 데이터가 쌓이는 것 방지!

    //using을 사용함으로써 비정상적인 예외가 발생할 경우에도 반드시 파일을 닫히도록 할 수 있다.
    using(IDbConnection dbConnection = new SqliteConnection(connectionString))
    {
      //파일 열기
      dbConnection.Open();

      using(IDbCommand dbCmd = dbConnection.CreateCommand()) // EnterSqL에 명령 할 수 있다.
      {
        string sqlQuery = "SELECT * FROM QrowthTable";
        //어떠한 Table을 불러오겠다는 말.
        dbCmd.CommandText = sqlQuery;

        using (IDataReader reader = dbCmd.ExecuteReader())
        {
          //Data 읽는 동안 할일
          while(reader.Read())
          {                    
            //Load Current DoteLevel [FROM GameManager]
            //현재 도트 레벨에 맞는 성장조건만 가져온다.
            //reader.GetInt32(0) = level DB;
            if(reader.GetInt32(0)!=Manager.DotLevel) continue;

            Debug.Log("[!]GrowthDb_Pharsing...:"); //타입명, (몇 열에 있는 것을 볼 것인가?)
            GrowCondList.Add(CreatCondition(reader.GetInt32(0),reader.GetString(2),reader.GetInt32(3),reader.GetInt32(4),reader.GetInt32(5)));
            
            Debug.Log("[DotLevel]"+reader.GetInt32(0));
            Debug.Log("[Index]"+reader.GetInt32(1));
            Debug.Log("[Condition]"+reader.GetString(2));
            Debug.Log("[Goal_Count]"+reader.GetInt32(3));
            Debug.Log("[Clear]"+reader.GetInt32(5));

          }             
          //파일 닫기
          dbConnection.Close();
          reader.Close();
                                    
        }
      }
    }
     yield return null;
  }

  // 성장조건 프리팹 생성 함수.
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
  // 현 레벨에서 필요한 목표 픽셀 조각 수를 불러온다.
  public void PixelDataLoad()
  {
    PieManager.PixelDataLoad();
  }

  public int GetGoalOfPixel(int hash)
  {
    // 성장 조건 리스트를 순회한다.
    for(int i  = 0;i<GrowCondList.Count;i++)
    {
       //Hash코드로 특정 조건을 조회 할 수 있다.
       ConditionDb db = GrowCondList[i].GetComponent<ConditionDb>();
       if(db.hash != hash) continue;
       return db.count;
    }

    return 0;
  }

  // 플레이어가 획득한 총 픽셀 조각 수를 불러온다.
  public void GetTotalPixelInfo()
  {
    //GameMAnager에서 불러오거나 GameManager 스트립트로 이동시킬 수 있음.
  }


//04.
  public void BarDataLoad()
  {
    BarManager.BarDataLoad();
  }
  

























}
