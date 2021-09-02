using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDb : MonoBehaviour
{
    public int level; //도트 레벨
    public string condition; //성장 조건
    public int count; //특정 조건
    public int IsClear; //완료 여부

    public int hash;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      //Clear상태인 경우에는 체크박스에 체크 활성화.
      if(IsClear==1)
      {
         transform.Find("checkbox").Find("mark").gameObject.SetActive(true);
      }
    }
}
