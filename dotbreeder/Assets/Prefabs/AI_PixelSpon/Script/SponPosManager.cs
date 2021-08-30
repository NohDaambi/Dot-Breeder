using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//information
// ��ǥ ������ �� ����������Ʈ ������Ʈ�� �ٴ´�.


public enum SPAWN_STATE
{
    //���� ������ ���� ACTIVE�� �Ұ����� ������ DELAY�� ������.
    ACTIVE = 667413720,
    DELAY = 1272707897
};

public class SponPosManager : MonoBehaviour
{
    public SPAWN_STATE CurrentState = SPAWN_STATE.ACTIVE;

    private const int sponposesnum = 4; //������ �ʴ� ���̱� ������ const�� ���ȭ ���ش�.
    private bool IsActice = true; //ó������ true�̰� ���ǰ� ������ false.
    private float creat_time = 20.0f; //�ȼ��� �����Ǵ� ������ Ÿ��

    //�ڸ��� ��ü�� �ִ��� ������ �迭�� �����Ѵ�. ������ true ������ false.
    //�ȼ��� �����ɶ� �ڵ����� true�� �ٱϴ�.
    public bool[] sponposes = new bool[sponposesnum];
    public GameObject[] zenposes = new GameObject[sponposesnum]; //������ �ȼ�����


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
                //�ð��� ������Ų��
                ElapsedTime += Time.deltaTime;

                //���������ӱ��� ��ٸ���.
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
