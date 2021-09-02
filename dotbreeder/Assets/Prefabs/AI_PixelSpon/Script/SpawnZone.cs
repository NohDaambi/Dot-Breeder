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
    public SpawnZone_Feature Feature; // �ܺ� ������Ʈ���� �������ش�.
   
    private GameObject Null;
    public GameObject[] MySponZone;
    public RESPAWN_STATE[] SpawnState; //�������� ��ġ�� �����ϴ� �迭
    //Respawncounter.cs�� ���� ������Ʈ�� �迭�� �ִ´�.


    public bool[] sponposes; 

    //������ ä�� �ڿ��� ���� �θ� ������Ʈ
    public GameObject Ingredient;

    //[ä���ڿ� ������]
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
        sponposes = new bool[transform.childCount]; //�⺻��= false

        //RespawnCounter ��������
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
            if (sponposes[i] == false && SpawnState[i] == RESPAWN_STATE.ACTIVE)   //Avtice����(false)�� �ƴϸ� ���� �˻����� �Ѿ��.
            {
                //if(sponposes[i] ==true )�Ʒ� ����
                //Active������ �������� ä�� �ڿ��� �� ���־�� ��. ��ġ ���� �ޱ� ���� transform ������
                Debug.Log("ó������ sponposes �ѹ�:" + i);
                Transform activezone = transform.GetChild(i).transform;

                //�ش� ��ġ�� ä���ڿ� �����ֱ�(ä���ڿ��� SpawnZone�� Ư���� ���� ������ ���� �ƴ� ���� ����)
                GameObject resources = Instantiate(RandomResources(), activezone.position, activezone.rotation);
                resources.transform.SetParent(Ingredient.transform, false);
                //������ �Ǿ��� ������ ������ ���·� �������ش�.
                activezone.GetComponent<RespawnCounter>().spawned_trigger = true;
                sponposes[i] = true; //ä���ڿ��� �����Ǿ��� ������ true�� �ٲپ� �ش�.
            }

        }

    }

    private GameObject RandomResources()
    {
        if (Feature != SpawnZone_Feature.RANDOM) return StaticResources();
        //Ransdom Feature�� ���� ����..
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

    //Tree�� ������ �ƴ� �����̴�.
    private GameObject StaticResources()
    {
        
        return tree;
    }
    // Update is called once per frame
    void Update()
    {
        //RespawnCounter ��������
        for (int i = 0; i < transform.childCount; i++)
        {
            MySponZone[i] = transform.GetChild(i).gameObject;
            SpawnState[i] = MySponZone[i].GetComponent<RespawnCounter>().CurrentState;
        }

        SponResources();
    }
}
