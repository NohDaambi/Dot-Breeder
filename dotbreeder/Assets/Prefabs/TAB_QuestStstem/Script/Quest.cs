using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quest : MonoBehaviour
{
    public GameObject InfoTitle; //퀘스트 선택 시 우측에 나타나는 세부정보
    public GameObject InfoDes;

    //descrtption list
    public List<GameObject> DesList = new List<GameObject>();
 
   
    //엑셀로 string가져옴
    public int ID;
    public int Siblig;
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

    void Update()
    {
        //버튼 클릭으로 인해 자기 정보와 다른 텍스트가 인포에 보여질 경우
        if(InfoTitle.transform.GetComponentInChildren<Text>().text!=Title) for(int i=0;i<DesList.Count;i++) DesList[i].SetActive(false);
        
        //목표 퀘스트 달성 조건이 만족했을 경우.

    }

    //If Left Quest Title Button clicked
    public void QuestTitleBtn()
    {
        Debug.Log("Title Btn Clciked!!");
        InfoTitle.transform.GetComponentInChildren<Text>().text=Title; //버튼 클릭시 제목 변경
        InfoDes.transform.GetChild(0).gameObject.GetComponent<Text>().text=Des; //버튼 클릭시 설명 변경

        if(DesList==null )  return;//리스트 빈값이면 리턴, 일단 급한대로 지정수로 판단함->고쳐야됨 완전 잘못된 코드임
        
        //리스트 존재하면
        //리스트 길이 만큼 순회+setActicve
        for(int i=0;i<DesList.Count;i++)
        {
            DesList[i].SetActive(true);
        }

    }
   
    
    
}
