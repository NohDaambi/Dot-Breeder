using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quest : MonoBehaviour
{
    GameObject InfoPage; //����Ʈ ���� �� ������ ��Ÿ���� ��������
   
    //������ string������
    public int ID;
    public string Siblig;
    public int SiblingID;
    public int Hash;
    public string Region;
    public string Title;

    //public string Goal; ������ �Ľ� ���ʿ�!
    public string Des;

    public int Prev;
    public int Count;
    public int Clear;

    //UIObject
    //private Text title;
    
    void Start()
    {
       
    }
    public void UpdateText()
    {
        //UI�� �������� Title�� �ٲ۴�.
        try
        {
           this.GetComponentInChildren<Text>().text=Title;

        }
        catch(Exception exc)
        {
           Debug.Log("Title ���ε� ����!");
        }
        
        //QuestBtn.GetComponentInChildren<Text>().text=Title;
 
    }
   

}
