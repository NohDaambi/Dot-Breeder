using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quest : MonoBehaviour
{
    public GameObject InfoTitle; //����Ʈ ���� �� ������ ��Ÿ���� ��������
    public GameObject InfoDes;

    //descrtption list
    public List<GameObject> DesList = new List<GameObject>();
 
   
    //������ string������
    public int ID;
    public int Siblig;
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

    void Update()
    {
        //��ư Ŭ������ ���� �ڱ� ������ �ٸ� �ؽ�Ʈ�� ������ ������ ���
        if(InfoTitle.transform.GetComponentInChildren<Text>().text!=Title) for(int i=0;i<DesList.Count;i++) DesList[i].SetActive(false);
        
        //��ǥ ����Ʈ �޼� ������ �������� ���.

    }

    //If Left Quest Title Button clicked
    public void QuestTitleBtn()
    {
        Debug.Log("Title Btn Clciked!!");
        InfoTitle.transform.GetComponentInChildren<Text>().text=Title; //��ư Ŭ���� ���� ����
        InfoDes.transform.GetChild(0).gameObject.GetComponent<Text>().text=Des; //��ư Ŭ���� ���� ����

        if(DesList==null )  return;//����Ʈ ���̸� ����, �ϴ� ���Ѵ�� �������� �Ǵ���->���ľߵ� ���� �߸��� �ڵ���
        
        //����Ʈ �����ϸ�
        //����Ʈ ���� ��ŭ ��ȸ+setActicve
        for(int i=0;i<DesList.Count;i++)
        {
            DesList[i].SetActive(true);
        }

    }
   
    
    
}
