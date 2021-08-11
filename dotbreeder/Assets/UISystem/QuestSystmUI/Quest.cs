using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quest : MonoBehaviour
{
    GameObject InfoPage; //퀘스트 선택 시 우측에 나타나는 세부정보
   
    //엑셀로 string가져옴
    public int ID;
    public string Siblig;
    public int SiblingID;
    public int Hash;
    public string Region;
    public string Title;

    //public string Goal; 데이터 파싱 불필요!
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
        //UI에 보여지는 Title을 바꾼다.
        try
        {
           this.GetComponentInChildren<Text>().text=Title;

        }
        catch(Exception exc)
        {
           Debug.Log("Title 업로드 오류!");
        }
        
        //QuestBtn.GetComponentInChildren<Text>().text=Title;
 
    }
   

}
