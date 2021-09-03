using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESOURCES_STATE
{
    //ä�� ������ ���� IDLE�� �Ҹ�Ǵ� ������ DEATH�� ������.
    IDLE = -1009909005,
    DESTROY = 1254594080
};

public class Resource : MonoBehaviour
{
    private GameManager Manager;
    public GameObject redpixelPrefab;
    public GameObject greenpixelPrefab;
    public GameObject bluepixelPrefab;
    public GameObject PixelPiece;

    Coroutine damageCoroutine;

    //ä���ڿ��� �⺻ ����
    public int hp=2; //�ϴ��� 1��: �÷��̾ 2�� ġ�� �װ� ��.

    public bool destroy_trigger;
    //ä���� ȹ�� ������ �ȼ� ���� ������
    private GameObject pixelprefab;

    //�ȼ����� � �����ϴ���?
    private int pixelcount;

    //Resources�� ��ġ�� position gameobject information
    private GameObject positioninfo;


    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //PixelPiece = transform.Find("PixelPiece").gameObject;
        int _layerMask = 1 << LayerMask.NameToLayer("Tilemap Position");
        Vector2 wp = gameObject.transform.position;
        Ray2D ray = new Ray2D(wp, Vector2.zero);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction,100f, _layerMask);

        foreach(var hit in hits)
        {
            if (!hit.collider.gameObject.CompareTag("Untagged"))
                continue;

            positioninfo = hit.collider.gameObject;

        }
        //���ڿ� ���� �ؽ��ڵ�.
        //Debug.Log("IDLE: " + "IDLE".GetHashCode());
        //Debug.Log("DELAY" + "DELAY".GetHashCode());
        //Debug.Log("SPON" + "SPON".GetHashCode());
    }
  
    //HP���� �� ����Ǵ� �ڷ�ƾ
    public IEnumerator Damage_Resources()
    {
        hp -= Manager.player.GetComponent<PlayerAction>().weaponstrength;
        Debug.Log("[!]System: ScanObject get damage:"+hp);

        if (hp <= 0&& destroy_trigger!=true)
        {
            destroy_trigger = true;

            StartCoroutine(Spon_Pixel());
            Destroy(this.gameObject);
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    //������Ʈ �ı��� ȣ��ȴ�.
    public IEnumerator Spon_Pixel()
    {
        Debug.Log("Start Coroutine Spon_Pixel!");
        positioninfo.GetComponent<RespawnCounter>().delay_trigger = true;
        for(int i=0;i<RendomPixel();i++){
            GameObject pixel = Instantiate(SetPixelColor(gameObject), transform.position, transform.rotation);
            
            //pixel.transform.SetParent(PixelPiece.transform, false); //���� �ڽ����� �ȵ��� ���� ���� ���� ����.
        }  
        yield return null;
    }


    private GameObject SetPixelColor(GameObject me) //������ �ȼ� �÷��� �����Ѵ�. �μ��δ� �ڱ��ڽ��� �ִ´�.
    {
        switch (me.tag)
        {
            case "Redspawner":
                //Debug.Log("You tried to get Redsponers pixel");
                return redpixelPrefab;

            case "Greenspawner":
                //Debug.Log("You tried to get Greensponers pixel");
                return greenpixelPrefab;

            case "Bluespawner":
                //Debug.Log("You tried to get Bluesponers pixel");
                return bluepixelPrefab;

            default:
                //Debug.Log("There's no matching tag");
                return gameObject;
        }

    }

    private int RendomPixel() //Ȯ���� ���� �ȼ����� ������ �����Ѵ�.
    {
        //�Լ��� ������ �ʱ�ȭ �Ǿ�� �ؼ� �ν���Ʈ ������ ������ �־���.
        int random = Random.Range(1, 101);
        int count = 0;
        switch (random)
        {
            case int n when (1 <= n && n <= 5): //5%
                //Debug.Log("Rendompixel: 1");
                count = 1;
                break;

            case int n when (6 <= n && n <= 45): //40%
                //Debug.Log("Rendompixel: 2");
                count = 2;
                break;

            case int n when (46 <= n && n <= 90): //45%
                //Debug.Log("Rendompixel: 3");
                count = 3;
                break;

            case int n when (91 <= n && n <= 98): //8%
                //Debug.Log("Rendompixel: 4");
                count = 4;
                break;

            case int n when (99 <= n && n <= 100): //2%
                //Debug.Log("Rendompixel: 5");
                count = 5;
                break;

        }
        return count;
    }
}

