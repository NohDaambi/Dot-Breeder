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
    public GameObject redpixelPrefab;
    public GameObject greenpixelPrefab;
    public GameObject bluepixelPrefab;
    public Transform Sponpose;
    // Start is called before the first frame update
    void Start()
    {
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

    private GameObject SetPixelColor(GameObject me) //������ �ȼ� �÷��� �����Ѵ�. �μ��δ� �ڱ��ڽ��� �ִ´�.
    {
        switch(me.tag)
        {
            case "Redsponer":
                Debug.Log("You tried to get Redsponers pixel");
                return redpixelPrefab;

            case "Greensponer":
                Debug.Log("You tried to get Greensponers pixel");
                return greenpixelPrefab;

            case "Bluesponer":
                Debug.Log("You tried to get Bluesponers pixel");
                return bluepixelPrefab;

            default:
                Debug.Log("There's no matching tag");
                return gameObject;
        }



    }

    //� ������Ʈ�� �浹�ߴ��� Ÿ�ϸ� �ȿ��� ã�� ��.
    private void FindCollisionObject(Collider2D player) //other���� ������ �÷��̾ ������.
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject ObjectPos = transform.GetChild(i).gameObject; //�ڽİ�ü(ObjectPos�� ��������)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = true; //��� object�� �ݶ��̴�istrigger�� �Ѽ� ���� player�� �ִ� ��ġ�� ��ǥ�� �� �� �ִ�.

            if (collider2D.IsTouching(player))
            {
                //player�� �浹��?�� ������Ʈ�̸� �Ʒ� �ڵ� ����
                Debug.Log("crashedObj Name:" + ObjectPos.name);

                //������ FlowerPos > SPonPos > ZenPos(1,2,3....)
                //SPonedPos�� ZenPos���� ���� ������Ʈ�̰�, ���⼭ �浹ó�� ��� �Ұ���!
                Sponpose = ObjectPos.transform; //�ڽİ�ü(Sponpos ��������)-�Ѱ��ۿ� ����
            }
        }
        SetCollisionInitial();
    }

    //�迭�� Ž���ؼ� ���� ������ �� �ִ� ������ ��������.
    private Transform SearchSponSpace(Transform Sponpos)
    {
        for (int i = 0; i < 4; i++)
        {
            if (Sponpos.GetComponent<SponPosManager>().sponposes[i] == false)
            {
                Debug.Log("SearchSPonSpace: ����");
 
                return Sponpose.GetComponent<SponPosManager>().zenposes[i].transform;
            }    
        }
        Debug.Log("SearchSPonSpace: ����");
        return transform;
    }

    //� ��ҿ��� �浹�ϴ³Ŀ� ���� �����Ǵ� ������ �ٸ���. ��1: ����:blue Ǯ:green ��:red�� �ߴ�.
    //�ڱ��ڽ��� ������ �޾Ƽ�, �������� ���� �޶�����.
    private void PixelSpon()
    {
        int debugcount = 0 ;
        //���� �� Ȯ���� �ȼ��� �����Ѵ�. � �������� �����Ѵ�.
        //�浹�ڿ��� ���� �����ϴ� ������ �����Ѵ�.�ڱ� �ڽ� �������� �����´�.
        //������ ��ġ�� �����Ѵ�.(�ش� ���-square-�� �̹� �ٸ� ������ ������ �ٸ� ��Ҹ� Ž���Ѵ�.
        //�ش� ������ �ȼ��� x�� �����Ѵ�.
        for (int i = 0; i < RendomPixel(); i++)
        {
           Transform CanSPon = SearchSponSpace(Sponpose);
            int index = CanSPon.GetSiblingIndex();
           GameObject pixel = Instantiate(SetPixelColor(gameObject), CanSPon.position, CanSPon.rotation);
           Sponpose.GetComponent<SponPosManager>().sponposes[index] = true;
           debugcount++;
        }

        Debug.Log("�ȼ��������� �Ϸ�" + SetPixelColor(gameObject).name + debugcount);
    }


    //FinCollisionObject()�Լ��� ����� �� �ݵ�� �Ʒ��Լ��� ���� �ʱ�ȭ �����࿩ ��.
    private void SetCollisionInitial()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject ObjectPos = transform.GetChild(i).gameObject; //�ڽİ�ü(ObjectPos�� ��������)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = false; //��� object�� �ݶ��̴�istrigger�� ����.
        }
    }

    //�ٽ� �Լ� ������..

    public void CalculateSponPos(string position)
    {
        switch(position)
        {
            case "x":
                break;
            case "y":
                break;
            case "z":
                break;
        }
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
                Debug.Log("ä��");
                //���� �׼ǻ������� Ȯ�� �� ���� �ȼ� �� �޼��� ������
                //flowerzenpos�� collision üũ Ű��->� ���̶� �浹�ߴ��� �� �� ����.
                FindCollisionObject(other);//other=player collider, �浹�� ���� ��ġ obj ����

                PixelSpon();

            }

        }
        else
            Debug.Log("�浹ü�̸�: "+other.tag);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
