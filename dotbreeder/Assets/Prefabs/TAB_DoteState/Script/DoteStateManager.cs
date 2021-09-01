using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;
public class DoteStateManager : MonoBehaviour
{
    private GameManager Manager;
    private GameObject DoteInfo;
    private GameObject DotCondition;
    private GameObject PixelChart;
    private GameObject TotalChart;
    private GameObject ExpectedLV;

    void Start()
    {
        //���ӸŴ��� �ҷ�����.
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //private���� ���� �� ��Ʈ���� ���� ���� ���ӿ�����Ʈ �ʱ�ȭ.
        DoteInfo = transform.Find("DoteInfo").gameObject;
        DotCondition = transform.Find("DotCondition").gameObject;
        PixelChart = transform.Find("PixelChart").gameObject;
        TotalChart = transform.Find("TotalChart").gameObject;
        ExpectedLV = transform.Find("ExpectedLV").gameObject;
    }

    //���� �޴������� ��Ʈ ���������� �ҷ��� UI�� ������Ʈ ��Ų��.
    private void GetDoteInfo(string infotitle)
    {
      GameObject info = transform.Find(infotitle).gameObject;
      //info.GetComponentInChildren<Text>().text;
    }
    private void SetDoteInfo()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
