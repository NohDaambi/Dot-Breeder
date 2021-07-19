using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBox : MonoBehaviour
{
    public Animator TxtBox;

    //����Ʈ ����, RGB���� ���� ���
    void Awake()
    {
        TxtBox = GetComponent<Animator>();
    }

    void Update()
    {     
        //LeftCtrlŰ�� Ȱ��ȭ ��Ȱ��ȭ
        
        if (Input.GetButtonDown("Fire1"))
            TxtBox.SetTrigger("Show");

        if (Input.GetButtonUp("Fire1"))
            TxtBox.SetTrigger("Hide");
        
    }


    //���콺 ȣ����,,
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
