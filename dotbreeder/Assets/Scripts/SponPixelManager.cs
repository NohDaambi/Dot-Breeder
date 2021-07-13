using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// 픽셀이 스폰되는 오브젝트에 붙는 스크립트이다.
// 1. 플레이어와 충돌 && 플레이어가 채집 상태일때 아이템이 젠된다.
// 2. 아이템은 특정 확률로 젠된다. pixelspon 메서드가 수행. 기본적으로 자기의 성질값에따라 스폰하는 픽셀조각이 다르다.
// 3. 젠은 플레이어 위치값을 받아와서 갯수만큼 주변에 뿌려
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


    private int RendomPixel() //확률에 따른 픽셀조각 개수를 리턴한다.
    {
        //함수가 끝나면 초기화 되어야 해서 인스턴트 변수로 선언해 주었다.
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

    private GameObject SetPixelColor(GameObject me) //스폰할 픽셀 컬러를 결정한다. 인수로는 자기자신을 넣는다.
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

    //어떤 오브젝트와 충돌했는지 타일맵 안에서 찾는 다.
    private void FindCollisionObject(Collider2D player) //other에는 무조건 플레이어가 들어가야함.
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject ObjectPos = transform.GetChild(i).gameObject; //자식객체(ObjectPos들 가져오기)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = true; //모든 object의 콜라이더istrigger을 켜서 현재 player이 있는 위치를 좌표로 알 수 있다.

            if (collider2D.IsTouching(player))
            {
                //player과 충돌중?인 오브젝트이면 아래 코드 실핼
                Debug.Log("crashedObj Name:" + ObjectPos.name);

                //어차피 FlowerPos > SPonPos > ZenPos(1,2,3....)
                //SPonedPos는 ZenPos들의 상위 오브젝트이고, 여기서 충돌처리 계산 할거임!
                Sponpose = ObjectPos.transform; //자식객체(Sponpos 가져오기)-한개밖에 없음
            }
        }
        SetCollisionInitial();
    }

    //배열을 탐색해서 없는 스폰할 수 있는 공간을 내보낸다.
    private Transform SearchSponSpace(Transform Sponpos)
    {
        for (int i = 0; i < 4; i++)
        {
            if (Sponpos.GetComponent<SponPosManager>().sponposes[i] == false)
            {
                Debug.Log("SearchSPonSpace: 성공");
 
                return Sponpose.GetComponent<SponPosManager>().zenposes[i].transform;
            }    
        }
        Debug.Log("SearchSPonSpace: 실패");
        return transform;
    }

    //어떤 장소에서 충돌하는냐에 따라서 생성되는 색깔이 다르다. 맵1: 나무:blue 풀:green 꽃:red로 했다.
    //자기자신의 정보를 받아서, 성질값에 따라 달라진다.
    private void PixelSpon()
    {
        int debugcount = 0 ;
        //랜덤 한 확률로 픽셀을 스폰한다. 몇개 스폰할지 결정한다.
        //충돌자원에 따라 스폰하는 색깔을 결정한다.자기 자신 정보에서 가져온다.
        //스폰할 위치를 결정한다.(해당 장소-square-에 이미 다른 조각이 있으면 다른 장소를 탐색한다.
        //해당 색깔의 픽셀을 x개 스폰한다.
        for (int i = 0; i < RendomPixel(); i++)
        {
           Transform CanSPon = SearchSponSpace(Sponpose);
            int index = CanSPon.GetSiblingIndex();
           GameObject pixel = Instantiate(SetPixelColor(gameObject), CanSPon.position, CanSPon.rotation);
           Sponpose.GetComponent<SponPosManager>().sponposes[index] = true;
           debugcount++;
        }

        Debug.Log("픽셀조각생성 완료" + SetPixelColor(gameObject).name + debugcount);
    }


    //FinCollisionObject()함수를 사용한 뒤 반드시 아래함수를 통해 초기화 시켜줘여 함.
    private void SetCollisionInitial()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject ObjectPos = transform.GetChild(i).gameObject; //자식객체(ObjectPos들 가져오기)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = false; //모든 object의 콜라이더istrigger을 끈다.
        }
    }

    //다시 함수 설계중..

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

  


    //player tag를 가진 obj와 충돌 시 메세지 발송
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //태그가 플레이어이고 현재 액션 상태인지 확인
        {
            //PlayerMove는 플레이어 움직임 스크립트 입니다.임의로 설정해둔거라 playercontroller로 이름 바꿀게요!
            PlayerMove playerController = other.GetComponent<PlayerMove>();   
            Transform Player = other.GetComponent<Transform>();

            //상대방으로부터  PlayerController,Transform 컴포넌트를 가져오는데 성공했다면
            if (playerController != null && Player !=null) //나중에는 if(playerController != null && playerController.playerstate== action)로 수정예정
            {
                Debug.Log("채집");
                //현재 액션상태인지 확인 후 랜덤 픽셀 젠 메세지 보내기
                //flowerzenpos의 collision 체크 키기->어떤 꽃이랑 충돌했는지 알 수 있음.
                FindCollisionObject(other);//other=player collider, 충돌한 꽃의 위치 obj 얻음

                PixelSpon();

            }

        }
        else
            Debug.Log("충돌체이름: "+other.tag);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
