using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//information
// 좌표 역할을 할 투명스프라이트 오브젝트에 붙는다.


public enum SPAWN_STATE
{
    //스폰 가능한 상태 ACTIVE와 불가능한 상태인 DELAY로 나뉜다.
    ACTIVE = 667413720,
    DELAY = 1272707897
};

public class SponPosManager : MonoBehaviour
{
    public SPAWN_STATE CurrentState = SPAWN_STATE.ACTIVE;

    private const int sponposesnum = 4; //변하지 않는 값이기 때문에 const로 상수화 해준다.
    private bool IsActice = true; //처음에는 true이고 젠되고 나서는 false.
    private float creat_time = 20.0f; //픽셀이 생성되는 딜레이 타임

    //자리에 물체가 있는지 없는지 배열로 관리한다. 있으면 true 없으면 false.
    //픽셀이 생성될때 자동으로 true로 바귄다.
    public bool[] sponposes = new bool[sponposesnum];
    public GameObject[] zenposes = new GameObject[sponposesnum]; //생성된 픽셀저장


    public IEnumerator State_Actice()
    {
        CurrentState = SPAWN_STATE.ACTIVE;

        while (CurrentState == SPAWN_STATE.ACTIVE)
        {
            
        }
        yield return null;
    }

    public IEnumerator State_Delay()
    {
        CurrentState = SPAWN_STATE.DELAY;

        while (CurrentState == SPAWN_STATE.DELAY)
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
