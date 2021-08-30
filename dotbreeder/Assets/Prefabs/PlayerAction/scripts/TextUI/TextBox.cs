using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextBox : MonoBehaviour
{
    public Animator TxtBox;

    void Awake()
    {
        TxtBox = GetComponent<Animator>();
    }

    void Update()
    {     
        //LeftCtrl키로 활성화 비활성화
        
        if (Input.GetButtonDown("Fire1")&& !Input.GetMouseButtonDown(0))
            TxtBox.SetTrigger("Show");

        if (Input.GetButtonUp("Fire1")&& !Input.GetMouseButtonUp(0))
            TxtBox.SetTrigger("Hide");
  
    }


   //마우스가 UI창 부분에 있으면 창 보임
    private void OnMouseEnter()
    {
        TxtBox.SetTrigger("Show");
    }

    private void OnMouseExit()
    {
       TxtBox.SetTrigger("Hide");
    }
}
