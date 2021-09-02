using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//픽셀조각에 대한 클래스이다. 픽셀조각 스프라이트에 들어가고, 프리팹으로 에셋에 저장되어있다.
//<기능>
//1. 플레이어와 충돌시 이미지 사라지고 데이터도 소멸(0)
//2. 충돌 후 플레이어에게 메세지를 보낸다. 픽셀개수 증가하라고.(0)
//3. 생성된지 특정시간이 되었는데도 충돌이 없다면 자동 소멸한다.(0)

public enum PIXEL_STATE
{
    IDLE = -1341230092, //기본상태
    DELAY = 1272707897, // 특정시간이 지나면 DESTROY상태로 바뀐다
    DESTROY = 1254594080, // DESTROY상태에서는 객체를 소멸시키고 배열bool값을 true로 바꾼다.
};

public class PixelpieceController : MonoBehaviour
{
    public PIXEL_STATE CurrentState = PIXEL_STATE.IDLE;
    public GameObject SponPose;
    private float stay_time = 10.0f; //하이딩
    public bool posetrigger = false;
    public int sponindex;

    void Start()
    {
        //생성된 직후부터 카운트 시작. 일단은 7초뒤에 플레이어가 조각을 먹지 않으면 소멸.
        Destroy(gameObject, 7f);

        //corutine 방식으로 해결
        //생성된 직후에는 DELAY상태로 전환됨.(time count)
        StartCoroutine(State_Delay());

        //생성되면서 자신의 위치를 저장한다.
        //위치값은 코인과, ZenPos의 충돌을 이용해 알아낸다. 충돌은 tag를 통해서 특정 물체끼리만 충돌이 반응하도록 제어한다.

    }

   public void Destroy_Pixel()
   {
       Debug.Log("[!]Player-Coin Interaction");
       Destroy(gameObject);//자기 자신 삭제!
   }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //플레이어가 픽셀을 수집할때의 상황 판단.
        if (other.tag == "Player") //태그가 플레이어인지 확인
        {
            //PlayerMove는 플레이어 움직임 스크립트 입니다.임의로 설정해둔거라 playercontroller로 이름 바꿀게요!
            PlayerMove playerController = other.GetComponent<PlayerMove>();

            //상대방으로부터  PlayerController컴포넌트를 가져오는데 성공했다면
            if (playerController != null) 
            {
                //playerController.GetPixel(GameObject); 메서드 실행: 플레이어에게 획득한 픽셀의 정보를 보낸다.
                //Debug.Log("획득한 픽셀->플레이어 정보 전달 완료");
                Debug.Log("획득한 픽셀->플레이어 정보 전달 요청");
                //삭제하기전 위치에 없어지는거니까 메모리도 삭제 요청 다른 스크립트에 보내기.
                Destroy(gameObject);//자기 자신 삭제!
            }
        }
       
        //생성된 위치의 정보는 한번만 가져오도록 한다.
        if(other.tag == "Untagged" && posetrigger == false)
        {
           //충돌한 위치가 부모오브젝트의 몇번째 자식인지 추출(그래야지 배열 접근 가능)
            sponindex = other.GetComponent<Transform>().GetSiblingIndex();
            //충돌한 위치의 부모오브젝트 접근(부모오브젝트에 스크립트가 붙어있음)
            SponPose = other.GetComponent<Transform>().parent.gameObject;

            
            //이 작업은 생성된 후 한번만 시행되어야 하므로, 트리거를 통해 제어한다.
            posetrigger = true;
        }
    }

    public IEnumerator State_Idle()
    {
        CurrentState = PIXEL_STATE.IDLE;

        yield return null;
    }

    public IEnumerator State_Delay()
    {
        CurrentState = PIXEL_STATE.DELAY;

        while (CurrentState == PIXEL_STATE.DELAY)
        {
            // 시간 초과 계산 지점
            float ElapsedTime = 0f;
            while (true)
            {
                //시간을 증가시킨다
                ElapsedTime += Time.deltaTime;

                //다음프레임까지 기다린다.
                yield return null;

                if (ElapsedTime >= stay_time)
                {
                    StartCoroutine(State_Destroy());
                    yield break;
                }
            }
        }

        yield return null;
    }

    //코루틴 형식이지만 한번 실행후 바로 객체가 삭제된다.
    public IEnumerator State_Destroy()
    {
        CurrentState = PIXEL_STATE.DESTROY;

        //1. 어떤 위치에서 스폰 되었는가?   V
        //2. 그 위치의 인덱스는 무엇인가?  V _1,2번은 OnTrigger매서드에서 판단.
        //3. 배열에서 false로 바꿔준다.  V

        //SponPos 오브젝트에 있는 스크립트에 접근 후, 해당 물체여부가 저장된 배열에서 bool값 변경.
        //false가 자리에 물체가 없다는 뜻!
        SponPose.GetComponent<SponPosManager>().sponposes[sponindex] = false;

        //객체 삭제
        Destroy(gameObject);
        yield return null;
    }

}
