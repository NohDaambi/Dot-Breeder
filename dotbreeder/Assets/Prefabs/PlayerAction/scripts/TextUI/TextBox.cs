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
        //LeftCtrlŰ�� Ȱ��ȭ ��Ȱ��ȭ
        
        if (Input.GetButtonDown("Fire1")&& !Input.GetMouseButtonDown(0))
            TxtBox.SetTrigger("Show");

        if (Input.GetButtonUp("Fire1")&& !Input.GetMouseButtonUp(0))
            TxtBox.SetTrigger("Hide");
  
    }


   //���콺�� UIâ �κп� ������ â ����
    private void OnMouseEnter()
    {
        TxtBox.SetTrigger("Show");
    }

    private void OnMouseExit()
    {
       TxtBox.SetTrigger("Hide");
    }
}
