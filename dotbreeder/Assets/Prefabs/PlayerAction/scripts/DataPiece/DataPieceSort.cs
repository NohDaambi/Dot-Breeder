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
    public GameObject[] DataPiece = new GameObject[ArrSize]; // ��ư ������Ʈ ����
    public GameObject[] DataPieceObj = new GameObject[ArrSize]; //������ ���� ���� Ȱ��ȭ ��Ȱ��ȭ ��ų ��
    public Image[] DataActiveImgArr = new Image[ArrSize]; // Ȱ��ȭ ������ ���� �̹���
    public Button[] DataPieceBtn = new Button[ArrSize]; // ��ư ����   
    public int[] EmptyArr = new int[ArrSize]; // �ϴ� �� �迭

    public Image DataActiveImg;

    static int ArrSize = 10;
    public int PlayCount;    
    public int GetCount; //������ ���� ȹ�� �� ��
    public int MinusCount; //���ҵǾ�� �� ��

    public bool isGet; //������ ���� ȹ�� ��  
    public bool isBtnClick; //��ư Ŭ��

    //����Ŭ�� ������    
    public float DblClickSec = 0.25f;
    bool isOneClick;
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

        if (!TabMenu.activeSelf)
            isBtnClick = false;
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
               DataActiveImgArr[num].sprite = DataActiveImg.sprite;
            }
            ActiveArrSorting(num);
            GetCount++;            
            MinusCount = 0;
        }
    }

    //��ư ����Ŭ���� �ؼ�ȭ�� �����ֱ�
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
    //�ڷΰ���
    public void BackBtn()
    {
        isBtnClick = false;
        DataInterpret.SetActive(false);
        DataPieceContents.SetActive(true);
    }
}

