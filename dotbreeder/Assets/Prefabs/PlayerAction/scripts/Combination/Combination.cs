using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combination : MonoBehaviour
{
    public PlayerAction player;
    public GameManager Manager;
    public Timer timer;

    public GameObject CombineUI;
    public GameObject CombineChild;
    public GameObject Combining;
    public GameObject CombineEnd;

    public Animator CombineAnim;
    public Animator ChildAnim;
    public Animator CombiningAnim;

    //���ձ� UI
    public Text Title;
    public Text time;
    public Image image;
    public Text Content;
    public Text R;
    public Text G;
    public Text B;
    public Text ProduceNum;

    //������ UI
    public Text TitleIng;
    public Text timeIng;
    public Image imageIng;

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
        if (pageNumItem == 1 && ItemPage)
        {
            UnlockBtnText[0].text = "1���� ������";
            UnlockBtnText[1].text = "1���� ������";
            UnlockBtnText[2].text = "1���� ������";
            UnlockBtnText[3].text = "2���� ������";
            UnlockBtnText[4].text = "2���� ������";
            UnlockBtnText[5].text = "2���� ������";            
        }
        //2������
        if(pageNumItem == 2 && ItemPage)
        {
            UnlockBtnText[0].text = "3���� ����";
            UnlockBtnText[1].text = "3���� ������";
            UnlockBtnText[2].text = "3���� ������";
            UnlockBtnText[3].text = "4���� ������";
            UnlockBtnText[4].text = "4���� ������";
            UnlockBtnText[5].text = "4���� ������";            
        }
        //3������~~
        if (pageNumItem == 3 && ItemPage)
        {
            UnlockBtnText[0].text = "????";
            UnlockBtnText[1].text = "????";
            UnlockBtnText[2].text = "????";
            UnlockBtnText[3].text = "????";
            UnlockBtnText[4].text = " ";
            UnlockBtnText[5].text = " ";            
        }

        //���๰ ������
        //1������
        if (pageNumBuilding == 1 && BuildingPage)
        {
            UnlockBtnText[0].text = "1���� ���๰";
            UnlockBtnText[1].text = "2���� ���๰";
            UnlockBtnText[2].text = "3���� ���๰";
            UnlockBtnText[3].text = "4���� ���๰";
            UnlockBtnText[4].text = "���๰";
            UnlockBtnText[5].text = "���๰";
        }
        //2������
        if (pageNumBuilding == 2 && BuildingPage)
        {
            UnlockBtnText[0].text = "????";
            UnlockBtnText[1].text = "????";
            UnlockBtnText[2].text = "????";
            UnlockBtnText[3].text = "????";
            UnlockBtnText[4].text = "????";
            UnlockBtnText[5].text = "????";
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
        //�����ϳ� �Ҵ��ؼ� 1�������ϰ�� �� ���๰, 2������ ������ 3������ ������2 ��� �ѱ��?
        if (pageNumItem == 1 && ItemPage)
            Item();
        else if (pageNumItem == 2 && ItemPage)
            Candy();

        if (pageNumBuilding == 1 && BuildingPage)
            TreeHouse();
    }
    public void Button2()
    {
        BtnClick();
        if (pageNumItem == 1 && ItemPage)
            Item();
        //else if (pageNum == 2)

        if (pageNumBuilding == 1 && BuildingPage)
            Bed();
    }
    public void Button3()
    {
        BtnClick();
        if (pageNumItem == 1 && ItemPage)
            Item();
        //else if (pageNum == 2)

        if (pageNumBuilding == 1 && BuildingPage)
            Stove();
    }
    public void Button4()
    {
        BtnClick();
        if (pageNumItem == 1 && ItemPage)
            Item();
        //else if (pageNum == 2) 

        if (pageNumBuilding == 1 && BuildingPage)
            Table();
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

        if (timer.HouseOn == false)
            timer.isGive = true;
        else if (timer.HouseOn == true)
            timer.isOnHouse = true;
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
        
    }
    //�ǹ� ���� â
    public void BuildingBtn()
    {
        CombineAnim.SetBool("isButton", false);
        BuildingPage = true;
        ItemPage = false;
        CombineChild.SetActive(false);
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

    //�� �Ʒ����ʹ� ���߿� ������ ���������Ѱ�..? ���÷� ��Ƶ�
    public void TreeHouse()
    {
        RequiredR = 1;
        RequiredG = 2;
        RequiredB = 1;
        GetHouseTime = 7;
        timer.combineTIme = GetHouseTime;

        //���ձ� �ؽ�Ʈ        
        Title.text = "�볪����";
        time.text = "���� �ð� : " + GetHouseTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "�볪�����̶��ϴ�! ������ ��������,,";

        //������ �ؽ�Ʈ
        TitleIng.text = "�볪����";
        timeIng.text = "���� �ð� : " + GetHouseTime.ToString();
        //imageIng.sprtie = ~~

        timer.CurrentCombinging = 1;

        ProduceCount();
    }
    public void Bed()
    {
        RequiredR = 2;
        RequiredG = 2;
        RequiredB = 1;
        GetBedTime = 15;
        timer.combineTIme = GetBedTime;
                
        Title.text = "��ź ���ħ��";
        time.text = "���� �ð� : " + GetBedTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "��ź ���ħ���Դϴ�! ���� ���������";

        //������ �ؽ�Ʈ
        TitleIng.text = "��ź ���ħ��";
        timeIng.text = "���� �ð� : " + GetBedTime.ToString();
        //imageIng.sprtie = ~~

        timer.CurrentCombinging = 2;

        ProduceCount();
    }
    public void Stove()
    {
        RequiredR = 2;
        RequiredG = 2;
        RequiredB = 2;
        GetStoveTime = 20;
        timer.combineTIme = GetStoveTime;
                
        Title.text = "������";
        time.text = "���� �ð� : " + GetStoveTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "�������Դϴ�! �����ؿ�";
               
        //������ �ؽ�Ʈ
        TitleIng.text = "������";
        timeIng.text = "���� �ð� : " + GetStoveTime.ToString();
        //imageIng.sprtie = ~~

        timer.CurrentCombinging = 3;

        ProduceCount();
    }
    public void Table()
    {
        RequiredR = 3;
        RequiredG = 2;
        RequiredB = 3;
        GetTableTime = 25;
        timer.combineTIme = GetTableTime;
                
        Title.text = "���̺� ��";
        time.text = "���� �ð� : " + GetTableTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "���̺� ���Դϴ�! � ���ϼ���.";
        
        //������ �ؽ�Ʈ
        TitleIng.text = "���̺� ��";
        timeIng.text = "���� �ð� : " + GetTableTime.ToString();
        //imageIng.sprtie = ~~

        timer.CurrentCombinging = 4;

        ProduceCount();
    }
    public void Candy()
    {
        RequiredR = 1;
        RequiredG = 1;
        RequiredB = 1;
        GetHouseTime = 10;
        timer.combineTIme = GetHouseTime;

        //���ձ� �ؽ�Ʈ        
        Title.text = "����";
        time.text = "���� �ð� : " + GetHouseTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "�޴��� ����! �̻� ���,,";

        //������ �ؽ�Ʈ
        TitleIng.text = "����";
        timeIng.text = "���� �ð� : " + GetHouseTime.ToString();
        //imageIng.sprtie = ~~

        ProduceCount();
    }
    //������ ���߿� ������
    public void Item()
    {
        RequiredR = 1;
        RequiredG = 1;
        RequiredB = 1;
        GetHouseTime = 7;
        timer.combineTIme = GetHouseTime;

        //���ձ� �ؽ�Ʈ        
        Title.text = "1���� ������";
        time.text = "���� �ð� : " + GetHouseTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "��ƾƤ�,,�ڰ�;�,,";

        //������ �ؽ�Ʈ
        TitleIng.text = "1���� ������";
        timeIng.text = "���� �ð� : " + GetHouseTime.ToString();
        //imageIng.sprtie = ~~

        ProduceCount();
    }
}
