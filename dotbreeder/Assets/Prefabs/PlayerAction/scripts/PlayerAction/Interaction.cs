using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public PlayerAction Player;
    public GameManager Manager;
    public QuestManager questManager;
    public Plants Plant;
    public PieceInform pieceInform;
    public TalkManager talkManager;
    public TypeEffect talk;

    public GameObject MiniGame;
    public GameObject CombinationUI;
    public GameObject CombinationChild;
    public GameObject Combining;
    public GameObject CombinEnd;

    public Text questText;
    public Text questTextIng;
    public Text questTextEd;
    public Text NpcName;

    public Image portraitImg;
    public Sprite PrevPortrait;

    public Animator CombinationAnim;
    public Animator PortraitAnim;

    public int talkIndex;

    //ä�� �׼�
    public void Forage()
    {
        //ä��
        if (Player.scanObject.tag == "G")
        {
            Plant.FlowerDestory();
            if (Manager.PrevGcount != Manager.Gcount)
                Manager.DropBox.DropPixel("G", 1);

            Manager.PrevGcount = Manager.Gcount;
        }
        else if (Player.scanObject.tag == "R")
        {
            Plant.RockDestory();
            if (Manager.PrevRcount != Manager.Rcount)
                Manager.DropBox.DropPixel("R", 1);

            Manager.PrevRcount = Manager.Rcount;
        }
        else if (Player.scanObject.tag == "B")
        {
            Plant.BoxDestory();
            if (Manager.PrevBcount != Manager.Bcount)
                Manager.DropBox.DropPixel("B", 1);

            Manager.PrevBcount = Manager.Bcount;
        }
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
            MiniGame.SetActive(true);

            if (MiniGame.activeSelf)
                Manager.isAction = true;
            else if (!MiniGame.activeSelf)
                Manager.isAction = false;
        }

        //���ձ�
        if (Player.scanObject.name == "Combination")
        {
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
    }

    //��ȭ �׼�
    public void Action(GameObject scanObj)
    {
        //���� ������Ʈ ��������
        Manager.scanObject = scanObj;
        ObjData objData = Manager.scanObject.GetComponent<ObjData>();

        //Npc �� ��쿡�� ��ȭ����
        if (objData.isNpc || objData.isDataPiece)
        {
            Talk(objData.Id);
            NpcName.gameObject.SetActive(true);
            NpcName.text = Manager.scanObject.name;
        }
        else
            NpcName.gameObject.SetActive(false);


        //�̾߱� �����ֱ�
        if (Player.scanObject.tag == "Npc" || Player.scanObject.tag == "DataPiece")
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
            questText.text = questManager.CheckQuest(id);
            questTextIng.text = questManager.CheckQuest(id);
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
