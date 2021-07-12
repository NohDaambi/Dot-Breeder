using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flower의 가능한 상태들을 정의합니다. ( 각 상태는 대문자 문자열에 의해서 해시코드에 대응!)
public enum FLOWER_STATE
{
    IDLE = -1341230092 ,
    DELAY = 1272707897,
    SPON = 1885304928
};

public class FlowerBehaviour : MonoBehaviour
{
    public FLOWER_STATE CurrentState = FLOWER_STATE.IDLE;
    public BoxCollider2D[] SponPoses = new BoxCollider2D[4];
    public GameObject Null;
    public Collider2D Spawned;
    public bool[] CanSpon = new bool[4]; //기본값 = false _ false: 스폰 가능 true: 스폰 불가능
    public bool SponSwitch = false;

    //픽셀 획득 가능한 상태를 의미한다. 플레이어와 상호작용을 하는 즉시 Spon상태로 넘어간다.
    public IEnumerator State_Idle()
    {
        CurrentState = FLOWER_STATE.IDLE;

        while(CurrentState == FLOWER_STATE.IDLE)
        {
            if (SponSwitch == true) StartCoroutine(State_Spon());
        }
        yield return null;
    }

    //픽셀이 획득 된 후 특정 시간 딜레이가 걸린 상태를 의미한다.
    //특정 시간이 흐르면 Idle상태로 넘어간다.
    public IEnumerator State_Delay()
    {
        CurrentState = FLOWER_STATE.DELAY;
        yield return null;
    }

    //플레이어와 상호작용 후 픽셀을 스폰할 위치를 찾고 픽셀을 스폰하는 상태를 의미한다.
    //해당 동작이 끝난 후 Dealy상태로 넘어간다.
    public IEnumerator State_Spon()
    {
        CurrentState = FLOWER_STATE.SPON;

        while (CurrentState == FLOWER_STATE.SPON)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (SponPoses[i].IsTouching(Spawned))
                {
                    Debug.Log("Log:Something is already sponed:" + SponPoses[i].name + "/// 충돌체이름:" + Spawned.name);
                    CanSpon[i] = true;
                }
            }
        }
        yield return null;
    }

    public Transform SearchSpace(Collider2D collision)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (SponPoses[i].IsTouching(collision))
            {
                Debug.Log("Log:Something is already sponed:" +  SponPoses[i].name + "/// 충돌체이름:" + collision.name);
                CanSpon[i] = true;
            }
        }
        return transform;
    }

    public void CheckCollision() //SPonSpace의 Collider을 업데이트 해준다.
    {
        if (CurrentState != FLOWER_STATE.SPON) return;

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject sponpos = transform.GetChild(i).gameObject;
            SponPoses[i]= sponpos.GetComponent<BoxCollider2D>() ; 
        }
    }


    //Flower의 충돌이 있거나 픽셀의 충돌이 있으면 호출되는 함수이다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case("Player"):
                if (CurrentState == FLOWER_STATE.IDLE) SponSwitch = true;
                break;
            case ("Respawn"): //픽셀과 충돌했을 경우
                if (CurrentState != FLOWER_STATE.SPON) break; //상태가 스폰중인 상태가 아니면 충돌값은 처리하지 않는다.
                Spawned = collision; //데이터에 충돌한 콜리션 저장
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //문자열 대응 해시코드.
        Debug.Log("IDLE: " + "IDLE".GetHashCode());
        Debug.Log("DELAY" + "DELAY".GetHashCode());
        Debug.Log("SPON" + "SPON".GetHashCode());
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
    }
}
