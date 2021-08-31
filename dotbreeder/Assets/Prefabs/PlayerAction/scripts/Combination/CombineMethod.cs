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

    public int PageNum; //1 숲 2 얼음 3 사막
    

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
            textArr[0].text = "분유 조합법";
            textArr[1].text = "쪽쪽이 조합법";
            textArr[2].text = "딸랑이 조합법";
            textArr[3].text = "축구공 조합법";
            textArr[4].text = "목각인형 조합법";
            textArr[5].text = "사탕 조합법";
            textArr[6].text = "비니 조합법";
            textArr[7].text = "송곳 조합법";
            textArr[8].text = "도끼 조합법";
            textArr[9].text = "망치 조합법";
            textArr[10].text = "장갑 조합법";
            textArr[11].text = "좋은도끼 조합법";
            textArr[12].text = "통나무집 조합법";
            textArr[13].text = "라탄 요람침대 조합법";
            textArr[14].text = "벽난로 조합법";
            textArr[15].text = "테이블 톱 조합법";
        }

        if(PageNum == 2)
        {
            stageImage.sprite = stageimgarr[1].sprite;
            textArr[0].text = "분유 조합법";
            textArr[1].text = "쪽쪽이 조합법";
            textArr[2].text = "딸랑이 조합법";
            textArr[3].text = "축구공 조합법";
            textArr[4].text = "목각인형 조합법";
            textArr[5].text = "사탕 조합법";
            textArr[6].text = "낚싯대 조합법";
            textArr[7].text = "지렁이 조합법";
            textArr[8].text = "두건 조합법";
            textArr[9].text = "좋은 낚싯대 조합법";
            textArr[10].text = "장갑 조합법";
            textArr[11].text = "뜰채 조합법";
            textArr[12].text = "이글루 조합법";
            textArr[13].text = "얼음침대 조합법";
            textArr[14].text = "낚시용품 진열대 조합법";
            textArr[15].text = "수족관(어항) 조합법";
        }

        if(PageNum == 3)
        {
            stageImage.sprite = stageimgarr[2].sprite;
            textArr[0].text = "분유 조합법";
            textArr[1].text = "쪽쪽이 조합법";
            textArr[2].text = "딸랑이 조합법";
            textArr[3].text = "축구공 조합법";
            textArr[4].text = "목각인형 조합법";
            textArr[5].text = "사탕 조합법";
            textArr[6].text = "츄르 조합법";
            textArr[7].text = "손톱깎이 조합법";
            textArr[8].text = "모자 조합법";
            textArr[9].text = "앞치마 조합법";
            textArr[10].text = "화장품 조합법";
            textArr[11].text = "먼지털이 조합법";
            textArr[12].text = "천막 조합법";
            textArr[13].text = "해먹 침대 조합법";
            textArr[14].text = "접시 그릇 조합법";
            textArr[15].text = "진흙화로, 물병 조합법";
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
