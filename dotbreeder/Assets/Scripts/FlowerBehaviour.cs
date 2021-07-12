using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flower�� ������ ���µ��� �����մϴ�. ( �� ���´� �빮�� ���ڿ��� ���ؼ� �ؽ��ڵ忡 ����!)
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
    public bool[] CanSpon = new bool[4]; //�⺻�� = false _ false: ���� ���� true: ���� �Ұ���
    public bool SponSwitch = false;

    //�ȼ� ȹ�� ������ ���¸� �ǹ��Ѵ�. �÷��̾�� ��ȣ�ۿ��� �ϴ� ��� Spon���·� �Ѿ��.
    public IEnumerator State_Idle()
    {
        CurrentState = FLOWER_STATE.IDLE;

        while(CurrentState == FLOWER_STATE.IDLE)
        {
            if (SponSwitch == true) StartCoroutine(State_Spon());
        }
        yield return null;
    }

    //�ȼ��� ȹ�� �� �� Ư�� �ð� �����̰� �ɸ� ���¸� �ǹ��Ѵ�.
    //Ư�� �ð��� �帣�� Idle���·� �Ѿ��.
    public IEnumerator State_Delay()
    {
        CurrentState = FLOWER_STATE.DELAY;
        yield return null;
    }

    //�÷��̾�� ��ȣ�ۿ� �� �ȼ��� ������ ��ġ�� ã�� �ȼ��� �����ϴ� ���¸� �ǹ��Ѵ�.
    //�ش� ������ ���� �� Dealy���·� �Ѿ��.
    public IEnumerator State_Spon()
    {
        CurrentState = FLOWER_STATE.SPON;

        while (CurrentState == FLOWER_STATE.SPON)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (SponPoses[i].IsTouching(Spawned))
                {
                    Debug.Log("Log:Something is already sponed:" + SponPoses[i].name + "/// �浹ü�̸�:" + Spawned.name);
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
                Debug.Log("Log:Something is already sponed:" +  SponPoses[i].name + "/// �浹ü�̸�:" + collision.name);
                CanSpon[i] = true;
            }
        }
        return transform;
    }

    public void CheckCollision() //SPonSpace�� Collider�� ������Ʈ ���ش�.
    {
        if (CurrentState != FLOWER_STATE.SPON) return;

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject sponpos = transform.GetChild(i).gameObject;
            SponPoses[i]= sponpos.GetComponent<BoxCollider2D>() ; 
        }
    }


    //Flower�� �浹�� �ְų� �ȼ��� �浹�� ������ ȣ��Ǵ� �Լ��̴�.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case("Player"):
                if (CurrentState == FLOWER_STATE.IDLE) SponSwitch = true;
                break;
            case ("Respawn"): //�ȼ��� �浹���� ���
                if (CurrentState != FLOWER_STATE.SPON) break; //���°� �������� ���°� �ƴϸ� �浹���� ó������ �ʴ´�.
                Spawned = collision; //�����Ϳ� �浹�� �ݸ��� ����
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //���ڿ� ���� �ؽ��ڵ�.
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
