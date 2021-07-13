using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//픽셀조각에 대한 클래스이다. 픽셀조각 스프라이트에 들어가고, 프리팹으로 에셋에 저장되어있다.
//<기능>
//1. 플레이어와 충돌시 이미지 사라지고 데이터도 소멸(0)
//2. 충돌 후 플레이어에게 메세지를 보낸다. 픽셀개수 증가하라고.(0)
//3. 생성된지 특정시간이 되었는데도 충돌이 없다면 자동 소멸한다.(0)
public class PixelpieceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //생성된 직후부터 카운트 시작. 일단은 7초뒤에 플레이어가 조각을 먹지 않으면 소멸.
        Destroy(gameObject, 7f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        //else
          //  Debug.Log("not collision with pixel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
