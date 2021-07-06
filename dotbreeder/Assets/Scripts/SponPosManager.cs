using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���
//1. ��ǥ ������ �� ����������Ʈ ������Ʈ�� �ٴ´�.
//2. "SponPixelManager"���� �� ������Ʈ�� Collider2D_IsTrigger�� ���� �� Ȱ��ȭ �ȴ�.
//3. for�Լ��� �ڽĿ�����Ʈ�� Ʈ���Ÿ� Ȱ��ȭ �Ѵ�.
//4. �ڽĿ�����Ʈ �� � �ڽ��� �浹�ߴ��� �Ǻ� �� "SPonPixelManage"�� ������ �����Ѵ�.
public class SponPosManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    public void ActiveTrigger() //SponPixelManager�� ������.
    {
        //Istrigger�� Ȱ��ȭ ��Ų��.
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject Zenpos = transform.GetChild(i).gameObject;
            Zenpos.GetComponent<BoxCollider2D>().isTrigger = true; ; //isTriggerȰ��ȭ
        }
    }

    private void UpdatePosInfo(ref BoxCollider2D[] poses)
    {
        //�迭�� �ݶ��̴� ������ �����Ѵ�.
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject Zenpos = transform.GetChild(i).gameObject;
            poses[i] = Zenpos.GetComponent<BoxCollider2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BoxCollider2D[] poses = new BoxCollider2D[transform.childCount - 1];
        //�θ� �ڱ� �浹�� �� �˰�, �� �޼��带 �����Ų��.
        //� �ڽ����� ���⼭ �Ǻ��Ѵ�.(��� �� �̻��ϳ�...)
        UpdatePosInfo(ref poses);
        //isTouching()�޼��带 ���� �����Ѵ�.
        for(int i =0;i<transform.childCount;i++)
        {
            if (poses[i].IsTouching(collision)&&collision.tag != "Player" && collision.tag != "Respawn") Debug.Log("Log:Something is already sponed" + poses[i].name);
            else
            {
                Debug.Log("Founded blanck space to spawn in[" + poses[i].name + " ]here");
                //�浹�� ���ٸ� �ƹ� �͵� ���ٴ� ��!
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
