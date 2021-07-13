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
    private const int sponposesnum = 4; //변하지 않는 값이기 때문에 const로 상수화 해준다.
   
    //자리에 물체가 있는지 없는지 배열로 관리한다. 있으면 true 없으면 false.
    //픽셀이 생성될때 자동으로 true로 바귄다.
    public bool[] sponposes = new bool[sponposesnum];
    public GameObject[] zenposes = new GameObject[sponposesnum]; //생성된 픽셀저장
    private BoxCollider2D[] posesCollider = new BoxCollider2D[sponposesnum];

 // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<sponposesnum;i++)
        {
            posesCollider[i] = zenposes[i].GetComponent<BoxCollider2D>();
        }
    }

    //collision이 아닌 배열과 위치 정보로 해결할거임..ㅠㅠ
    public void SearchSponSpaces(Transform Sponpos) //어떤 obj에 공격했는지 인수로 받고, 그 오브젝트 아래의 스폰포스 위치 불러온다.
    {
        //player와 충돌한 obj의 스폰장소를 배열에 업데이트 한다.
        Transform[] ZenPos = new Transform[4];
        for (int i = 0; i < Sponpos.childCount; i++)
        {
            ZenPos[i] = Sponpos.GetChild(i).transform;
        }

        //배열 탐색: 배열은 게임 오브젝트 형식.
        for (int i = 0; i < ZenPos.Length; i++)
        {
            for (int n = 0; i > zenposes.Length; n++)
            {
                if (ZenPos[i].position.x != zenposes[i].transform.position.x && ZenPos[i].position.y != zenposes[i].transform.position.y)
                {

                }
            }
        }


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

    public void MakePosValTrue(int i)
    {
        sponposes[i] = true;
    }

    private void MakePosValFalse(Collider2D collision)
    {
        switch (collision.name)
        {
            case "Zenpos":
                sponposes[0] = false;
                break;
            case "Zenpos(1)":
                sponposes[1] = false;
                break;
            case "Zenpos(2)":
                sponposes[2] = false;
                break;
            case "Zenpos(3)":
                sponposes[3] = false;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ////꽃에 먼저 충돌을 했는지 확인
        //BoxCollider2D[] poses = new BoxCollider2D[transform.childCount];
        ////부모가 자기 충돌인 줄 알고, 이 메서드를 실행시킨다.
        ////어떤 자식인지 여기서 판별한다.(어감이 좀 이상하네...)
        //UpdatePosInfo(ref poses);
        ////isTouching()메서드를 통해 구현한다.
        

        //for(int i =0;i<transform.childCount;i++)
        //{
        //   if (posesCollider[i].IsTouching(collision) && collision.tag != "Respawn")
        //   {
        //       Debug.Log("Log:Something is already sponed:" + posesCollider[i].name + "/// 충돌체이름:" + collision.name);
        //       MakePosValTrue(i);
        //  }
        //}

        //////트리거가 개수만큼 돌고나면,


        ////Debug.Log("트리거 한번 돔");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
