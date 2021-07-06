using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//기능
//1. 좌표 역할을 할 투명스프라이트 오브젝트에 붙는다.
//2. "SponPixelManager"에서 이 오브젝트의 Collider2D_IsTrigger을 켰을 때 활성화 된다.
//3. for함수로 자식오브젝트의 트리거를 활성화 한다.
//4. 자식오브젝트 중 어떤 자식이 충돌했는지 판별 후 "SPonPixelManage"에 정보를 전송한다.
public class SponPosManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    public void ActiveTrigger() //SponPixelManager에 쓰였다.
    {
        //Istrigger를 활성화 시킨다.
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject Zenpos = transform.GetChild(i).gameObject;
            Zenpos.GetComponent<BoxCollider2D>().isTrigger = true; ; //isTrigger활성화
        }
    }

    private void UpdatePosInfo(ref BoxCollider2D[] poses)
    {
        //배열에 콜라이더 정보를 저장한다.
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject Zenpos = transform.GetChild(i).gameObject;
            poses[i] = Zenpos.GetComponent<BoxCollider2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BoxCollider2D[] poses = new BoxCollider2D[transform.childCount - 1];
        //부모가 자기 충돌인 줄 알고, 이 메서드를 실행시킨다.
        //어떤 자식인지 여기서 판별한다.(어감이 좀 이상하네...)
        UpdatePosInfo(ref poses);
        //isTouching()메서드를 통해 구현한다.
        for(int i =0;i<transform.childCount;i++)
        {
            if (poses[i].IsTouching(collision)&&collision.tag != "Player" && collision.tag != "Respawn") Debug.Log("Log:Something is already sponed" + poses[i].name);
            else
            {
                Debug.Log("Founded blanck space to spawn in[" + poses[i].name + " ]here");
                //충돌이 없다면 아무 것도 없다는 말!
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
