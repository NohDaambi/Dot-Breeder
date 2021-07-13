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
    private const int sponposesnum = 4; //������ �ʴ� ���̱� ������ const�� ���ȭ ���ش�.
   
    //�ڸ��� ��ü�� �ִ��� ������ �迭�� �����Ѵ�. ������ true ������ false.
    //�ȼ��� �����ɶ� �ڵ����� true�� �ٱϴ�.
    public bool[] sponposes = new bool[sponposesnum];
    public GameObject[] zenposes = new GameObject[sponposesnum]; //������ �ȼ�����
    private BoxCollider2D[] posesCollider = new BoxCollider2D[sponposesnum];

 // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<sponposesnum;i++)
        {
            posesCollider[i] = zenposes[i].GetComponent<BoxCollider2D>();
        }
    }

    //collision�� �ƴ� �迭�� ��ġ ������ �ذ��Ұ���..�Ф�
    public void SearchSponSpaces(Transform Sponpos) //� obj�� �����ߴ��� �μ��� �ް�, �� ������Ʈ �Ʒ��� �������� ��ġ �ҷ��´�.
    {
        //player�� �浹�� obj�� ������Ҹ� �迭�� ������Ʈ �Ѵ�.
        Transform[] ZenPos = new Transform[4];
        for (int i = 0; i < Sponpos.childCount; i++)
        {
            ZenPos[i] = Sponpos.GetChild(i).transform;
        }

        //�迭 Ž��: �迭�� ���� ������Ʈ ����.
        for (int i = 0; i < ZenPos.Length; i++)
        {
            for (int n = 0; i > zenposes.Length; n++)
            {
                if (ZenPos[i].position.x != zenposes[i].transform.position.x && ZenPos[i].position.y != zenposes[i].transform.position.y)
                {

                }
            }
        }


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

    public void MakePosValTrue(int i)
    {
        sponposes[i] = true;
    }

    private void MakePosValFalse(Collider2D collision)
    {
        switch (collision.name)
        {
            case "Zenpos":
                sponposes[0] = false;
                break;
            case "Zenpos(1)":
                sponposes[1] = false;
                break;
            case "Zenpos(2)":
                sponposes[2] = false;
                break;
            case "Zenpos(3)":
                sponposes[3] = false;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ////�ɿ� ���� �浹�� �ߴ��� Ȯ��
        //BoxCollider2D[] poses = new BoxCollider2D[transform.childCount];
        ////�θ� �ڱ� �浹�� �� �˰�, �� �޼��带 �����Ų��.
        ////� �ڽ����� ���⼭ �Ǻ��Ѵ�.(��� �� �̻��ϳ�...)
        //UpdatePosInfo(ref poses);
        ////isTouching()�޼��带 ���� �����Ѵ�.
        

        //for(int i =0;i<transform.childCount;i++)
        //{
        //   if (posesCollider[i].IsTouching(collision) && collision.tag != "Respawn")
        //   {
        //       Debug.Log("Log:Something is already sponed:" + posesCollider[i].name + "/// �浹ü�̸�:" + collision.name);
        //       MakePosValTrue(i);
        //  }
        //}

        //////Ʈ���Ű� ������ŭ ������,


        ////Debug.Log("Ʈ���� �ѹ� ��");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
