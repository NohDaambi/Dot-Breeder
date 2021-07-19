using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public PlayerAction player;
    public Plants Plant;   
    public Animator talkPanel;
    public Animator PortraitAnim;
    public QuestManager questManager;
    public Image portraitImg;
    public Sprite PrevPortrait;
    public DropArr dropArr;

    public Rscore Rtext;
    public Gscore Gtext;
    public Bscore Btext;
    public TypeEffect talk;
    public Text questText;
    public Text questTextIng;
    public Text questTextEd;
    public Text NpcName;


    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject TabMenu;


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
        //게임 불러오기
        GameLoad();
        //퀘스트 이름
        questText.text = questManager.CheckQuest();
        questTextIng.text = questManager.CheckQuest();
    }

    void Update()
    {
        //메뉴 창 키기,끄기
        if(Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
            {
                //두개가 중복으로 켜지지 않음
                menuSet.SetActive(true);
                TabMenu.SetActive(false);
            }
        }

        //Tab키 키기,끄기
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (TabMenu.activeSelf)
                TabMenu.SetActive(false);
            else
            {
                TabMenu.SetActive(true);
                menuSet.SetActive(false);
            }
                
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
        {
            Destroy(gameObject);
        }

    }


    //채집 액션
    public void Forage()
    {
        if (player.scanObject.tag == "G")
        {            
            Plant.FlowerDestory();
            dropArr.Drop("G", Gcount, PrevGcount);

        }
        else if (player.scanObject.tag == "R")
        {
            Plant.RockDestory();
            dropArr.Drop("R", Rcount, PrevRcount);
        }
        else if (player.scanObject.tag == "B")
        {
            Plant.BoxDestory();
            dropArr.Drop("B", Bcount, PrevBcount);
        }


        //첫번째 퀘스트 클리어
        if (Gcount >= 3 && player.scanObject.name == "NpcB" && questManager.questId == 20)
        {
            questManager.questId += 10;
            questManager.questActionIndex = 0;
            Gcount -= 3;
        }

        //교육하러가기
        if(player.scanObject.name == "Study")
        {
            //현재 씬 번호 불러내서 레지스트리에 저장하기
            PlayerPrefs.SetInt("SceneNum", SceneManager.GetActiveScene().buildIndex);

            PlayerPrefs.Save();

            SceneManager.LoadScene("MiniGame");

        }
    }

    //대화 액션
    public void Action(GameObject scanObj)
    {
        //현재 오브젝트 가져오기
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();

        //Npc 일 경우에만 대화가능
        if (objData.isNpc)
        {
            Talk(objData.Id);
        }

        //이야기 보여주기
        talkPanel.SetBool("isShow", isAction);

        if (objData.isNpc)
        {
            NpcName.gameObject.SetActive(true);
            NpcName.text = scanObject.name;
        }
        else
            NpcName.gameObject.SetActive(false);

        //if (objData.isStudy)
        //{
        //    isAction = true;
        //}

    }

    //대화 set, end
    void Talk(int id)
    {
        //set talk
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        //end talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = questManager.CheckQuest(id);
            questTextIng.text = questManager.CheckQuest(id);
            //이전 퀘스트 번호 받아와서 출력 -> 완료된 퀘스트 출력
            //if(questManager.questId >)
            return;
        }

        //Continue Talk      
        
        talk.SetMsg(talkData.Split(':')[0]);

        //Show Portrait
        portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
        portraitImg.color = new Color(1, 1, 1, 1);

        //Anim Portrait
        if (PrevPortrait != portraitImg.sprite)
        {
            PortraitAnim.SetTrigger("doEffect");
            PrevPortrait = portraitImg.sprite;
        }


        isAction = true;
        talkIndex++;
    
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
