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

    //조합기 UI
    public Text Title;
    public Text time;
    public Image image;
    public Text Content;
    public Text R;
    public Text G;
    public Text B;
    public Text ProduceNum;

    //조합중 UI
    public Text TitleIng;
    public Text timeIng;
    public Image imageIng;

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
    public int pageNum = 1;
    public int pageMax;

    public int DotItem;

    private static bool combineExist;
        
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            CombineChild.SetActive(false);
            //Combining.SetActive(false);
            Manager.isAction = false;
        }

        if(isCombining)
        {
            //ineractable로 해금 시스템도 만들기
            //이거는 조합중일때 다른 버튼 클릭 제한
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
                
        pageText.text = pageNum.ToString()+ " / " + pageMax.ToString();

        //1페이지
        if(pageNum == 1)
        {
            UnlockBtnText[0].text = "1레벨 통나무집";
            UnlockBtnText[1].text = "1레벨 요람침대";
            UnlockBtnText[2].text = "1레벨 벽난로";
            UnlockBtnText[3].text = "2레벨 테이블 톱";
            UnlockBtnText[4].text = "2레벨 아이템";
            UnlockBtnText[5].text = "2레벨 아이템";            
        }
        //2페이지
        if(pageNum == 2)
        {
            UnlockBtnText[0].text = "3레벨 사탕";
            UnlockBtnText[1].text = "3레벨 아이템";
            UnlockBtnText[2].text = "3레벨 아이템";
            UnlockBtnText[3].text = "4레벨 아이템";
            UnlockBtnText[4].text = "4레벨 아이템";
            UnlockBtnText[5].text = "4레벨 아이템";            
        }
        //3페이지~~
        if (pageNum == 3)
        {
            UnlockBtnText[0].text = "1레벨 건축물";
            UnlockBtnText[1].text = "2레벨 건축물";
            UnlockBtnText[2].text = "3레벨 건축물";
            UnlockBtnText[3].text = "4레벨 건축물";
            UnlockBtnText[4].text = " ";
            UnlockBtnText[5].text = " ";            
        }


    }
    //버튼 클릭 시
    public void BtnClick()
    {
        CombineAnim.SetTrigger("isButton");
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
        //숫자하나 할당해서 1페이지일경우 뭐 건축물, 2페이지 아이템 3페이지 아이템2 등등 넘기기?
        if (pageNum == 1)
            TreeHouse();
        else if (pageNum == 2)
            Candy();
    }
    public void Button2()
    {
        BtnClick();
        if (pageNum == 1)
            Bed();
        //else if (pageNum == 2)
    }
    public void Button3()
    {
        BtnClick();
        if (pageNum == 1)
            Stove();
        //else if (pageNum == 2)
    }
    public void Button4()
    {
        BtnClick();
        if (pageNum == 1)
            Table();
        //else if (pageNum == 2) 
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
        if(pageNum > 1)
            pageNum--;
    }
    //페이지 오른쪽 버튼
    public void RightBtn()
    {
        if(pageNum < pageMax)
            pageNum++;
    }


    //이 아래부터는 나중에 엑셀로 정리, 예시로 잡아둠
    public void TreeHouse()
    {
        RequiredR = 1;
        RequiredG = 2;
        RequiredB = 1;
        GetHouseTime = 20;
        timer.combineTIme = GetHouseTime;

        //조합기 텍스트        
        Title.text = "통나무집";
        time.text = "제작 시간 : " + GetHouseTime.ToString();
        //image.sprite = 스프라이트 가져와서 각 할당
        Content.text = "통나무집이랍니다! 벌레가 나올지도,,";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;

        //조합중 텍스트
        TitleIng.text = "통나무집";
        timeIng.text = "제작 시간 : " + GetHouseTime.ToString();
        //imageIng.sprtie = ~~
       

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
    public void Bed()
    {
        RequiredR = 2;
        RequiredG = 2;
        RequiredB = 1;
        GetBedTime = 40;
        timer.combineTIme = GetBedTime;
                
        Title.text = "라탄 요람침대";
        time.text = "제작 시간 : " + GetBedTime.ToString();
        //image.sprite = 스프라이트 가져와서 각 할당
        Content.text = "라탄 요람침대입니다! 아주 편안하지용";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;

        //조합중 텍스트
        TitleIng.text = "라탄 요람침대";
        timeIng.text = "제작 시간 : " + GetBedTime.ToString();
        //imageIng.sprtie = ~~
        

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
    public void Stove()
    {
        RequiredR = 2;
        RequiredG = 2;
        RequiredB = 2;
        GetStoveTime = 50;
        timer.combineTIme = GetStoveTime;
                
        Title.text = "벽난로";
        time.text = "제작 시간 : " + GetStoveTime.ToString();
        //image.sprite = 스프라이트 가져와서 각 할당
        Content.text = "벽난로입니다! 따뜻해용";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;
               
        //조합중 텍스트
        TitleIng.text = "벽난로";
        timeIng.text = "제작 시간 : " + GetStoveTime.ToString();
        //imageIng.sprtie = ~~
      

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
    public void Table()
    {
        RequiredR = 3;
        RequiredG = 2;
        RequiredB = 3;
        GetTableTime = 70;
        timer.combineTIme = GetTableTime;
                
        Title.text = "테이블 톱";
        time.text = "제작 시간 : " + GetTableTime.ToString();
        //image.sprite = 스프라이트 가져와서 각 할당
        Content.text = "테이블 톱입니다! 어서 일하세요.";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;
        
        //조합중 텍스트
        TitleIng.text = "테이블 톱";
        timeIng.text = "제작 시간 : " + GetTableTime.ToString();
        //imageIng.sprtie = ~~
      
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
    public void Candy()
    {
        RequiredR = 1;
        RequiredG = 1;
        RequiredB = 1;
        GetHouseTime = 10;
        timer.combineTIme = GetHouseTime;

        //조합기 텍스트        
        Title.text = "사탕";
        time.text = "제작 시간 : " + GetHouseTime.ToString();
        //image.sprite = 스프라이트 가져와서 각 할당
        Content.text = "달달한 사탕! 이빨 썩어,,";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;

        //조합중 텍스트
        TitleIng.text = "사탕";
        timeIng.text = "제작 시간 : " + GetHouseTime.ToString();
        //imageIng.sprtie = ~~


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
