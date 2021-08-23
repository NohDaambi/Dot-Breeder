using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    public TalkManager talkManager;
    public PlayerAction player;
    public Animator talkPanel;
    public QuestManager questManager;
    public DropTextBox DropBox;
    public DataPieceSort DataPiece;
    public Interaction PlayerInteraction;

    public Rscore Rtext;
    public Gscore Gtext;
    public Bscore Btext;   

    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject TabMenu;
    public GameObject PlantObj;
    public GameObject DataPieceObj;

    public int talkIndex;    
    public int Rcount;
    public int Gcount;
    public int Bcount;

    public int PrevRcount;
    public int PrevGcount;
    public int PrevBcount;

    public bool isAction;
    private static bool ManagerExist;

    void Start()
    {
        //퀘스트 이름
        PlayerInteraction.questText.text = questManager.CheckQuest();
        PlayerInteraction.questTextIng.text = questManager.CheckQuest();
    }

    void Update()
    {
        //메뉴 창 키기,끄기
        if(Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else if (!menuSet.activeSelf && !PlayerInteraction.CombinationUI.activeSelf && !TabMenu.activeSelf 
                  && SceneManager.GetActiveScene().buildIndex != 0) 
                menuSet.SetActive(true);
            else
            {
                //두개가 중복으로 켜지지 않음
                menuSet.SetActive(false);
                DataPiece.DataInterpret.SetActive(false);
                DataPiece.DataPieceContents.SetActive(true);
                TabMenu.SetActive(false);
            }

            if (PlayerInteraction.CombinationUI.activeSelf && PlayerInteraction.CombinationChild.activeSelf)
            {
                PlayerInteraction.CombinationChild.SetActive(false);
                PlayerInteraction.CombinationAnim.SetTrigger("isInit");
            }
            if(PlayerInteraction.CombinationUI.activeSelf && !PlayerInteraction.CombinationChild.activeSelf)
            {
                PlayerInteraction.CombinationUI.SetActive(false);
            }
        }

        //Tab키 키기,끄기
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (TabMenu.activeSelf)
            {
                DataPiece.DataPieceContents.SetActive(true);
                DataPiece.DataInterpret.SetActive(false);
                TabMenu.SetActive(false);
            }
            else
            {
                TabMenu.SetActive(true);
                menuSet.SetActive(false);
            }
        }

        //숲-1에서만 활성화
        if (SceneManager.GetActiveScene().name == "Forest1")
        {
            PlantObj.SetActive(true);
            DataPieceObj.SetActive(true);
        }
        else
        {
            PlantObj.SetActive(false);
            DataPieceObj.SetActive(false);
        }
    }

    void Awake()
    {
        Time.timeScale = 1;

        //중복삭제
        if (!ManagerExist)
        {
            ManagerExist = true;            
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }  

    //게임 저장
    public void GameSave()
    {
        //플레이어 위치저장
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);

        //퀘스트 넘버 저장
        PlayerPrefs.SetInt("QustId", questManager.questId);
        PlayerPrefs.SetInt("QustActionIndex", questManager.questActionIndex);

        //수집한 RGB값 저장
        PlayerPrefs.SetInt("Rcount", Rcount);
        PlayerPrefs.SetInt("Gcount", Gcount);
        PlayerPrefs.SetInt("Bcount", Bcount);

        //씬 번호 저장
        //현재 씬 번호 불러내서 레지스트리에 저장하기
        PlayerPrefs.SetInt("SceneNum", SceneManager.GetActiveScene().buildIndex);
        
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    //게임 불러오기
    public void GameLoad()
    {
        //한번도 저장한 적 없으면 걍 반환(로드안함)
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        int questId = PlayerPrefs.GetInt("QustId");
        int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");

        int Rcnt = PlayerPrefs.GetInt("Rcount");
        int Gcnt = PlayerPrefs.GetInt("Gcount");
        int Bcnt = PlayerPrefs.GetInt("Bcount");

        int ScNum = PlayerPrefs.GetInt("SceneNum");

        player.transform.position = new Vector3(x, y, -1);

        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;

        Rcount = Rcnt;
        Gcount = Gcnt;
        Bcount = Bcnt;

        SceneManager.LoadScene(ScNum);        
       
    }

    //게임 종료
    public void GameExit()
    {
        Application.Quit();
    }
}
