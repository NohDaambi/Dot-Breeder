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
    // Start is called before the first frame update
    void Start()
    {
    }

    //어떤 장소에서 충돌하는냐에 따라서 생성되는 색깔이 다르다. 맵1: 나무:blue 풀:green 꽃:red로 했다.
    //자기자신의 정보를 받아서, 성질값에 따라 달라진다.
    private void PixelSpon()
    {
        //랜덤 한 확률로 픽셀을 스폰한다. 몇개 스폰할지 결정한다.
        //충돌자원에 따라 스폰하는 색깔을 결정한다.자기 자신 정보에서 가져온다.
        //스폰할 위치를 결정한다.(해당 장소-square-에 이미 다른 조각이 있으면 다른 장소를 탐색한다.
        //해당 색깔의 픽셀을 x개 스폰한다.
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

    private string SetPixelColor(GameObject me) //스폰할 픽셀 컬러를 결정한다. 인수로는 자기자신을 넣는다.
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

    private GameObject FindCollisionObject(Collider2D player) //other에는 무조건 플레이어가 들어가야함.
    {
        Debug.Log("childCounting Test REsult:" + transform.childCount);

        for(int i=0;i<transform.childCount;i++)
        {
            GameObject ObjectPos = transform.GetChild(i).gameObject; //자식객체(ObjectPos들 가져오기)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = true; //모든 object의 콜라이더istrigger을 켜서 현재 player이 있는 위치를 좌표로 알 수 있다.

            if (player.tag == "player")
            {
                //디버깅 위해 색변환
                SpriteRenderer sprite = ObjectPos.GetComponent<SpriteRenderer>();
                sprite.color = new Color(1, 1, 1, 1);

                SetCollisionInitial(ObjectPos.transform);
                return ObjectPos; //플레이어가 있는 곳이라면 해당 위치 겜오브젝 리턴
            }
        }
        Debug.Log("Fail to Find");
        return gameObject;
    }

    //함수 오버로딩: 아래는 플레이어가 아닌 픽셀조각이 이미 생성되어 있는 위치를 판별하기 위해 사용됨.
    private GameObject FindCollisionObject(GameObject ObjectPos)
    {
        Transform Objectpos = ObjectPos.transform;
        for (int i = 0; i < Objectpos.childCount; i++)
        {
            GameObject Sponedpos = Objectpos.GetChild(i).gameObject; //자식객체(ObjectPos들 가져오기)
            BoxCollider2D collider2D = Objectpos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = true; //모든 object의 콜라이더istrigger을 킨다.

            if (ObjectPos.tag != "Respawn" && ObjectPos.tag != "Respawn")
            {
                //디버깅 위해 색변환
                SpriteRenderer sprite = ObjectPos.GetComponent<SpriteRenderer>();
                sprite.color = new Color(1, 1, 1, 1);

                SetCollisionInitial(Sponedpos.transform);
                return ObjectPos; //픽셀이 없는 곳이라면 해당 위치 겜오브젝 리턴
            }
        }

        Debug.Log("Fail to Find");
        return gameObject;
    }


    //FinCollisionObject()함수를 사용한 뒤 반드시 아래함수를 통해 초기화 시켜줘여 함.
    private void SetCollisionInitial(Transform transforms)
    {
        for (int i = 0; i < transforms.childCount; i++)
        {
            GameObject ObjectPos = transforms.GetChild(i).gameObject; //자식객체(ObjectPos들 가져오기)
            BoxCollider2D collider2D = ObjectPos.GetComponent<BoxCollider2D>();
            collider2D.isTrigger = false; //모든 object의 콜라이더istrigger을 끈다.
        }
    }

    private void SetPixelPosition(GameObject Sponpos) //스폰할 픽셀 위치를 결정한다. 
    {
        FindCollisionObject(Sponpos); //픽셀조각이 이미 생성되어 있는 위치를 판별하기 위해 사용됨.
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
                Debug.Log("Playerposition:" + Player.position);
                //현재 액션상태인지 확인 후 랜덤 픽셀 젠 메세지 보내기
                //flowerzenpos의 collision 체크 키기->어떤 꽃이랑 충돌했는지 알 수 있음.
                SetPixelPosition(FindCollisionObject(other));//other=player collider

                //SponPixel(); 스폰픽셀 메서드 실핼
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
