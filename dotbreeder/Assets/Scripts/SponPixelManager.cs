using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// �ȼ��� �����Ǵ� ������Ʈ�� �ٴ� ��ũ��Ʈ�̴�.
// 1. �÷��̾�� �浹 && �÷��̾ ä�� �����϶� �������� ���ȴ�.
// 2. �������� Ư�� Ȯ���� ���ȴ�. pixelspon �޼��尡 ����. �⺻������ �ڱ��� ������������ �����ϴ� �ȼ������� �ٸ���.
// 3. ���� �÷��̾� ��ġ���� �޾ƿͼ� ������ŭ �ֺ��� �ѷ�
public class SponPixelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    //� ��ҿ��� �浹�ϴ³Ŀ� ���� �����Ǵ� ������ �ٸ���. ��1: ����:blue Ǯ:green ��:red�� �ߴ�.
    //�ڱ��ڽ��� ������ �޾Ƽ�, �������� ���� �޶�����.
    private void PixelSpon()
    {
        //���� �� Ȯ���� �ȼ��� �����Ѵ�. � �������� �����Ѵ�.
        //�浹�ڿ��� ���� �����ϴ� ������ �����Ѵ�.�ڱ� �ڽ� �������� �����´�.
        //������ ��ġ�� �����Ѵ�.(�ش� ���-square-�� �̹� �ٸ� ������ ������ �ٸ� ��Ҹ� Ž���Ѵ�.
        //�ش� ������ �ȼ��� x�� �����Ѵ�.
    }

    private int RendomPixel() //Ȯ���� ���� �ȼ����� ������ �����Ѵ�.
    {
        //�Լ��� ������ �ʱ�ȭ �Ǿ�� �ؼ� �ν���Ʈ ������ ������ �־���.
        int random = Random.Range(1, 101);
        int count=0;
        switch (random)
        {
            case int n when (1 <= n && n <= 5): //5%
                Debug.Log("Rendompixel: 1");
                count = 1;
                break;

            case int n when (6 <= n && n <= 45): //40%
                Debug.Log("Rendompixel: 2");
                count = 2;
                break;

            case int n when (46 <= n && n <= 90): //45%
                Debug.Log("Rendompixel: 3");
                count = 3;
                break;

            case int n when (91 <= n && n <= 98): //8%
                Debug.Log("Rendompixel: 4");
                count = 4;
                break;

            case int n when (99 <= n && n <= 100): //2%
                Debug.Log("Rendompixel: 5");
                count = 5;
                break;

        }
        return count;
    }

    private string SetPixelColor(GameObject me) //������ �ȼ� �÷��� �����Ѵ�. �μ��δ� �ڱ��ڽ��� �ִ´�.
    {
        switch(me.tag)
        {
            case "Redsponer":
                Debug.Log("You try to get Redsponers pixel");
                return "R";

            case "Greensponer":
                Debug.Log("You try to get Greensponers pixel");
                return "G";

            case "Bluesponer":
                Debug.Log("You try to get Bluesponers pixel");
                return "B";

            default:
                Debug.Log("There's no matching tag");
                break;
        }

        return "Null";

    }

    private GameObject FindCollisionObject(Collider2D player) //other���� ������ �÷��̾ ������.
    {
        Debug.Log("childCounting Test REsult:" + transform.childCount);

        for(int i=0;i<transform.childCount;i++)
        {
            GameObject ObjectPos = transform.GetChild(i).gameObject; //�ڽİ�ü(ObjectPos�� ��������)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = true; //��� object�� �ݶ��̴�istrigger�� �Ѽ� ���� player�� �ִ� ��ġ�� ��ǥ�� �� �� �ִ�.

            if (player.tag == "player")
            {
                //����� ���� ����ȯ
                SpriteRenderer sprite = ObjectPos.GetComponent<SpriteRenderer>();
                sprite.color = new Color(1, 1, 1, 1);

                SetCollisionInitial(ObjectPos.transform);
                return ObjectPos; //�÷��̾ �ִ� ���̶�� �ش� ��ġ �׿����� ����
            }
        }
        Debug.Log("Fail to Find");
        return gameObject;
    }

    //�Լ� �����ε�: �Ʒ��� �÷��̾ �ƴ� �ȼ������� �̹� �����Ǿ� �ִ� ��ġ�� �Ǻ��ϱ� ���� ����.
    private GameObject FindCollisionObject(GameObject ObjectPos)
    {
        Transform Objectpos = ObjectPos.transform;
        for (int i = 0; i < Objectpos.childCount; i++)
        {
            GameObject Sponedpos = Objectpos.GetChild(i).gameObject; //�ڽİ�ü(ObjectPos�� ��������)
            BoxCollider2D collider2D = Objectpos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = true; //��� object�� �ݶ��̴�istrigger�� Ų��.

            if (ObjectPos.tag != "Respawn" && ObjectPos.tag != "Respawn")
            {
                //����� ���� ����ȯ
                SpriteRenderer sprite = ObjectPos.GetComponent<SpriteRenderer>();
                sprite.color = new Color(1, 1, 1, 1);

                SetCollisionInitial(Sponedpos.transform);
                return ObjectPos; //�ȼ��� ���� ���̶�� �ش� ��ġ �׿����� ����
            }
        }

        Debug.Log("Fail to Find");
        return gameObject;
    }


    //FinCollisionObject()�Լ��� ����� �� �ݵ�� �Ʒ��Լ��� ���� �ʱ�ȭ �����࿩ ��.
    private void SetCollisionInitial(Transform transforms)
    {
        for (int i = 0; i < transforms.childCount; i++)
        {
            GameObject ObjectPos = transforms.GetChild(i).gameObject; //�ڽİ�ü(ObjectPos�� ��������)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = false; //��� object�� �ݶ��̴�istrigger�� ����.
        }
    }

    private void SetPixelPosition(GameObject Sponpos) //������ �ȼ� ��ġ�� �����Ѵ�. 
    {
        FindCollisionObject(Sponpos); //�ȼ������� �̹� �����Ǿ� �ִ� ��ġ�� �Ǻ��ϱ� ���� ����.
    }


    //player tag�� ���� obj�� �浹 �� �޼��� �߼�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //�±װ� �÷��̾��̰� ���� �׼� �������� Ȯ��
        {
            //PlayerMove�� �÷��̾� ������ ��ũ��Ʈ �Դϴ�.���Ƿ� �����صаŶ� playercontroller�� �̸� �ٲܰԿ�!
            PlayerMove playerController = other.GetComponent<PlayerMove>();   
            Transform Player = other.GetComponent<Transform>();

            //�������κ���  PlayerController,Transform ������Ʈ�� �������µ� �����ߴٸ�
            if (playerController != null && Player !=null) //���߿��� if(playerController != null && playerController.playerstate== action)�� ��������
            {
                Debug.Log("Playerposition:" + Player.position);
                //���� �׼ǻ������� Ȯ�� �� ���� �ȼ� �� �޼��� ������
                //flowerzenpos�� collision üũ Ű��->� ���̶� �浹�ߴ��� �� �� ����.
                SetPixelPosition(FindCollisionObject(other));//other=player collider

                //SponPixel(); �����ȼ� �޼��� ����
            }

           // Debug.Log("player,flower collsion");
        }
        else
            Debug.Log("not collision");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
