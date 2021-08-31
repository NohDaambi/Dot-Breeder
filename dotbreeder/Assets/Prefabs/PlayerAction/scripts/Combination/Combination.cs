using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combination : MonoBehaviour
{
    public PlayerAction player;
    public GameManager Manager;
    public Timer timer;
    public HouseManager houseManager;
    public ItemManager itemManager;

    public GameObject CombineUI;
    public GameObject CombineChild;
    public GameObject Combining;
    public GameObject CombineEnd;

    public Animator CombineAnim;
    public Animator ChildAnim;
    public Animator CombiningAnim;
    public Animator ChangeItem;

    //���ձ� UI
    public Text Title;
    public Text time;
    public Image image;
    public Text Content;
    public Text R;
    public Text G;
    public Text B;
    public Text ProduceNum;
    public Image[] ShowItemArr = new Image[6];
    public Image[] CombineItemArr = new Image[24]; // 0~2 step1 3~5 step2 6~14 step3(678 ���� 91011 �ر� 121314 ���� 15~23 step4(151617 ���� 181920 �ر� 212223 ����) 
    public Image[] CombineBuildingArr = new Image[12]; // 0~3 shack 4~7 Igloo 8~11 Desert 

    //������ UI
    public Text TitleIng;
    public Text timeIng;
    public Image imageIng;

    //���� ��
    public Image imageEnd;

    //���� �ð�
    public float GetHouseTime;
    public float GetBedTime;
    public float GetStoveTime;
    public float GetTableTime;

    //�ʿ��� ���
    public int RequiredR;
    public int RequiredG;
    public int RequiredB;

    //���� ������ ��
    public int produceNum;

    //�ִ� ���� ���� �� (�⺻�� : 1)
    public int maxR = 1;
    public int maxG = 1;
    public int maxB = 1;

    //���ձ� ������ ��� ��ư
    public Button[] UnlockButton = new Button[6];
    public Text[] UnlockBtnText = new Text[6];        

    //��� ��ư
    public Button[] LockButton = new Button[6];
    public Text[] LockBtnText = new Text[6];

    //�������ΰ�?, ������ �����ų� ����� �� false, ���չ�ư ������ true
    public bool isCombining;

    //���ձ� ������
    public Text pageText;
    public int pageNumItem = 1;
    public int pageNumBuilding = 1;
    public int pageMax;
    public bool ItemPage;
    public bool BuildingPage;

    public int DotItem;

    private static bool combineExist;
    void Awake()
    {
        ItemPage = true;
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            CombineChild.SetActive(false);
            Manager.isAction = false;
        }

        if(isCombining)
        {
            //�������϶� �ٸ� ��ư Ŭ�� ����
            for (int i = 0; i < UnlockButton.Length; i++)
            {
                UnlockButton[i].interactable = false;                
            }
        }
        else if(!isCombining)
        {
            for (int i = 0; i < UnlockButton.Length; i++)
            {
                UnlockButton[i].interactable = true;
            }
        }
        if(ItemPage)                
            pageText.text = pageNumItem.ToString()+ " / " + pageMax.ToString();
        if(BuildingPage)
            pageText.text = pageNumBuilding.ToString() + " / " + pageMax.ToString();

        //������ ������
        //1������
        if (pageNumItem == 1 && ItemPage && Manager.stageNum >= 1)
        {
            UnlockBtnText[0].text = "����";
            UnlockBtnText[1].text = "������";
            UnlockBtnText[2].text = "������";
            UnlockBtnText[3].text = "�౸��";
            UnlockBtnText[4].text = "������";
            UnlockBtnText[5].text = "����";            
        }
        //2������
        if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
        {
            UnlockBtnText[0].text = "���";
            UnlockBtnText[1].text = "�۰�";
            UnlockBtnText[2].text = "����";
            UnlockBtnText[3].text = "��ġ";
            UnlockBtnText[4].text = "�尩";
            UnlockBtnText[5].text = "��������";            
        }
        if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
        {
            UnlockBtnText[0].text = "���˴�";
            UnlockBtnText[1].text = "������";
            UnlockBtnText[2].text = "�ΰ�";
            UnlockBtnText[3].text = "���� ���˴�";
            UnlockBtnText[4].text = "�尩";
            UnlockBtnText[5].text = "��ä";
        }
        if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
        {
            UnlockBtnText[0].text = "��";
            UnlockBtnText[1].text = "�������";
            UnlockBtnText[2].text = "����";
            UnlockBtnText[3].text = "��ġ��";
            UnlockBtnText[4].text = "ȭ��ǰ";
            UnlockBtnText[5].text = "��������";
        }

        //���๰ ������
        //1������
        if (pageNumBuilding == 1 && BuildingPage && Manager.stageNum == 1)
        {
            UnlockBtnText[0].text = "�볪����";
            UnlockBtnText[1].text = "��ź ���ħ��";
            UnlockBtnText[2].text = "������";
            UnlockBtnText[3].text = "���̺� ��";
            UnlockBtnText[4].text = "????";
            UnlockBtnText[5].text = "????";
        }
        if (pageNumBuilding == 1 && BuildingPage && Manager.stageNum == 2)
        {
            UnlockBtnText[0].text = "�̱۷�";
            UnlockBtnText[1].text = "���ħ��";
            UnlockBtnText[2].text = "���ÿ�ǰ ������";
            UnlockBtnText[3].text = "������(����)";
            UnlockBtnText[4].text = "????";
            UnlockBtnText[5].text = "????";
        }
        if (pageNumBuilding == 1 && BuildingPage && Manager.stageNum == 3)
        {
            UnlockBtnText[0].text = "õ��";
            UnlockBtnText[1].text = "�ظ� ħ��";
            UnlockBtnText[2].text = "����, �׸�";
            UnlockBtnText[3].text = "����ȭ��, ����";
            UnlockBtnText[4].text = "????";
            UnlockBtnText[5].text = "????";
        }

        //������
        if (ItemPage)
        {
            //���� ���� �̹��� ���
            if (Manager.DotLevel == 1)
            {
                if (pageNumItem == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        ShowItemArr[i].color = new Color(255, 255, 255, 255);
                    }
                    for (int i = 3; i < 6; i++)
                    {
                        ShowItemArr[i].color = new Color(0, 0, 0, 150);
                    }
                }

                if (pageNumItem >= 2)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        ShowItemArr[i].color = new Color(0, 0, 0, 150);
                    }
                }
            }
            else if (Manager.DotLevel == 2)
            {
                if (pageNumItem == 1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        ShowItemArr[i].color = new Color(255, 255, 255, 255);
                    }
                }

                if (pageNumItem >= 2)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        ShowItemArr[i].color = new Color(0, 0, 0, 150);
                    }
                }
            }
            else if (Manager.DotLevel == 3)
            {
                if (pageNumItem == 1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        ShowItemArr[i].color = new Color(255, 255, 255, 255);
                    }
                }

                if (pageNumItem == 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        ShowItemArr[i].color = new Color(255, 255, 255, 255);
                    }
                    for (int i = 3; i < 6; i++)
                    {
                        ShowItemArr[i].color = new Color(0, 0, 0, 150);
                    }
                }
            }
            else if (Manager.DotLevel == 4 && pageNumItem <= 2)
            {
                for (int i = 0; i < 6; i++)
                {
                    ShowItemArr[i].color = new Color(255, 255, 255, 255);
                }
            }

            //1����,2���� ���� ������
            if (Manager.stageNum >= 1 && pageNumItem == 1)
            {
                for (int i = 0; i < ShowItemArr.Length; i++)
                {
                    ShowItemArr[i].sprite = CombineItemArr[i].sprite;
                }
            }
            //3���� ������
            if (Manager.stageNum == 1 && pageNumItem == 2)
            {
                ItemStageSpriteFunc(6);
            }
            //���
            else if (Manager.stageNum == 2 && pageNumItem == 2)
            {
                ItemStageSpriteFunc(9);
            }
            //����
            else if (Manager.stageNum == 3 && pageNumItem == 2)
            {
                ItemStageSpriteFunc(12);
            }
        }
        //�ǹ�
        if (BuildingPage)
        {
            if (Manager.DotLevel == 1)
            {
                BuildingSpriteFunc(1);
            }
            else if (Manager.DotLevel == 2)
            {
                BuildingSpriteFunc(2);
            }
            else if (Manager.DotLevel == 3)
            {
                BuildingSpriteFunc(3);
            }
            else if (Manager.DotLevel == 4)
            {
                BuildingSpriteFunc(4);
            }
            //�������� �� ��������Ʈ
            if (Manager.stageNum == 1)
            {
                BuildingStageSpriteFunc(0);
            }
            else if (Manager.stageNum == 2)
            {
                BuildingStageSpriteFunc(4);
            }
            else if (Manager.stageNum == 3)
            {
                BuildingStageSpriteFunc(8);
            }
        }

    }
    public void ItemStageSpriteFunc(int num)
    {
        for (int i = 0; i < 3; i++)
        {
            ShowItemArr[i].sprite = CombineItemArr[i + num].sprite;
        }
        for (int i = 3; i < 6; i++)
        {
            ShowItemArr[i].sprite = CombineItemArr[i + num + 6].sprite;
        }
    }
    public void BuildingSpriteFunc(int level)
    {
        for (int i = 0; i < level; i++)
        {
            ShowItemArr[i].color = new Color(255, 255, 255, 255);
        }
        for (int i = level; i < 6; i++)
        {
            ShowItemArr[i].color = new Color(0, 0, 0, 150);
        }
    }
    public void BuildingStageSpriteFunc(int num)
    {
        for (int i = 0; i < 4; i++)
        {
            ShowItemArr[i].sprite = CombineBuildingArr[i + num].sprite;
        }
        for (int i = 4; i < 6; i++)
        {
            ShowItemArr[i].color = new Color(0, 0, 0, 0);
        }
    }

    //��ư Ŭ�� ��
    public void BtnClick()
    {
        CombineAnim.SetBool("isButton", true);
        if (!isCombining)
            CombineChild.SetActive(true);
        else if (isCombining)
        {            
            Combining.SetActive(true);            
        }
        ChildAnim.SetTrigger("isShow");
    }

    public void Button1()
    {
        BtnClick();
        //��
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.Milk();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.Beanie();

        //����
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.Milk();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.FishingRod();

        //�縷
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
            itemManager.Chur();

        if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Forest1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 1)
            itemManager.TreeHouse();
        else if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Ocene1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 2)
            itemManager.Igloo();
    }
    public void Button2()
    {
        BtnClick();
        //��
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.jjokjjok2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.Driver();

        //����
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.jjokjjok2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.Worm();

        //�縷
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 3)
            itemManager.Milk();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
            itemManager.NailClipper();

        if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Forest1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 1)
            itemManager.Bed();
        else if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Ocene1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 2)
            itemManager.IceBed();
    }
    public void Button3()
    {
        BtnClick();
        //��
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.DDalang2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.Axe();

        //����
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.DDalang2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.Bandana();

        //�縷
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 3)
            itemManager.Milk();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
            itemManager.Hat();

        if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Forest1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 1)
            itemManager.Stove();
        else if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Ocene1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 2)
            itemManager.FishingTool();
    }
    public void Button4()
    {
        BtnClick();
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.SoccerBall();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.Hammer();

        //����
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.SoccerBall();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.GreatFishingRod();

        //�縷
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 3)
            itemManager.Milk();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
            itemManager.Apron();

        if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Forest1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 1)
            itemManager.Table();
        else if (pageNumBuilding == 1 && BuildingPage && (SceneManager.GetActiveScene().name == "Ocene1" || SceneManager.GetActiveScene().name == "House") && Manager.stageNum == 2)
            itemManager.Aquarium();
    }
    public void Button5()
    {
        BtnClick();
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.WoodenDoll();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.ForestGlove();

        //����
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.WoodenDoll();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.IceGlove();

        //�縷
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 3)
            itemManager.WoodenDoll();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
            itemManager.Cosmetic();
    }
    public void Button6()
    {
        BtnClick();
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.Candy();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.GreatAxe();

        //����
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.Candy();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.LandingNet();

        //�縷
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 3)
            itemManager.Candy();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
            itemManager.Dust();
    }

    //���� ��ư
    public void ProduceButton()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            Manager.Rcount -= RequiredR * produceNum;
            Manager.Gcount -= RequiredG * produceNum;
            Manager.Bcount -= RequiredB * produceNum;

            //�ٲ�� �Ҵ������ �ؽ�ƮUI �ߺ� ��� ����
            Manager.PrevGcount = Manager.Gcount;
            Manager.PrevRcount = Manager.Rcount;
            Manager.PrevBcount = Manager.Bcount;

            CombineChild.SetActive(false);
            Combining.SetActive(true);
            CombiningAnim.SetTrigger("isShow");
            isCombining = true;
        }
        else if(Manager.Rcount <= RequiredR || Manager.Gcount <= RequiredG || Manager.Bcount <= RequiredB)
        {
            ChildAnim.SetTrigger("isNotFull");
        }

    }
    //�ð� ���̱�
    public void TimeReduce()
    {
        //1��ư 1�� ����
        if (timer.combineTIme > 0)
        { 
            timer.combineTIme--;
            timer.transTime++;
        }
    }
    //���� ���
    public void CombineCancel()
    {
        Combining.SetActive(false);
        CombineChild.SetActive(true);
        Manager.Rcount += RequiredR * produceNum;
        Manager.Gcount += RequiredG * produceNum;
        Manager.Bcount += RequiredB * produceNum;

        //�ٲ�� �Ҵ������ �ؽ�ƮUI �ߺ� ��� ����
        Manager.PrevGcount = Manager.Gcount;
        Manager.PrevRcount = Manager.Rcount;
        Manager.PrevBcount = Manager.Bcount;

        isCombining = false;

        //�ʱ�ȭ
        timer.combineTIme += timer.transTime;
        isCombining = false;
        timer.currentTime = 0;
        timer.transTime = 0;
        timer.isPlus = false;
    }
    //������ �ѱ��
    public void GiveItem()
    {
        Combining.SetActive(false);
        CombineEnd.SetActive(false);
        CombineUI.SetActive(false);

        Manager.isAction = false;

        //��Ʈ���� �ش� ������ �Ҵ��ϱ�, �̸��ҷ��ͼ� �� �� �Ҵ�
        DotItem += produceNum;

        if (timer.ShackOn == false)
            timer.isGive = true;
        else if (timer.ShackOn == true)
            timer.isOnShack = true;

        if (timer.IglooOn == false)
            timer.isGive = true;
        else if (timer.IglooOn == true)
            timer.isOnIgloo = true;
    }

    //�ִ�� �����ϱ�
    public void Max()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            maxR = Manager.Rcount / RequiredR;
            maxG = Manager.Gcount / RequiredG;
            maxB = Manager.Bcount / RequiredB;

            if (maxR <= maxG && maxR <= maxB)
            {
                produceNum = maxR;
                ProduceNum.text = produceNum.ToString();
            }
            if (maxG <= maxR && maxG <= maxB)
            {
                produceNum = maxG;
                ProduceNum.text = produceNum.ToString();
            }
            if (maxB <= maxG && maxB <= maxR)
            {
                produceNum = maxB;
                ProduceNum.text = produceNum.ToString();
            }

        }
    }
    //�ִ뿡�� �� �����ϱ�
    public void Half()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            maxR = Manager.Rcount / RequiredR;
            maxG = Manager.Gcount / RequiredG;
            maxB = Manager.Bcount / RequiredB;

            if (maxR <= maxG && maxR <= maxB)
            {
                produceNum = maxR / 2;
                ProduceNum.text = produceNum.ToString();
            }
            if (maxG <= maxR && maxG <= maxB)
            {
                produceNum = maxG / 2;
                ProduceNum.text = produceNum.ToString();
            }
            if (maxB <= maxG && maxB <= maxR)
            {
                produceNum = maxB / 2;
                ProduceNum.text = produceNum.ToString();
            }

        }
    }
    //������ ���� ��ư
    public void LeftBtn()
    {
        if(pageNumItem > 1 && ItemPage)
            pageNumItem--;
        
        if(pageNumBuilding > 1 && BuildingPage)
            pageNumBuilding--;
    }
    //������ ������ ��ư
    public void RightBtn()
    {
        if(pageNumItem < pageMax && ItemPage)
            pageNumItem++;

        if (pageNumBuilding < pageMax && BuildingPage)
            pageNumBuilding++;
    }
    //������ ���� â
    public void ItemBtn()
    {
        CombineAnim.SetBool ("isButton", false);
        ItemPage = true;
        BuildingPage = false;
        CombineChild.SetActive(false);
        ChangeItem.SetTrigger("isItem");     
    }
    //�ǹ� ���� â
    public void BuildingBtn()
    {
        CombineAnim.SetBool("isButton", false);
        BuildingPage = true;
        ItemPage = false;
        CombineChild.SetActive(false);
        ChangeItem.SetTrigger("isBuilding");
    }

    public void ProduceCount()
    {

        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;

        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            produceNum = 1;
        }
        else
        {
            produceNum = 0;
        }

        ProduceNum.text = produceNum.ToString();
    }
   
}
