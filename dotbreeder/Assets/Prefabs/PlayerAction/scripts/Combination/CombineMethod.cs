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
    public Text[] RgbTxt = new Text[3];
    public Text ItemName;

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
            textArr[0].text = "����";
            textArr[1].text = "������";
            textArr[2].text = "������";
            textArr[3].text = "�౸��";
            textArr[4].text = "������";
            textArr[5].text = "����";
            textArr[6].text = "���";
            textArr[7].text = "�۰�";
            textArr[8].text = "����";
            textArr[9].text = "��ġ";
            textArr[10].text = "�尩";
            textArr[11].text = "��������";
            textArr[12].text = "�볪����";
            textArr[13].text = "��ź ���ħ��";
            textArr[14].text = "������";
            textArr[15].text = "���̺� ��";
        }

        if(PageNum == 2)
        {
            stageImage.sprite = stageimgarr[1].sprite;
            textArr[0].text = "����";
            textArr[1].text = "������";
            textArr[2].text = "������";
            textArr[3].text = "�౸��";
            textArr[4].text = "������";
            textArr[5].text = "����";
            textArr[6].text = "���˴�";
            textArr[7].text = "������";
            textArr[8].text = "�ΰ�";
            textArr[9].text = "���� ���˴�";
            textArr[10].text = "�尩";
            textArr[11].text = "��ä";
            textArr[12].text = "�̱۷�";
            textArr[13].text = "����ħ��";
            textArr[14].text = "���ÿ�ǰ ������";
            textArr[15].text = "������(����)";
        }

        if(PageNum == 3)
        {
            stageImage.sprite = stageimgarr[2].sprite;
            textArr[0].text = "����";
            textArr[1].text = "������";
            textArr[2].text = "������";
            textArr[3].text = "�౸��";
            textArr[4].text = "������";
            textArr[5].text = "����";
            textArr[6].text = "��";
            textArr[7].text = "�������";
            textArr[8].text = "����";
            textArr[9].text = "��ġ��";
            textArr[10].text = "ȭ��ǰ";
            textArr[11].text = "��������";
            textArr[12].text = "õ��";
            textArr[13].text = "�ظ� ħ��";
            textArr[14].text = "���� �׸�";
            textArr[15].text = "����ȭ��, ����";
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

    public void TextTransition(int num)
    {
        RgbTxt[0].text = "R �ȼ����� " + itemManager.combine.RequiredR;
        RgbTxt[1].text = "G �ȼ����� " + itemManager.combine.RequiredG;
        RgbTxt[2].text = "B �ȼ����� " + itemManager.combine.RequiredB;        
        ItemName.text = textArr[num].text;
    }

    public void button1()
    {
        if(PageNum >= 1)
        {
            itemManager.Milk();
            TextTransition(0);
            MethodImage.sprite = itemManager.combine.CombineItemArr[0].sprite;
        } 
    }
    public void button2()
    {
        if (PageNum >= 1)
        {
            itemManager.jjokjjok2();
            TextTransition(1);
            MethodImage.sprite = itemManager.combine.CombineItemArr[1].sprite;
        }
    }
    public void button3()
    {
        if (PageNum >= 1)
        {
            itemManager.DDalang2();
            TextTransition(2);
            MethodImage.sprite = itemManager.combine.CombineItemArr[2].sprite;
        }
    }
    public void button4()
    {
        if (PageNum >= 1)
        {
            itemManager.SoccerBall();
            TextTransition(3);
            MethodImage.sprite = itemManager.combine.CombineItemArr[3].sprite;
        }
    }
    public void button5()
    {
        if (PageNum >= 1)
        {
            itemManager.WoodenDoll();
            TextTransition(4);
            MethodImage.sprite = itemManager.combine.CombineItemArr[4].sprite;
        }
    }
    public void button6()
    {
        if (PageNum >= 1)
        {
            itemManager.Candy();
            TextTransition(5);
            MethodImage.sprite = itemManager.combine.CombineItemArr[5].sprite;
        }
    }
    
    public void button7()
    {
        if (PageNum == 1)
        {
            itemManager.Beanie();
            TextTransition(6);
            MethodImage.sprite = itemManager.combine.CombineItemArr[6].sprite;
        }
        if(PageNum == 2)
        {
            itemManager.FishingRod();
            TextTransition(6);
            MethodImage.sprite = itemManager.combine.CombineItemArr[9].sprite;          
        }
        if (PageNum == 3)
        {
            itemManager.Chur();
            TextTransition(6);
            MethodImage.sprite = itemManager.combine.CombineItemArr[12].sprite;       
        }
    }
    public void button8()
    {
        if (PageNum == 1)
        {
            itemManager.Driver();
            TextTransition(7);
            MethodImage.sprite = itemManager.combine.CombineItemArr[7].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.Worm();
            TextTransition(7);
            MethodImage.sprite = itemManager.combine.CombineItemArr[10].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.NailClipper();
            TextTransition(7);
            MethodImage.sprite = itemManager.combine.CombineItemArr[13].sprite;  
        }
    }
    public void button9()
    {
        if (PageNum == 1)
        {
            itemManager.Axe();
            TextTransition(8);
            MethodImage.sprite = itemManager.combine.CombineItemArr[8].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.Bandana();
            TextTransition(8);
            MethodImage.sprite = itemManager.combine.CombineItemArr[11].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Hat();
            TextTransition(8);
            MethodImage.sprite = itemManager.combine.CombineItemArr[14].sprite;
        }
    }
    public void button10()
    {
        if (PageNum == 1)
        {
            itemManager.Hammer();
            TextTransition(9);
            MethodImage.sprite = itemManager.combine.CombineItemArr[15].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.GreatFishingRod();
            TextTransition(9);
            MethodImage.sprite = itemManager.combine.CombineItemArr[18].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Apron();
            TextTransition(9);
            MethodImage.sprite = itemManager.combine.CombineItemArr[21].sprite;
        }
    }
    public void button11()
    {
        if (PageNum == 1)
        {
            itemManager.ForestGlove();
            TextTransition(10);
            MethodImage.sprite = itemManager.combine.CombineItemArr[16].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.IceGlove();
            TextTransition(10);
            MethodImage.sprite = itemManager.combine.CombineItemArr[19].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Cosmetic();
            TextTransition(10);
            MethodImage.sprite = itemManager.combine.CombineItemArr[22].sprite;
        }
    }
    public void button12()
    {
        if (PageNum == 1)
        {
            itemManager.GreatAxe();
            TextTransition(11);
            MethodImage.sprite = itemManager.combine.CombineItemArr[17].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.LandingNet();
            TextTransition(11);
            MethodImage.sprite = itemManager.combine.CombineItemArr[20].sprite;
        }
        if (PageNum == 3)
        {
            itemManager.Dust();
            TextTransition(11);
            MethodImage.sprite = itemManager.combine.CombineItemArr[23].sprite;
        }
    }
    public void button13()
    {
        if (PageNum == 1)
        {
            itemManager.TreeHouse();
            TextTransition(12);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[0].sprite;
        }
        if(PageNum == 2)
        {
            itemManager.Igloo();
            TextTransition(12);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
    public void button14()
    {
        if (PageNum == 1)
        {
            itemManager.Bed();
            TextTransition(13);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[1].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.IceBed();
            TextTransition(13);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
    public void button15()
    {
        if (PageNum == 1)
        {
            itemManager.Stove();
            TextTransition(14);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[2].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.FishingTool();
            TextTransition(14);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
    public void button16()
    {
        if (PageNum == 1)
        {
            itemManager.Table();
            TextTransition(15);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[3].sprite;
        }
        if (PageNum == 2)
        {
            itemManager.Aquarium();
            TextTransition(15);
            MethodImage.sprite = itemManager.combine.CombineBuildingArr[4].sprite;
        }
    }
}
