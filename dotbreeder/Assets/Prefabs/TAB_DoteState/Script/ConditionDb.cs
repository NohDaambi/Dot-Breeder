using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDb : MonoBehaviour
{
    public int level; //��Ʈ ����
    public string condition; //���� ����
    public int count; //Ư�� ����
    public int IsClear; //�Ϸ� ����

    public int hash;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      //Clear������ ��쿡�� üũ�ڽ��� üũ Ȱ��ȭ.
      if(IsClear==1)
      {
         transform.Find("checkbox").Find("mark").gameObject.SetActive(true);
      }
    }
}
