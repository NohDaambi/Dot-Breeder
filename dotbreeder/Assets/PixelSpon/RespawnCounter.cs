using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESPAWN_STATE
{
    //스폰 가능한 상태 ACTIVE와,스폰이 된 상태 Sponed, 불가능한 상태인 DELAY로 나뉜다.
    ACTIVE = 667413720,
    DELAY = 1272707897,
    SPAWNED = 1138053376
};

public class RespawnCounter : MonoBehaviour
{
    public RESPAWN_STATE CurrentState = RESPAWN_STATE.ACTIVE;
    private float creat_time = 3.0f; //채집자원이 생성되는 딜레이 타임
    public bool spawned_trigger;
    public bool delay_trigger;
    //나중에 부모에게서 정보를 받아 자원마다 딜레이 타임 다르게 구성할 예정

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(State_Actice());
        spawned_trigger = true;
    }

    public IEnumerator State_Actice()
    {
        //Debug.Log("State_Actice()실행" + transform.parent.gameObject.name);
        CurrentState = RESPAWN_STATE.ACTIVE;
        GameObject Spawnzone = transform.parent.gameObject; //부모객체 가져오기
        //전체 배열을 관리하는 부모객체의 배열 bool값을 false(스폰 가능한 상태)로 바꾼다.
        Spawnzone.GetComponent<SpawnZone>().sponposes[transform.GetSiblingIndex()] = false;
        
        //Active로 바뀌는 순간, SpawnZone에게 채집자원을 젠하라고 요청을 보낸다.

        while (CurrentState == RESPAWN_STATE.ACTIVE)
        {
            //Debug.Log("ACIVE_While문 접근" + transform.parent.gameObject.name);
            if (spawned_trigger == true)
            {
                //Debug.Log("StartCoroutine실행" + transform.parent.gameObject.name);
                StartCoroutine(State_Sponed());

            }

            yield return null;
        }

        yield return null;
    }

    public IEnumerator State_Sponed()
    {
        //스폰이 되어서 이미 자원이 있는 상태
        CurrentState = RESPAWN_STATE.SPAWNED;

        spawned_trigger = false;

        while (CurrentState == RESPAWN_STATE.SPAWNED)
        {
            //플레이어가 자원을 획득해서 자원이 해당 자리에 없는 경우, delaytrigger가 외부에서 true로 바뀐다.
            if (delay_trigger == true) StartCoroutine(State_Delay());

            yield return null;
        }

        yield return null;
    }

    public IEnumerator State_Delay()
    {
        CurrentState = RESPAWN_STATE.DELAY;
        delay_trigger = false;

        GameObject Spawnzone = transform.parent.gameObject; //부모객체 가져오기
        //전체 배열을 관리하는 부모객체의 배열 bool값을 false(스폰 불가능한 상태)로 바꾼다.
        Spawnzone.GetComponent<SpawnZone>().sponposes[Spawnzone.transform.GetSiblingIndex()] = false;

        while (CurrentState == RESPAWN_STATE.DELAY)
        {
            float ElapsedTime = 0f;
            while (true)
            {
                //시간을 증가시킨다
                ElapsedTime += Time.deltaTime;

                //다음프레임까지 기다린다.
                yield return null;

                if (ElapsedTime >= creat_time)
                {
                    StartCoroutine(State_Actice());
                    yield break;
                }
            }
        }
        yield return null;
    }

}
