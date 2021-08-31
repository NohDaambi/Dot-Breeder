using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    //Tab키 메뉴 버튼 관리

    public GameObject Dotinform;
    public GameObject Mixture;
    public GameObject Quest;
    public GameObject Data;

    public void DotinformBtn()
    {
        Dotinform.SetActive(true);
        Mixture.SetActive(false);
        Quest.SetActive(false);
        Data.SetActive(false);
    }
    public void MixtureBtn()
    {
        Dotinform.SetActive(false);
        Mixture.SetActive(true);
        Quest.SetActive(false);
        Data.SetActive(false);
    }
    public void QuestBtn()
    {
        Dotinform.SetActive(false);
        Mixture.SetActive(false);
        Quest.SetActive(true);
        Data.SetActive(false);
    }
    public void DataBlockBtn()
    {
        Dotinform.SetActive(false);
        Mixture.SetActive(false);
        Quest.SetActive(false);
        Data.SetActive(true);
    }   
}

