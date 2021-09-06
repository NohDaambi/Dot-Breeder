using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPieceSort : MonoBehaviour
{    
    public GameManager Manager;

    public GameObject TabMenu;
    public GameObject DataSet;
    public GameObject DataPieceContents;
    public GameObject DataInterpret;
    public GameObject[] DataPiece = new GameObject[ArrSize]; // 버튼 오브젝트 정렬
    public GameObject[] DataPieceObj = new GameObject[ArrSize]; //데이터 조각 정렬 활성화 비활성화 시킬 것
    public Image[] DataActiveImgArr = new Image[ArrSize]; // 활성화 데이터 조각 이미지
    public Button[] DataPieceBtn = new Button[ArrSize]; // 버튼 정렬   
    public int[] EmptyArr = new int[ArrSize]; // 일단 빈 배열

    public Image DataActiveImg;

    static int ArrSize = 10;
    public int PlayCount;    
    public int GetCount; //데이터 조각 획득 한 수
    public int MinusCount; //감소되어야 할 수

    public bool isGet; //데이터 조각 획득 중  
    public bool isBtnClick; //버튼 클릭

    //더블클릭 변수들    
    public float DblClickSec = 0.25f;
    bool isOneClick;
    double Timer = 0;

    public Text InterpretText;

    void Awake()
    {
        //모든 버튼 비활성화
        for (int i = 0; i < DataPieceBtn.Length; i++)
        {
            DataPieceBtn[i].interactable = false;            
        }
    }
    void Update()
    {
        //버튼한번클릭
        if(isOneClick && ((Time.time - Timer) > DblClickSec))
             isOneClick = false;   
        //버튼두번클릭
        DoubleClick();

        if (!TabMenu.activeSelf)
            isBtnClick = false;
    }

    //활성화 된 버튼 중 전에 먹은 데이터조각 보다 작을 경우 정렬
    public void ActiveArrSorting(int num)
    {                         
        EmptyArr[GetCount] = num;   

        if (GetCount > 0)
        {
            for (int k = 0; k < GetCount; k++)
            {
                if (EmptyArr[k] > EmptyArr[GetCount])
                {
                    MinusCount++;
                    DataPiece[EmptyArr[GetCount]].transform.SetSiblingIndex(GetCount-MinusCount);
                }
            }
        }
    }
   
    public void PieceControl(int num)
    {
        //오브젝트 비활성화
        if (Manager.isAction && isGet)
        {
            DataPieceObj[num].SetActive(false);
            isGet = false;
        }

        if (!Manager.isAction && DataPieceObj[num].activeSelf && !isGet) // 행동중이고 해당 데이터조각이 살아있을 경우 카운트 시작
        {            
            if (PlayCount < 10)
                PlayCount++;
            //전에 먹은 데이터조각보다 클 경우 그냥 +1에 할당
            for (int i = 0; i < PlayCount; i++)
            {
               DataPiece[num].transform.SetSiblingIndex(i);
               DataPieceBtn[num].interactable = true;
               DataActiveImgArr[num].sprite = DataActiveImg.sprite;
            }
            ActiveArrSorting(num);
            GetCount++;            
            MinusCount = 0;
        }
    }

    //버튼 더블클릭시 해석화면 보여주기
    public void DoubleClick()
    {
        if (Input.GetMouseButtonDown(0) && TabMenu.activeSelf && DataSet.activeSelf)
        {            
            if (!isOneClick)
            {
                Timer = Time.time;
                isOneClick = true;               
            }
            else if (isOneClick && (Time.time - Timer) < DblClickSec && isBtnClick)
            {
                DataInterpret.SetActive(true);
                DataPieceContents.SetActive(false);
                isOneClick = false;
            }
        }
    }

    public void BtnHoveringExit()
    {       
        isBtnClick = false;
    }

    public void BtnClick()
    {
        isBtnClick = true;
    }
    //뒤로가기
    public void BackBtn()
    {
        isBtnClick = false;
        DataInterpret.SetActive(false);
        DataPieceContents.SetActive(true);
    }
}

