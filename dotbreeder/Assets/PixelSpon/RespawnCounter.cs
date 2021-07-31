using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESPAWN_STATE
{
    //���� ������ ���� ACTIVE��,������ �� ���� Sponed, �Ұ����� ������ DELAY�� ������.
    ACTIVE = 667413720,
    DELAY = 1272707897,
    SPAWNED = 1138053376
};

public class RespawnCounter : MonoBehaviour
{
    public RESPAWN_STATE CurrentState = RESPAWN_STATE.ACTIVE;
    private float creat_time = 3.0f; //ä���ڿ��� �����Ǵ� ������ Ÿ��
    public bool spawned_trigger;
    public bool delay_trigger;
    //���߿� �θ𿡰Լ� ������ �޾� �ڿ����� ������ Ÿ�� �ٸ��� ������ ����

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(State_Actice());
        spawned_trigger = true;
    }

    public IEnumerator State_Actice()
    {
        //Debug.Log("State_Actice()����" + transform.parent.gameObject.name);
        CurrentState = RESPAWN_STATE.ACTIVE;
        GameObject Spawnzone = transform.parent.gameObject; //�θ�ü ��������
        //��ü �迭�� �����ϴ� �θ�ü�� �迭 bool���� false(���� ������ ����)�� �ٲ۴�.
        Spawnzone.GetComponent<SpawnZone>().sponposes[transform.GetSiblingIndex()] = false;
        
        //Active�� �ٲ�� ����, SpawnZone���� ä���ڿ��� ���϶�� ��û�� ������.

        while (CurrentState == RESPAWN_STATE.ACTIVE)
        {
            //Debug.Log("ACIVE_While�� ����" + transform.parent.gameObject.name);
            if (spawned_trigger == true)
            {
                //Debug.Log("StartCoroutine����" + transform.parent.gameObject.name);
                StartCoroutine(State_Sponed());

            }

            yield return null;
        }

        yield return null;
    }

    public IEnumerator State_Sponed()
    {
        //������ �Ǿ �̹� �ڿ��� �ִ� ����
        CurrentState = RESPAWN_STATE.SPAWNED;

        spawned_trigger = false;

        while (CurrentState == RESPAWN_STATE.SPAWNED)
        {
            //�÷��̾ �ڿ��� ȹ���ؼ� �ڿ��� �ش� �ڸ��� ���� ���, delaytrigger�� �ܺο��� true�� �ٲ��.
            if (delay_trigger == true) StartCoroutine(State_Delay());

            yield return null;
        }

        yield return null;
    }

    public IEnumerator State_Delay()
    {
        CurrentState = RESPAWN_STATE.DELAY;
        delay_trigger = false;

        GameObject Spawnzone = transform.parent.gameObject; //�θ�ü ��������
        //��ü �迭�� �����ϴ� �θ�ü�� �迭 bool���� false(���� �Ұ����� ����)�� �ٲ۴�.
        Spawnzone.GetComponent<SpawnZone>().sponposes[Spawnzone.transform.GetSiblingIndex()] = false;

        while (CurrentState == RESPAWN_STATE.DELAY)
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

}
