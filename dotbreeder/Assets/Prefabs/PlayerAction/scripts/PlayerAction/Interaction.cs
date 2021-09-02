using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public PlayerAction Player;
    public GameManager Manager;
    public QuestManager questManager;
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
    public static bool openDoor;

    //ä�� �׼�
    public void Forage(GameObject scanobj)
    {

        //ä�� << ���⿡ ä�� ī��Ʈ �����ؼ� ����� ������ �ؽ�ƮUI ����ϰ� �ؾ���!
        if (scanobj.tag == "G")
        {            
            if (Manager.PrevGcount != Manager.Gcount)
                Manager.DropBox.DropPixel("G", 1);

            Manager.Gcount+=1;
            Manager.PrevGcount = Manager.Gcount;
           
        }
        else if (scanobj.tag == "R")
        {           
            if (Manager.PrevRcount != Manager.Rcount)
                Manager.DropBox.DropPixel("R", 1);
            Manager.Rcount+=1;
            Manager.PrevRcount = Manager.Rcount;
        }
        else if (scanobj.tag == "B")
        {           
            if (Manager.PrevBcount != Manager.Bcount)
                Manager.DropBox.DropPixel("B", 1);
            Manager.Bcount+=1;
            Manager.PrevBcount = Manager.Bcount;
        }
        

        scanobj.GetComponent<PixelpieceController>().Destroy_Pixel();//�ڱ� �ڽ� ����!
    }

    //��ȣ�ۿ� �׼�
    public void playerInteraction()
    {
        //ù��° ����Ʈ Ŭ����
        if (Manager.Gcount >= 3 && Player.scanObject.name == "NpcB" && Manager.questManager.questId == 20)
        {
            questManager.questId += 10;
            questManager.questActionIndex = 0;
            Manager.Gcount -= 3;

            //�ٲ� count�� prev���� �Ҵ����� ������ �ؽ�Ʈ�� �ѹ��� ��µ�
            Manager.PrevGcount = Manager.Gcount;
        }

        //�����Ϸ�����
        if (Player.scanObject.name == "Study")
        {
            if (Manager.DotLevel == 1)
            {
                Debug.Log("����ϱ⿣ ��Ʈ�� ���� ���..");
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

        //���ձ�
        if (Player.scanObject.name == "Combination")
        {
            QuestObj questobj = Manager.transform.Find("CombinationObj").GetComponent<QuestObj>();
            if(questobj.IsbeonCall==true||questobj.IsAvtive==true)
            {
                //����Ʈ�� ������̰ų� �������϶�
                questobj.ShowMessage();
                return;
            }
            
            CombinationUI.SetActive(true);
            if (!CombinationChild.activeSelf && !Combining.activeSelf && !CombinEnd.activeSelf)
                CombinationAnim.SetBool("isButton", false);

            if (CombinationUI.activeSelf)
                Manager.isAction = true;
            else if (!CombinationUI.activeSelf)
                Manager.isAction = false;
        }

        //������ ����
        if (Player.scanObject.tag == "DataPiece")
        {
            pieceInform.FindDataPiece();
        }

        //��������
        if (Player.scanObject.tag == "TreasureChest")
        {
            openDoor = true;

        }
    }

    //��ȭ �׼�
    public void Action(GameObject scanObj)
    {
        //���� ������Ʈ ��������
        Manager.scanObject = scanObj;
        ObjData objData = Manager.scanObject.GetComponent<ObjData>();

        //Npc �� ��쿡�� ��ȭ����
        if (objData.isNpc || objData.isDataPiece || (objData.isStudy && Manager.DotLevel == 1))
        {
            Talk(objData.Id);
            NpcName.gameObject.SetActive(true);
            NpcName.text = Manager.scanObject.name;
        }
        else
            NpcName.gameObject.SetActive(false);


        //�̾߱� �����ֱ�
        if (Player.scanObject.tag == "Npc" || Player.scanObject.tag == "DataPiece" || (Player.scanObject.name == "Study" && Manager.DotLevel == 1))
            Manager.talkPanel.SetBool("isShow", Manager.isAction);
    }

    //��ȭ set, end
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
