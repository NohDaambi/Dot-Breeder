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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
