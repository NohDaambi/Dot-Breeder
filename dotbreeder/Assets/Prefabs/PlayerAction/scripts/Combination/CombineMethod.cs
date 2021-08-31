using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombineMethod : MonoBehaviour
{
    public ItemManager itemManager;
    public GameManager Manager;

    public Text[] textArr = new Text[16];
    public Button[] buttonarr = new Button[16];

    public Image MethodImage;
    public Image stageImage;
    public Image[] stageimgarr = new Image[3];
    public Text RgbTxt;

    public int PageNum; //1 �� 2 ���� 3 �縷
    

    void Awake()
    {
        PageNum = 1;
    }
    void Update()
    {
        if(Manager.DotLevel == 1)
        {
            for (int i = 3; i < 12; i++)
            {
                buttonarr[i].interactable = false;
            }
            for (int i = 13; i < 16; i++)
            {
                buttonarr[i].interactable = false;
            }            
        }
        if(Manager.DotLevel == 2)
        {
            for (int i = 3; i < 6; i++)
            {
                buttonarr[i].interactable = true;
            }
            for (int i = 13; i < 14; i++)
            {
                buttonarr[i].interactable = true;
            }
        }
        if (Manager.DotLevel == 3)
        {
            for (int i = 6; i < 9; i++)
            {
                buttonarr[i].interactable = true;
            }
            for (int i = 13; i < 15; i++)
            {
                buttonarr[i].interactable = true;
            }
        }
        if (Manager.DotLevel == 4)
        {
            for (int i = 9; i < 12; i++)
            {
                buttonarr[i].interactable = true;
            }
            for (int i = 12; i < 16; i++)
            {
                buttonarr[i].interactable = true;
            }
        }

        if (PageNum == 1)
        {
            stageImage.sprite = stageimgarr[0].sprite;
            textArr[0].text = "���� ���չ�";
            textArr[1].text = "������ ���չ�";
            textArr[2].text = "������ ���չ�";
            textArr[3].text = "�౸�� ���չ�";
            textArr[4].text = "������ ���չ�";
            textArr[5].text = "���� ���չ�";
            textArr[6].text = "��� ���չ�";
            textArr[7].text = "�۰� ���չ�";
            textArr[8].text = "���� ���չ�";
            textArr[9].text = "��ġ ���չ�";
            textArr[10].text = "�尩 ���չ�";
            textArr[11].text = "�������� ���չ�";
            textArr[12].text = "�볪���� ���չ�";
            textArr[13].text = "��ź ���ħ�� ���չ�";
            textArr[14].text = "������ ���չ�";
            textArr[15].text = "���̺� �� ���չ�";
        }

        if(PageNum == 2)
        {
            stageImage.sprite = stageimgarr[1].sprite;
            textArr[0].text = "���� ���չ�";
            textArr[1].text = "������ ���չ�";
            textArr[2].text = "������ ���չ�";
            textArr[3].text = "�౸�� ���չ�";
            textArr[4].text = "������ ���չ�";
            textArr[5].text = "���� ���չ�";
            textArr[6].text = "���˴� ���չ�";
            textArr[7].text = "������ ���չ�";
            textArr[8].text = "�ΰ� ���չ�";
            textArr[9].text = "���� ���˴� ���չ�";
            textArr[10].text = "�尩 ���չ�";
            textArr[11].text = "��ä ���չ�";
            textArr[12].text = "�̱۷� ���չ�";
            textArr[13].text = "����ħ�� ���չ�";
            textArr[14].text = "���ÿ�ǰ ������ ���չ�";
            textArr[15].text = "������(����) ���չ�";
        }

        if(PageNum == 3)
        {
            stageImage.sprite = stageimgarr[2].sprite;
            textArr[0].text = "���� ���չ�";
            textArr[1].text = "������ ���չ�";
            textArr[2].text = "������ ���չ�";
            textArr[3].text = "�౸�� ���չ�";
            textArr[4].text = "������ ���չ�";
            textArr[5].text = "���� ���չ�";
            textArr[6].text = "�� ���չ�";
            textArr[7].text = "������� ���չ�";
            textArr[8].text = "���� ���չ�";
            textArr[9].text = "��ġ�� ���չ�";
            textArr[10].text = "ȭ��ǰ ���չ�";
            textArr[11].text = "�������� ���չ�";
            textArr[12].text = "õ�� ���չ�";
            textArr[13].text = "�ظ� ħ�� ���չ�";
            textArr[14].text = "���� �׸� ���չ�";
            textArr[15].text = "����ȭ��, ���� ���չ�";
        }
    }

    public void Left()
    {
        if (PageNum > 0)
            PageNum--;
        if (PageNum <= 0)
            PageNum = 3;
    }

    public void Right()
    {
        if (PageNum < 3)
            PageNum++;
        else if (PageNum >= 3)
            PageNum = 1;
    }

    public void button1()
    {
        if(PageNum >= 1)
        {
            itemManager.Milk();            
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[0].sprite;
        } 
    }
    public void button2()
    {
        if (PageNum >= 1)
        {
            itemManager.jjokjjok2();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[1].sprite;
        }
    }
    public void button3()
    {
        if (PageNum >= 1)
        {
            itemManager.DDalang2();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[2].sprite;
        }
    }
    public void button4()
    {
        if (PageNum >= 1)
        {
            itemManager.SoccerBall();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[3].sprite;
        }
    }
    public void button5()
    {
        if (PageNum >= 1)
        {
            itemManager.WoodenDoll();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[4].sprite;
        }
    }
    public void button6()
    {
        if (PageNum >= 1)
        {
            itemManager.Candy();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[5].sprite;
        }
    }
    
    public void button7()
    {
        if (PageNum == 1)
        {
            itemManager.Beanie();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[6].sprite;
        }
        if(PageNum == 2)
        {
            itemManager.FishingRod();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[9].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Chur();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[12].sprite;
        }
    }
    public void button8()
    {
        if (PageNum == 1)
        {
            itemManager.Driver();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[7].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.Worm();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[10].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.NailClipper();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[13].sprite;
        }
    }
    public void button9()
    {
        if (PageNum == 1)
        {
            itemManager.Axe();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[8].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.Bandana();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[11].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Hat();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[14].sprite;
        }
    }
    public void button10()
    {
        if (PageNum == 1)
        {
            itemManager.Hammer();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[15].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.GreatFishingRod();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[18].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Apron();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[21].sprite;
        }
    }
    public void button11()
    {
        if (PageNum == 1)
        {
            itemManager.ForestGlove();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[16].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.IceGlove();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[19].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Cosmetic();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[22].sprite;
        }
    }
    public void button12()
    {
        if (PageNum == 1)
        {
            itemManager.GreatAxe();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[17].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.LandingNet();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[20].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Dust();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineItemArr[23].sprite;
        }
    }
    public void button13()
    {
        if (PageNum == 1)
        {
            itemManager.TreeHouse();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[0].sprite;
        }
        if(PageNum == 2)
        {
            itemManager.Igloo();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
    public void button14()
    {
        if (PageNum == 1)
        {
            itemManager.Bed();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[1].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.IceBed();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
    public void button15()
    {
        if (PageNum == 1)
        {
            itemManager.Stove();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[2].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.FishingTool();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
    public void button16()
    {
        if (PageNum == 1)
        {
            itemManager.Table();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[3].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.Aquarium();
            RgbTxt.text = "R :" + itemManager.combine.RequiredR + " G : " + itemManager.combine.RequiredG + " B : " + itemManager.combine.RequiredB;
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
}
