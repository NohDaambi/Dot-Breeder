using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TalkManager talkManager;
    public PlayerAction player;
    public Animator talkPanel;
    public QuestManager questManager;
    public DropTextBox DropBox;
    public DataPieceSort DataPiece;
    public Interaction PlayerInteraction;   
    public DoteStateManager DoteStateManager;

    public Rscore Rtext;
    public Gscore Gtext;
    public Bscore Btext;   

    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject TabMenu;
    public GameObject DataPieceObj;
    public GameObject miniGame;
    public GameObject PlayerObj;

    public int talkIndex;  

    //Pixel count as Total_���� �ȼ� ����
    public int totalR;
    public int totalG;
    public int totalB;

    //Pixel count as DotLevel_������ ������ ī��Ʈ �ʱ�ȭ.
    public int Rcount;
    public int Gcount;
    public int Bcount;

    public int PrevRcount;
    public int PrevGcount;
    public int PrevBcount;

    //About Dote
    public string DotName;
    public int DotLevel;
    public int DotStat;
    public string Hobby;

    public bool isAction;
    private static bool ManagerExist;

    public int stageNum;


    void Start()
    {
        //����Ʈ �̸�
        DotName = "����";
        DotLevel = 1;
        DotStat = 23;
        Hobby = "�����";
        DoteStateManager.LoadAllDoteInfo(); //��Ʈ���¸Ŵ������� UI�� ���� ���ε�
        StartCoroutine(DoteStateManager.GrowthDataLoad()); //db���� �Ľ�.
        DoteStateManager.PixelDataLoad();
        DoteStateManager.BarDataLoad();
        TabMenu.SetActive(false);
        

    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
            PlayerObj.SetActive(false);
        else
            PlayerObj.SetActive(true);

        //�������� �ѹ�
        if (SceneManager.GetActiveScene().name == "Forest1" || SceneManager.GetActiveScene().name == "Forest2")
            stageNum = 1;
        else if (SceneManager.GetActiveScene().name == "Ocene1" || SceneManager.GetActiveScene().name == "Ocene2")
            stageNum = 2;
        else if (SceneManager.GetActiveScene().name == "Desert1" || SceneManager.GetActiveScene().name == "Desert2")
            stageNum = 3;


        //�޴� â Ű��,����
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else if (!menuSet.activeSelf && !PlayerInteraction.CombinationUI.activeSelf && !TabMenu.activeSelf 
                  && SceneManager.GetActiveScene().buildIndex != 0 && !miniGame.activeSelf) 
                menuSet.SetActive(true);
            else
            {
                //�ΰ��� �ߺ����� ������ ����
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

        //TabŰ Ű��,����
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

        //��-1������ Ȱ��ȭ
        if (SceneManager.GetActiveScene().name == "Forest1")        
            DataPieceObj.SetActive(true);
        else
            DataPieceObj.SetActive(false);
    }

    void Awake()
    {
        instance = this;
        Time.timeScale = 1;

        //�ߺ�����
        if (!ManagerExist)
        {
            ManagerExist = true;            
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

       
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
