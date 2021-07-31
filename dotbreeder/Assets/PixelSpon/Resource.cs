using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESOURCES_STATE
{
    //채집 가능한 상태 IDLE과 소멸되는 상태인 DEATH로 나뉜다.
    IDLE = -1009909005,
    DESTROY = 1254594080
};

public class Resource : MonoBehaviour
{
    public GameObject redpixelPrefab;
    public GameObject greenpixelPrefab;
    public GameObject bluepixelPrefab;
    public GameObject PixelPiece;

    Coroutine damageCoroutine;

    //채집자원의 기본 정보
    public int hp=2; //일단은 1로: 플레이어가 2번 치면 죽게 함.

    public bool destroy_trigger;
    //채집시 획득 가능한 픽셀 조각 프리팹
    private GameObject pixelprefab;

    //픽셀조각 몇개 스폰하는지?
    private int pixelcount;

    //Resources가 위치한 position gameobject information
    private GameObject positioninfo;
    //Player정보 Get
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
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
        //문자열 대응 해시코드.
        //Debug.Log("IDLE: " + "IDLE".GetHashCode());
        //Debug.Log("DELAY" + "DELAY".GetHashCode());
        //Debug.Log("SPON" + "SPON".GetHashCode());
    }
  
    //HP깎을 때 실행되는 코루틴
    public IEnumerator Damage_Resources()
    {
        while (true)
        {
            hp -= player.GetComponent<PlayerMove>().weaponstrength;

            if (hp <= 0&& destroy_trigger!=true)
            {
                destroy_trigger = true;

                StartCoroutine(Spon_Pixel());
                Destroy(this.gameObject);
                break;
            }
            else
            {
                break;
            }

        }
        yield return null;
    }

    //오브젝트 파괴시 호출된다.
    public IEnumerator Spon_Pixel()
    {
        Debug.Log("Start Coroutine Spon_Pixel!");
        positioninfo.GetComponent<RespawnCounter>().delay_trigger = true;
        for(int i=0;i<RendomPixel();i++){
            GameObject pixel = Instantiate(SetPixelColor(gameObject), transform.position, transform.rotation);
        }
        
        //pixel.transform.SetParent(PixelPiece.transform, false); //현재 자식으로 안들어가는 오류 있음 추후 수정.
        yield return null;
    }


    //Flower의 충돌이 있거나 픽셀의 충돌이 있으면 호출되는 함수이다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌을 받았을 때 코루틴을 실행시킨다.
        if (collision.gameObject.CompareTag("Player")/*&&플레이어가 공격상태*/)
        {
            if(damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(Damage_Resources());
            }
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //충돌을 받았을 때 코루틴을 멈춘다.
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(Damage_Resources());
                damageCoroutine = null;
            }
        }
    }




    private GameObject SetPixelColor(GameObject me) //스폰할 픽셀 컬러를 결정한다. 인수로는 자기자신을 넣는다.
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

    private int RendomPixel() //확률에 따른 픽셀조각 개수를 리턴한다.
    {
        //함수가 끝나면 초기화 되어야 해서 인스턴트 변수로 선언해 주었다.
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

