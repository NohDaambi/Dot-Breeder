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

    //조합기 UI
    public Text Title;
    public Text time;
    public Image image;
    public Text Content;
    public Text R;
    public Text G;
    public Text B;
    public Text ProduceNum;
    public Image[] ShowItemArr = new Image[6];
    public Image[] CombineItemArr = new Image[24]; // 0~2 step1 3~5 step2 6~14 step3(678 문식 91011 팽귄 121314 여우 15~23 step4(151617 문식 181920 팽귄 212223 여우) 
    public Image[] CombineBuildingArr = new Image[12]; // 0~3 shack 4~7 Igloo 8~11 Desert 

    //조합중 UI
    public Text TitleIng;
    public Text timeIng;
    public Image imageIng;

    //조합 끝
    public Image imageEnd;

    //조합 시간
    public float GetHouseTime;
    public float GetBedTime;
    public float GetStoveTime;
    public float GetTableTime;

    //필요한 재료
    public int RequiredR;
    public int RequiredG;
    public int RequiredB;

    //생산 가능한 수
    public int produceNum;

    //최대 생산 가능 수 (기본값 : 1)
    public int maxR = 1;
    public int maxG = 1;
    public int maxB = 1;

    //조합기 아이템 목록 버튼
    public Button[] UnlockButton = new Button[6];
    public Text[] UnlockBtnText = new Text[6];        

    //잠금 버튼
    public Button[] LockButton = new Button[6];
    public Text[] LockBtnText = new Text[6];

    //조합중인가?, 조합이 끝나거나 취소할 때 false, 조합버튼 누를때 true
    public bool isCombining;

    //조합기 페이지
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
            //조합중일때 다른 버튼 클릭 제한
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

        //아이템 페이지
        //1페이지
        if (pageNumItem == 1 && ItemPage && Manager.stageNum >= 1)
        {
            UnlockBtnText[0].text = "분유";
            UnlockBtnText[1].text = "쪽쪽이";
            UnlockBtnText[2].text = "딸랑이";
            UnlockBtnText[3].text = "축구공";
            UnlockBtnText[4].text = "목각인형";
            UnlockBtnText[5].text = "사탕";            
        }
        //2페이지
        if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
        {
            UnlockBtnText[0].text = "비니";
            UnlockBtnText[1].text = "송곳";
            UnlockBtnText[2].text = "도끼";
            UnlockBtnText[3].text = "망치";
            UnlockBtnText[4].text = "장갑";
            UnlockBtnText[5].text = "좋은도끼";            
        }
        if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
        {
            UnlockBtnText[0].text = "낚싯대";
            UnlockBtnText[1].text = "지렁이";
            UnlockBtnText[2].text = "두건";
            UnlockBtnText[3].text = "좋은 낚싯대";
            UnlockBtnText[4].text = "장갑";
            UnlockBtnText[5].text = "뜰채";
        }
        if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
        {
            UnlockBtnText[0].text = "츄르";
            UnlockBtnText[1].text = "손톱깎이";
            UnlockBtnText[2].text = "모자";
            UnlockBtnText[3].text = "앞치마";
            UnlockBtnText[4].text = "화장품";
            UnlockBtnText[5].text = "먼지털이";
        }

        //건축물 페이지
        //1페이지
        if (pageNumBuilding == 1 && BuildingPage && Manager.stageNum == 1)
        {
            UnlockBtnText[0].text = "통나무집";
            UnlockBtnText[1].text = "라탄 요람침대";
            UnlockBtnText[2].text = "벽난로";
            UnlockBtnText[3].text = "테이블 톱";
            UnlockBtnText[4].text = "????";
            UnlockBtnText[5].text = "????";
        }
        if (pageNumBuilding == 1 && BuildingPage && Manager.stageNum == 2)
        {
            UnlockBtnText[0].text = "이글루";
            UnlockBtnText[1].text = "썰매침대";
            UnlockBtnText[2].text = "낚시용품 진열대";
            UnlockBtnText[3].text = "수족관(어항)";
            UnlockBtnText[4].text = "????";
            UnlockBtnText[5].text = "????";
        }
        if (pageNumBuilding == 1 && BuildingPage && Manager.stageNum == 3)
        {
            UnlockBtnText[0].text = "천막";
            UnlockBtnText[1].text = "해먹 침대";
            UnlockBtnText[2].text = "접시, 그릇";
            UnlockBtnText[3].text = "진흙화로, 물병";
            UnlockBtnText[4].text = "????";
            UnlockBtnText[5].text = "????";
        }

        //아이템
        if (ItemPage)
        {
            //레벨 별로 이미지 흑백
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

            //1레벨,2레벨 공통 아이템
            if (Manager.stageNum >= 1 && pageNumItem == 1)
            {
                for (int i = 0; i < ShowItemArr.Length; i++)
                {
                    ShowItemArr[i].sprite = CombineItemArr[i].sprite;
                }
            }
            //3레벨 문식이
            if (Manager.stageNum == 1 && pageNumItem == 2)
            {
                ItemStageSpriteFunc(6);
            }
            //펭귄
            else if (Manager.stageNum == 2 && pageNumItem == 2)
            {
                ItemStageSpriteFunc(9);
            }
            //여우
            else if (Manager.stageNum == 3 && pageNumItem == 2)
            {
                ItemStageSpriteFunc(12);
            }
        }
        //건물
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
            //스테이지 별 스프라이트
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

    //버튼 클릭 시
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
        //숲
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.Milk();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.Beanie();

        //얼음
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.Milk();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.FishingRod();

        //사막
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
        //숲
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.jjokjjok2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.Driver();

        //얼음
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.jjokjjok2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.Worm();

        //사막
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
        //숲
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 1)
            itemManager.DDalang2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 1)
            itemManager.Axe();

        //얼음
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.DDalang2();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.Bandana();

        //사막
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

        //얼음
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.SoccerBall();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.GreatFishingRod();

        //사막
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

        //얼음
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.WoodenDoll();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.IceGlove();

        //사막
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

        //얼음
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 2)
            itemManager.Candy();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 2)
            itemManager.LandingNet();

        //사막
        if (pageNumItem == 1 && ItemPage && Manager.stageNum == 3)
            itemManager.Candy();
        else if (pageNumItem == 2 && ItemPage && Manager.stageNum == 3)
            itemManager.Dust();
    }

    //제작 버튼
    public void ProduceButton()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            Manager.Rcount -= RequiredR * produceNum;
            Manager.Gcount -= RequiredG * produceNum;
            Manager.Bcount -= RequiredB * produceNum;

            //바뀌고 할당해줘야 텍스트UI 중복 출력 방지
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
    //시간 줄이기
    public void TimeReduce()
    {
        //1버튼 1초 감소
        if (timer.combineTIme > 0)
        { 
            timer.combineTIme--;
            timer.transTime++;
        }
    }
    //조합 취소
    public void CombineCancel()
    {
        Combining.SetActive(false);
        CombineChild.SetActive(true);
        Manager.Rcount += RequiredR * produceNum;
        Manager.Gcount += RequiredG * produceNum;
        Manager.Bcount += RequiredB * produceNum;

        //바뀌고 할당해줘야 텍스트UI 중복 출력 방지
        Manager.PrevGcount = Manager.Gcount;
        Manager.PrevRcount = Manager.Rcount;
        Manager.PrevBcount = Manager.Bcount;

        isCombining = false;

        //초기화
        timer.combineTIme += timer.transTime;
        isCombining = false;
        timer.currentTime = 0;
        timer.transTime = 0;
        timer.isPlus = false;
    }
    //아이템 넘기기
    public void GiveItem()
    {
        Combining.SetActive(false);
        CombineEnd.SetActive(false);
        CombineUI.SetActive(false);

        Manager.isAction = false;

        //도트한테 해당 아이템 할당하기, 이름불러와서 그 값 할당
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

    //최대로 조합하기
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
    //최대에서 반 조합하기
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
    //페이지 왼쪽 버튼
    public void LeftBtn()
    {
        if(pageNumItem > 1 && ItemPage)
            pageNumItem--;
        
        if(pageNumBuilding > 1 && BuildingPage)
            pageNumBuilding--;
    }
    //페이지 오른쪽 버튼
    public void RightBtn()
    {
        if(pageNumItem < pageMax && ItemPage)
            pageNumItem++;

        if (pageNumBuilding < pageMax && BuildingPage)
            pageNumBuilding++;
    }
    //아이템 조합 창
    public void ItemBtn()
    {
        CombineAnim.SetBool ("isButton", false);
        ItemPage = true;
        BuildingPage = false;
        CombineChild.SetActive(false);
        ChangeItem.SetTrigger("isItem");     
    }
    //건물 조합 창
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
