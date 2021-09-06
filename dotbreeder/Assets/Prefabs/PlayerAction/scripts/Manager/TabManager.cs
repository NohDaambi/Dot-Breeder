using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    //TabŰ �޴� ��ư ����

    public GameObject Dotinform;
    public GameObject Mixture;
    public GameObject Quest;
    public GameObject Data;

    public Animator TabAnim;

    public void DotinformBtn()
    {
        Dotinform.SetActive(true);
        Mixture.SetActive(false);
        Quest.SetActive(false);
        Data.SetActive(false);
        TabAnim.SetTrigger("isState");
    }
    public void MixtureBtn()
    {
        Dotinform.SetActive(false);
        Mixture.SetActive(true);
        Quest.SetActive(false);
        Data.SetActive(false);
        TabAnim.SetTrigger("isCombine");
    }
    public void QuestBtn()
    {
        Dotinform.SetActive(false);
        Mixture.SetActive(false);
        Quest.SetActive(true);
        Data.SetActive(false);
        TabAnim.SetTrigger("isQuest");
    }
    public void DataBlockBtn()
    {
        Dotinform.SetActive(false);
        Mixture.SetActive(false);
        Quest.SetActive(false);
        Data.SetActive(true);
        TabAnim.SetTrigger("isDate");
    }   
}

