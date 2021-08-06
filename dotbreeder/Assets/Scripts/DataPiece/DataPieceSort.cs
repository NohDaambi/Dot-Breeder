using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPieceSort : MonoBehaviour
{    
    public PlayerAction Player;
    public GameManager Manager;

    public GameObject TabMenu;
    public GameObject DataSet;
    public GameObject DataPieceContents;
    public GameObject DataInterpret;
    public GameObject[] DataPiece = new GameObject[10]; // 버튼 오브젝트 정렬
    public GameObject[] DataPieceObj = new GameObject[10]; //데이터 조각 정렬 활성화 비활성화 시킬 것
    public Button[] DataPieceBtn = new Button[10]; // 버튼 정렬   
    public int[] EmptyArr = new int[10]; // 일단 빈 배열

    public int PlayCount;    
    public int GetCount; //데이터 조각 획득 한 수
    public int MinusCount; //감소되어야 할 수

    public bool isGet; //데이터 조각 획득 중
    public bool isActive;

    //더블클릭 변수들    
    public float DblClickSec = 0.25f;
    bool isOneClick = false;
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
            }
            ActiveArrSorting(num);
            GetCount++;            
            MinusCount = 0;
        }
    }

    //버튼 더블클릭시 해석화면 보여주기
    public void DoubleClick()
    {
        if (Input.GetMouseButtonDown(0) && TabMenu.activeSelf && DataSet.activeSelf && isActive)
        {            
            if (!isOneClick)
            {
                Timer = Time.time;
                isOneClick = true;               
            }
            else if (isOneClick && (Time.time - Timer) < DblClickSec)
            {
                DataInterpret.SetActive(true);
                DataPieceContents.SetActive(false);
                isOneClick = false;
            }
        }
    }

    public void ClickDelay()
    {
        isActive = false;
    }
    public void BtnHovering()
    {
        isActive = true;
        Invoke("ClickDelay", 1f);
    }

    //뒤로가기
    public void BackBtn()
    {
        DataInterpret.SetActive(false);
        DataPieceContents.SetActive(true);
    }

    public void InterpretTextFunc(int num)
    {   
        if (num == 0)
            InterpretText.text = "데이터 조각1 해석내용";
        else if (num == 1)
            InterpretText.text = "데이터 조각2 해석내용";
        else if (num == 2)
            InterpretText.text = "데이터 조각3 해석내용";
        else if (num == 3)
            InterpretText.text = "데이터 조각4 해석내용";
        else if (num == 4)
            InterpretText.text = "데이터 조각5 해석내용";
        else if (num == 5)
            InterpretText.text = "데이터 조각6 해석내용";
        else if (num == 6)
            InterpretText.text = "데이터 조각7 해석내용";
        else if (num == 7)
            InterpretText.text = "데이터 조각8 해석내용";
        else if (num == 8)
            InterpretText.text = "데이터 조각9 해석내용";
        else if (num == 9)
            InterpretText.text = "데이터 조각10 해석내용";
    }

    public void FindDataPiece()
    {
        if (Player.scanObject.name == "DataPiece1")
            PieceControl(0);
        if (Player.scanObject.name == "DataPiece2")
            PieceControl(1);
        if (Player.scanObject.name == "DataPiece3")
            PieceControl(2);
        if (Player.scanObject.name == "DataPiece4")
            PieceControl(3);
        if (Player.scanObject.name == "DataPiece5")
            PieceControl(4);
        if (Player.scanObject.name == "DataPiece6")
            PieceControl(5);
        if (Player.scanObject.name == "DataPiece7")
            PieceControl(6);
        if (Player.scanObject.name == "DataPiece8")
            PieceControl(7);
        if (Player.scanObject.name == "DataPiece9")
            PieceControl(8);
        if (Player.scanObject.name == "DataPiece10")
            PieceControl(9);
    }
    //각 버튼 할당
    public void DataBtn0()
    {        
        InterpretTextFunc(0);
        DoubleClick();
    }
    public void DataBtn1()
    {
        InterpretTextFunc(1);
        DoubleClick();
    }
    public void DataBtn2()
    {
        InterpretTextFunc(2);
        DoubleClick();
    }
    public void DataBtn3()
    {
        InterpretTextFunc(3);
        DoubleClick();
    }
    public void DataBtn4()
    {
        InterpretTextFunc(4);
        DoubleClick();
    }
    public void DataBtn5()
    {
        InterpretTextFunc(5);
        DoubleClick();
    }
    public void DataBtn6()
    {
        InterpretTextFunc(6);
        DoubleClick();
    }
    public void DataBtn7()
    {
        InterpretTextFunc(7);
        DoubleClick();
    }
    public void DataBtn8()
    {
        InterpretTextFunc(8);
        DoubleClick();
    }
    public void DataBtn9()
    {
        InterpretTextFunc(9);
        DoubleClick();
    }
}

