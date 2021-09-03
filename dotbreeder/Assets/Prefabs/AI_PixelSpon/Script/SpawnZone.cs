using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnZone_Feature
{
    DEFAULT = -782300793,
    RANDOM = -1768411145,
    STATIC = -1788026084
};

public class SpawnZone : MonoBehaviour
{
    public SpawnZone_Feature Feature; // 외부 컨포넌트에서 지정해준다.
   
    private GameObject Null;
    public GameObject[] MySponZone;
    public RESPAWN_STATE[] SpawnState; //스폰가능 위치를 관리하는 배열
    //Respawncounter.cs를 지닌 오브젝트를 배열에 넣는다.


    public bool[] sponposes; 

    //생성된 채집 자원을 넣을 부모 오브젝트
    public GameObject Ingredient;

    //[채집자원 프리팹]
    //Map LV.1
    public GameObject flower1; //random
    public GameObject flower2; //random
    public GameObject flower3; //random
    public GameObject grass1; //random
    public GameObject grass2; //random
    public GameObject tree; //static position


    // Start is called before the first frame update
    void Awake()
    {
        //initialize
        MySponZone = new GameObject[transform.childCount];
        SpawnState = new RESPAWN_STATE[transform.childCount];
        sponposes = new bool[transform.childCount]; //기본값= false

        //RespawnCounter 가져오기
        for (int i = 0; i<transform.childCount; i++)
        {
            MySponZone[i] = transform.GetChild(i).gameObject;
             SpawnState[i] = MySponZone[i].GetComponent<RespawnCounter>().CurrentState;
        }
    }


    private void SponResources()
    {
        for(int i = 0; i< transform.childCount;i++)
        {
            if (sponposes[i] == false && SpawnState[i] == RESPAWN_STATE.ACTIVE)   //Avtice상태(false)가 아니면 다음 검색으로 넘어간다.
            {
                //if(sponposes[i] ==true )아래 실행
                //Active상태인 구역에는 채집 자원을 젠 해주어야 함. 위치 값을 받기 위해 transform 가져옴
                Debug.Log("처리중인 sponposes 넘버:" + i);
                Transform activezone = transform.GetChild(i).transform;

                //해당 위치에 채집자원 젠해주기(채집자원은 SpawnZone의 특성에 따라 랜덤일 수도 아닐 수도 있음)
                GameObject resources = Instantiate(RandomResources(), activezone.position, activezone.rotation);
                resources.transform.SetParent(Ingredient.transform, false);
                //스폰이 되었기 때문에 스폰된 상태로 변경해준다.
                activezone.GetComponent<RespawnCounter>().spawned_trigger = true;
                sponposes[i] = true; //채집자원이 생성되었기 때문에 true로 바꾸어 준다.
            }

        }

    }

    private GameObject RandomResources()
    {
        if (Feature != SpawnZone_Feature.RANDOM) return StaticResources();
        //Ransdom Feature일 때만 실행..
        int random = Random.Range(1, 6);
        switch(random)
        {
            case 1:
                return flower1;
            case 2:
                return flower2;
            case 3:
                return flower3;
            case 4:
                return grass1;
            case 5:
                return grass2;

        }
        return Null;
    }

    //Tree는 랜덤이 아닌 고정이다.
    private GameObject StaticResources()
    {
        
        return tree;
    }
    // Update is called once per frame
    void Update()
    {
        //RespawnCounter 가져오기
        for (int i = 0; i < transform.childCount; i++)
        {
            MySponZone[i] = transform.GetChild(i).gameObject;
            SpawnState[i] = MySponZone[i].GetComponent<RespawnCounter>().CurrentState;
        }

        SponResources();
    }
}
