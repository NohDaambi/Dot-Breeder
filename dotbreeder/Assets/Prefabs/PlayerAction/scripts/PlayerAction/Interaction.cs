using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public PlayerAction Player;
    public GameManager Manager;
    public QuestManager questManager;
    public PieManager PixelCountManager;
    public PieceInform pieceInform;
    public TalkManager talkManager;
    public TypeEffect talk;

    public GameObject MiniGame;
    public GameObject CombinationUI;
    public GameObject CombinationChild;
    public GameObject Combining;
    public GameObject CombinEnd;

    public Text questText;
    public Text NpcName;

    public Image portraitImg;
    public Sprite PrevPortrait;

    public Animator CombinationAnim;
    public Animator PortraitAnim;

    public int talkIndex;
    public static bool ForestopenDoor;
    public static bool isTalkPlayer = false;

    //채집 액션
    public void Forage(GameObject scanobj)
    {

        //채집 << 여기에 채집 카운트 적용해서 드랍시 나오는 텍스트UI 출력하게 해야함!
        if (scanobj.tag == "G")
        {            
            Manager.Gcount+=1;
            Manager.PrevGcount = Manager.Gcount;
            scanobj.GetComponent<PixelpieceController>().Destroy_Pixel();//자기 자신 삭제!
            Manager.DropBox.DropPixel("G", 1);  
            PixelCountManager.PixelDataLoad();      
        }
        else if (scanobj.tag == "R")
        {            
            Manager.Rcount+=1;
            Manager.PrevRcount = Manager.Rcount;
            scanobj.GetComponent<PixelpieceController>().Destroy_Pixel();//자기 자신 삭제!
            Manager.DropBox.DropPixel("R", 1);   
            PixelCountManager.PixelDataLoad();
        }
        else if (scanobj.tag == "B")
        {            
            Manager.Bcount+=1;
            Manager.PrevBcount = Manager.Bcount;
            scanobj.GetComponent<PixelpieceController>().Destroy_Pixel();//자기 자신 삭제!
            Manager.DropBox.DropPixel("B", 1);  
            PixelCountManager.PixelDataLoad();
        }

       
    }

    //상호작용 액션
    public void playerInteraction()
    {
        //첫번째 퀘스트 클리어
        if (Manager.Gcount >= 3 && Player.scanObject.name == "NpcB" && Manager.questManager.questId == 20)
        {
            questManager.questId += 10;
            questManager.questActionIndex = 0;
            Manager.Gcount -= 3;

            //바뀐 count를 prev값에 할당하지 않으면 텍스트가 한번더 출력됨
            Manager.PrevGcount = Manager.Gcount;
        }

        //교육하러가기
        if (Player.scanObject.name == "Study")
        {
            if (Manager.DotLevel == 1)
            {
                Debug.Log("사용하기엔 도트가 아직 어리다..");
            }
            else if (Manager.DotLevel >= 2)
            {
                MiniGame.SetActive(true);

                if (MiniGame.activeSelf)
                    Manager.isAction = true;
                else if (!MiniGame.activeSelf)
                    Manager.isAction = false;
            }
        }

        //조합기
        if (Player.scanObject.name == "Combination")
        {
            /*QuestObj questobj = Manager.transform.Find("CombinationObj").GetComponent<QuestObj>();
            if(questobj.IsbeonCall==true||questobj.IsAvtive==true)
            {
                //퀘스트가 대기중이거나 실행중일때
                questobj.ShowMessage();
                questobj.IsbeonCall=false; //한번 상호작용을 하면 퀘스트 생성요청보냄.
                return;
            }
            //IsbeonCall,IsAvtive가 모두 false일때만 실행.
            */
            CombinationUI.SetActive(true);
            if (!CombinationChild.activeSelf && !Combining.activeSelf && !CombinEnd.activeSelf)
                CombinationAnim.SetBool("isButton", false);

            if (CombinationUI.activeSelf)
                Manager.isAction = true;
            else if (!CombinationUI.activeSelf)
                Manager.isAction = false;
        }

        //데이터 조각
        if (Player.scanObject.tag == "DataPiece")
        {
            pieceInform.FindDataPiece();
        }

        //보물상자
        if (Player.scanObject.tag == "ForestTreasureChest")
        {
            ForestopenDoor = true;
        }
    }

    //대화 액션
    public void Action(GameObject scanObj)
    {
        //현재 오브젝트 가져오기
        Manager.scanObject = scanObj;
        ObjData objData = Manager.scanObject.GetComponent<ObjData>();

        // (obj.isCombination && ()<--여기에 퀘스트 클리어 조건 넣으면 퀘스트 클리어시 조합기 사용 가능) 
        // 현재는 도트레벨 1에만 대사출력, 2렙에는 조합기 켜지게끔 조건 걸어놓은건데 예람이꺼 잘 모르겠어서 안나오는중, while문안에 뭘 넣어야 할 듯,,        
        if (objData.isNpc || objData.isDataPiece || (objData.isStudy && Manager.DotLevel == 1) || (objData.isCombination && Manager.DotLevel == 1)) 
        {
            Talk(objData.Id);
            NpcName.gameObject.SetActive(true);
            NpcName.text = Manager.scanObject.name;
            //isTalkPlayer = true; npc와의 애기가 끝나는거 알아야함
        }
        else
        {
            NpcName.gameObject.SetActive(false);
            //isTalkPlayer = false;
        }

        //이야기 보여주기
        if (Player.scanObject.tag == "Npc" || Player.scanObject.tag == "DataPiece" 
            || (Player.scanObject.name == "Study" && Manager.DotLevel == 1) 
            || (Player.scanObject.name == "Combination" && Manager.DotLevel == 1))
            Manager.talkPanel.SetBool("isShow", Manager.isAction);
    }

    //대화 set, end
    public void Talk(int id)
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
            Manager.isAction = false;
            talkIndex = 0;
            return;
        }

        //Show Portrait
        if (Player.scanObject.tag == "Npc")
        {
            //Continue Talk      
            talk.SetMsg(talkData.Split(':')[0]);
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);

            //Anim Portrait
            if (PrevPortrait != portraitImg.sprite)
            {
                PortraitAnim.SetTrigger("doEffect");
                PrevPortrait = portraitImg.sprite;
            }
        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        Manager.isAction = true;
        talkIndex++;
    }
}
