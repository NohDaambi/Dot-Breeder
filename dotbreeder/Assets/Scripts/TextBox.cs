using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBox : MonoBehaviour
{
    public Animator TxtBox;

    //퀘스트 내용, RGB수집 내용 출력
    void Awake()
    {
        TxtBox = GetComponent<Animator>();
    }

    void Update()
    {     
        //LeftCtrl키로 활성화 비활성화
        
        if (Input.GetButtonDown("Fire1"))
            TxtBox.SetTrigger("Show");

        if (Input.GetButtonUp("Fire1"))
            TxtBox.SetTrigger("Hide");
        
    }


    //마우스 호버링,,
   /* void OnMouseOver()
    {
        TxtBox.SetTrigger("Show");
    }

    void OnMouseExit()
    {
        TxtBox.SetTrigger("Hide");
    }
   */
}
