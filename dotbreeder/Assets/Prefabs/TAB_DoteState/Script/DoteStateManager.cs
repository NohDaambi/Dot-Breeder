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
        //게임매니저 불러오기.
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //private으로 선언 한 도트상태 탭의 구성 게임오브젝트 초기화.
        DoteInfo = transform.Find("DoteInfo").gameObject;
        DotCondition = transform.Find("DotCondition").gameObject;
        PixelChart = transform.Find("PixelChart").gameObject;
        TotalChart = transform.Find("TotalChart").gameObject;
        ExpectedLV = transform.Find("ExpectedLV").gameObject;
    }

    //게임 메니저에서 도트 인포정보를 불러와 UI에 업데이트 시킨다.
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
