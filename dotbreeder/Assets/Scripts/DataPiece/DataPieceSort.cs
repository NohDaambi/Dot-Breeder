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
    public GameObject[] DataPiece = new GameObject[10]; // ��ư ������Ʈ ����
    public GameObject[] DataPieceObj = new GameObject[10]; //������ ���� ���� Ȱ��ȭ ��Ȱ��ȭ ��ų ��
    public Button[] DataPieceBtn = new Button[10]; // ��ư ����   
    public int[] EmptyArr = new int[10]; // �ϴ� �� �迭

    public int PlayCount;    
    public int GetCount; //������ ���� ȹ�� �� ��
    public int MinusCount; //���ҵǾ�� �� ��

    public bool isGet; //������ ���� ȹ�� ��
    public bool isActive;

    //����Ŭ�� ������    
    public float DblClickSec = 0.25f;
    bool isOneClick = false;
    double Timer = 0;

    public Text InterpretText;

    void Awake()
    {
        //��� ��ư ��Ȱ��ȭ
        for (int i = 0; i < DataPieceBtn.Length; i++)
        {
            DataPieceBtn[i].interactable = false;
        }
    }
    void Update()
    {
        //��ư�ѹ�Ŭ��
        if(isOneClick && ((Time.time - Timer) > DblClickSec))
             isOneClick = false;   
        //��ư�ι�Ŭ��
        DoubleClick();
    }

    //Ȱ��ȭ �� ��ư �� ���� ���� ���������� ���� ���� ��� ����
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
        //������Ʈ ��Ȱ��ȭ
        if (Manager.isAction && isGet)
        {
            DataPieceObj[num].SetActive(false);
            isGet = false;
        }

        if (!Manager.isAction && DataPieceObj[num].activeSelf && !isGet) // �ൿ���̰� �ش� ������������ ������� ��� ī��Ʈ ����
        {            
            if (PlayCount < 10)
                PlayCount++;
            //���� ���� �������������� Ŭ ��� �׳� +1�� �Ҵ�
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

    //��ư ����Ŭ���� �ؼ�ȭ�� �����ֱ�
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

    //�ڷΰ���
    public void BackBtn()
    {
        DataInterpret.SetActive(false);
        DataPieceContents.SetActive(true);
    }

    public void InterpretTextFunc(int num)
    {   
        if (num == 0)
            InterpretText.text = "������ ����1 �ؼ�����";
        else if (num == 1)
            InterpretText.text = "������ ����2 �ؼ�����";
        else if (num == 2)
            InterpretText.text = "������ ����3 �ؼ�����";
        else if (num == 3)
            InterpretText.text = "������ ����4 �ؼ�����";
        else if (num == 4)
            InterpretText.text = "������ ����5 �ؼ�����";
        else if (num == 5)
            InterpretText.text = "������ ����6 �ؼ�����";
        else if (num == 6)
            InterpretText.text = "������ ����7 �ؼ�����";
        else if (num == 7)
            InterpretText.text = "������ ����8 �ؼ�����";
        else if (num == 8)
            InterpretText.text = "������ ����9 �ؼ�����";
        else if (num == 9)
            InterpretText.text = "������ ����10 �ؼ�����";
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
    //�� ��ư �Ҵ�
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

