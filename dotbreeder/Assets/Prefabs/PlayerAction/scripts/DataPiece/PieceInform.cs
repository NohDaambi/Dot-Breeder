using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceInform : MonoBehaviour
{
    public PlayerAction Player;
    public DataPieceSort DataPiece;

    public Text InterpretText;

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
            DataPiece.PieceControl(0);
        if (Player.scanObject.name == "DataPiece2")
            DataPiece.PieceControl(1);
        if (Player.scanObject.name == "DataPiece3")
            DataPiece.PieceControl(2);
        if (Player.scanObject.name == "DataPiece4")
            DataPiece.PieceControl(3);
        if (Player.scanObject.name == "DataPiece5")
            DataPiece.PieceControl(4);
        if (Player.scanObject.name == "DataPiece6")
            DataPiece.PieceControl(5);
        if (Player.scanObject.name == "DataPiece7")
            DataPiece.PieceControl(6);
        if (Player.scanObject.name == "DataPiece8")
            DataPiece.PieceControl(7);
        if (Player.scanObject.name == "DataPiece9")
            DataPiece.PieceControl(8);
        if (Player.scanObject.name == "DataPiece10")
            DataPiece.PieceControl(9);
    }
    //�� ��ư �Ҵ�
    public void DataBtn0()
    {
        InterpretTextFunc(0);
        DataPiece.DoubleClick();
    }
    public void DataBtn1()
    {
        InterpretTextFunc(1);
        DataPiece.DoubleClick();
    }
    public void DataBtn2()
    {
        InterpretTextFunc(2);
        DataPiece.DoubleClick();
    }
    public void DataBtn3()
    {
        InterpretTextFunc(3);
        DataPiece.DoubleClick();
    }
    public void DataBtn4()
    {
        InterpretTextFunc(4);
        DataPiece.DoubleClick();
    }
    public void DataBtn5()
    {
        InterpretTextFunc(5);
        DataPiece.DoubleClick();
    }
    public void DataBtn6()
    {
        InterpretTextFunc(6);
        DataPiece.DoubleClick();
    }
    public void DataBtn7()
    {
        InterpretTextFunc(7);
        DataPiece.DoubleClick();
    }
    public void DataBtn8()
    {
        InterpretTextFunc(8);
        DataPiece.DoubleClick();
    }
    public void DataBtn9()
    {
        InterpretTextFunc(9);
        DataPiece.DoubleClick();
    }
}
