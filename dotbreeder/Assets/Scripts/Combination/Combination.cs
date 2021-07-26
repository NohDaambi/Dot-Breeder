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


    //조합중인가?, 조합이 끝나거나 취소할 때 false, 조합버튼 누를때 true
    public bool isCombining;

    public int DotItem;

    private static bool combineExist;

    public void Awake()
    {

        // 씬 이동 간 중복 방지        
        if (!combineExist)
        {
            combineExist = true;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            CombineChild.SetActive(false);
            Combining.SetActive(false);
            Manager.isAction = false;
        }
    }

    public void Button1()
    {
        CombineAnim.SetTrigger("isButton");
        if(!isCombining)
            CombineChild.SetActive(true);
        else if(isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        TreeHouse();
    }
    public void Button2()
    {
        CombineAnim.SetTrigger("isButton");
        if (!isCombining)
            CombineChild.SetActive(true);
        else if (isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        Bed();
    }
    public void Button3()
    {
        CombineAnim.SetTrigger("isButton");
        if (!isCombining)
            CombineChild.SetActive(true);
        else if (isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        Stove();
    }
    public void Button4()
    {
        CombineAnim.SetTrigger("isButton");
        if (!isCombining)
            CombineChild.SetActive(true);
        else if (isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        Table();
    }
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
            Debug.Log("재료가 부족합니다!");
        }

        //제작하는 함수(시간,증가)

    }
    public void TimeReduce()
    {
        //1버튼 1초 감소
        if (timer.combineTIme > 0)
        { 
            timer.combineTIme--;
            timer.transTime++;
        }
    }
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
    public void GiveItem()
    {
        Combining.SetActive(false);
        CombineEnd.SetActive(false);
        CombineUI.SetActive(false);

        Manager.isAction = false;

        //도트한테 해당 아이템 할당하기, 이름불러와서 그 값 할당
        DotItem += produceNum;
    }
    public void Max()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            maxR = Manager.Rcount / RequiredR;
            maxG = Manager.Gcount / RequiredG;
            maxB = Manager.Bcount / RequiredB;

            if (maxR == maxG && maxR == maxB && maxG == maxB)
            {
                produceNum = maxR;
                ProduceNum.text = produceNum.ToString();
            }
     
        }
    }
    public void Half()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            maxR = Manager.Rcount / RequiredR;
            maxG = Manager.Gcount / RequiredG;
            maxB = Manager.Bcount / RequiredB;

            if (maxR == maxG && maxR == maxB && maxG == maxB)
            {
                produceNum = maxR / 2;
                ProduceNum.text = produceNum.ToString();
            }

        }
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
}
