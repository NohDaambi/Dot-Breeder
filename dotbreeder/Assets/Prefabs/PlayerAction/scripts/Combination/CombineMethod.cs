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

    public int PageNum; //1 ½£ 2 ¾óÀ½ 3 »ç¸·
    

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
            textArr[0].text = "ºÐÀ¯";
            textArr[1].text = "ÂÊÂÊÀÌ";
            textArr[2].text = "µþ¶ûÀÌ";
            textArr[3].text = "Ãà±¸°ø";
            textArr[4].text = "¸ñ°¢ÀÎÇü";
            textArr[5].text = "»çÅÁ";
            textArr[6].text = "ºñ´Ï";
            textArr[7].text = "¼Û°÷";
            textArr[8].text = "µµ³¢";
            textArr[9].text = "¸ÁÄ¡";
            textArr[10].text = "Àå°©";
            textArr[11].text = "ÁÁÀºµµ³¢";
            textArr[12].text = "Åë³ª¹«Áý";
            textArr[13].text = "¶óÅº ¿ä¶÷Ä§´ë";
            textArr[14].text = "º®³­·Î";
            textArr[15].text = "Å×ÀÌºí Åé";
        }

        if(PageNum == 2)
        {
            stageImage.sprite = stageimgarr[1].sprite;
            textArr[0].text = "ºÐÀ¯";
            textArr[1].text = "ÂÊÂÊÀÌ";
            textArr[2].text = "µþ¶ûÀÌ";
            textArr[3].text = "Ãà±¸°ø";
            textArr[4].text = "¸ñ°¢ÀÎÇü";
            textArr[5].text = "»çÅÁ";
            textArr[6].text = "³¬½Ë´ë";
            textArr[7].text = "Áö··ÀÌ";
            textArr[8].text = "µÎ°Ç";
            textArr[9].text = "ÁÁÀº ³¬½Ë´ë";
            textArr[10].text = "Àå°©";
            textArr[11].text = "¶ãÃ¤";
            textArr[12].text = "ÀÌ±Û·ç";
            textArr[13].text = "¾óÀ½Ä§´ë";
            textArr[14].text = "³¬½Ã¿ëÇ° Áø¿­´ë";
            textArr[15].text = "¼öÁ·°ü(¾îÇ×)";
        }

        if(PageNum == 3)
        {
            stageImage.sprite = stageimgarr[2].sprite;
            textArr[0].text = "ºÐÀ¯";
            textArr[1].text = "ÂÊÂÊÀÌ";
            textArr[2].text = "µþ¶ûÀÌ";
            textArr[3].text = "Ãà±¸°ø";
            textArr[4].text = "¸ñ°¢ÀÎÇü";
            textArr[5].text = "»çÅÁ";
            textArr[6].text = "Ãò¸£";
            textArr[7].text = "¼ÕÅé±ðÀÌ";
            textArr[8].text = "¸ðÀÚ";
            textArr[9].text = "¾ÕÄ¡¸¶";
            textArr[10].text = "È­ÀåÇ°";
            textArr[11].text = "¸ÕÁöÅÐÀÌ";
            textArr[12].text = "Ãµ¸·";
            textArr[13].text = "ÇØ¸Ô Ä§´ë";
            textArr[14].text = "Á¢½Ã ±×¸©";
            textArr[15].text = "ÁøÈëÈ­·Î, ¹°º´";
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
        RgbTxt[0].text = "R ÇÈ¼¿Á¶°¢ " + itemManager.combine.RequiredR;
        RgbTxt[1].text = "G ÇÈ¼¿Á¶°¢ " + itemManager.combine.RequiredG;
        RgbTxt[2].text = "B ÇÈ¼¿Á¶°¢ " + itemManager.combine.RequiredB;        
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
