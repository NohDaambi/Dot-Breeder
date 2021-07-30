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
    public Animator CombinationAnim;
    public QuestManager questManager;
    public Image portraitImg;
    public Sprite PrevPortrait;
    public DropTextBox DropBox;
    public StartScene startScene;

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
    public GameObject CombinationUI;
    public GameObject CombinationChild;
    public GameObject Combining;
    public GameObject CombinEnd;
    public GameObject Study;


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
        //���� �ҷ�����
        //GameLoad();
        //����Ʈ �̸�
        questText.text = questManager.CheckQuest();
        questTextIng.text = questManager.CheckQuest();
    }

    void Update()
    {
        //�޴� â Ű��,����
        if(Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else if (!menuSet.activeSelf && !CombinationUI.activeSelf && !TabMenu.activeSelf 
                  && SceneManager.GetActiveScene().buildIndex != 0) 
            {
                menuSet.SetActive(true);
            }
            else
            {
                //�ΰ��� �ߺ����� ������ ����
                menuSet.SetActive(false);
                TabMenu.SetActive(false);
            }


            if (CombinationUI.activeSelf && CombinationChild.activeSelf)
            {
                CombinationChild.SetActive(false);                
                CombinationAnim.SetTrigger("isInit");
            }
            if(CombinationUI.activeSelf && !CombinationChild.activeSelf)
            {
                CombinationUI.SetActive(false);
            }
            
        }

        //TabŰ Ű��,����
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

        //�ߺ�����
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

    //ä�� �׼�
    public void Forage()
    {
        //ä��
        if (player.scanObject.tag == "G")
        {
            Plant.FlowerDestory();
            if (PrevGcount != Gcount)
                DropBox.DropPixel("G", 1);

            PrevGcount = Gcount;
        }
        else if (player.scanObject.tag == "R")
        {
            Plant.RockDestory();
            if (PrevRcount != Rcount)
                DropBox.DropPixel("R", 1);

            PrevRcount = Rcount;
        }
        else if (player.scanObject.tag == "B")
        {
            Plant.BoxDestory();
            if (PrevBcount != Bcount)
                DropBox.DropPixel("B", 1);

            PrevBcount = Bcount;
        }
    }

    //��ȣ�ۿ� �׼�
    public void Interaction()
    {        
        //ù��° ����Ʈ Ŭ����
        if (Gcount >= 3 && player.scanObject.name == "NpcB" && questManager.questId == 20)
        {
            questManager.questId += 10;
            questManager.questActionIndex = 0;
            Gcount -= 3;

            //�ٲ� count�� prev���� �Ҵ����� ������ �ؽ�Ʈ�� �ѹ��� ��µ�
            PrevGcount = Gcount;
        }

        //�����Ϸ�����
        if(player.scanObject.name == "Study")
        {
            Study.SetActive(true);

            if (Study.activeSelf)
                isAction = true;
            else if (!Study.activeSelf)
                isAction = false;
        }

        //���ձ�
        if(player.scanObject.name == "Combination")
        {
            CombinationUI.SetActive(true);
            if(!CombinationChild.activeSelf && !Combining.activeSelf && !CombinEnd.activeSelf)
                CombinationAnim.SetTrigger("isInit");

            if (CombinationUI.activeSelf)
                isAction = true;
            else if (!CombinationUI.activeSelf)
                isAction = false;
        }
    }

    //��ȭ �׼�
    public void Action(GameObject scanObj)
    {
        //���� ������Ʈ ��������
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();

        //Npc �� ��쿡�� ��ȭ����
        if (objData.isNpc)
        {
            Talk(objData.Id);
        }

        //�̾߱� �����ֱ�
        if(player.scanObject.tag == "Npc")
            talkPanel.SetBool("isShow", isAction);

        if (objData.isNpc)
        {
            NpcName.gameObject.SetActive(true);
            NpcName.text = scanObject.name;
        }
        else
            NpcName.gameObject.SetActive(false);

    }

    //��ȭ set, end
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
            //���� ����Ʈ ��ȣ �޾ƿͼ� ��� -> �Ϸ�� ����Ʈ ���
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


    //���� ����
    public void GameSave()
    {
        //�÷��̾� ��ġ����
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);

        //����Ʈ �ѹ� ����
        PlayerPrefs.SetInt("QustId", questManager.questId);
        PlayerPrefs.SetInt("QustActionIndex", questManager.questActionIndex);

        //������ RGB�� ����
        PlayerPrefs.SetInt("Rcount", Rcount);
        PlayerPrefs.SetInt("Gcount", Gcount);
        PlayerPrefs.SetInt("Bcount", Bcount);

        //�� ��ȣ ����
        //���� �� ��ȣ �ҷ����� ������Ʈ���� �����ϱ�
        PlayerPrefs.SetInt("SceneNum", SceneManager.GetActiveScene().buildIndex);
        
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    //���� �ҷ�����
    public void GameLoad()
    {
        //�ѹ��� ������ �� ������ �� ��ȯ(�ε����)
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

    //���� ����
    public void GameExit()
    {
        Application.Quit();
    }
}
