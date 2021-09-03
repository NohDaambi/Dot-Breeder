using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ȼ������� ���� Ŭ�����̴�. �ȼ����� ��������Ʈ�� ����, ���������� ���¿� ����Ǿ��ִ�.
//<���>
//1. �÷��̾�� �浹�� �̹��� ������� �����͵� �Ҹ�(0)
//2. �浹 �� �÷��̾�� �޼����� ������. �ȼ����� �����϶��.(0)
//3. �������� Ư���ð��� �Ǿ��µ��� �浹�� ���ٸ� �ڵ� �Ҹ��Ѵ�.(0)

public enum PIXEL_STATE
{
    IDLE = -1341230092, //�⺻����
    DELAY = 1272707897, // Ư���ð��� ������ DESTROY���·� �ٲ��
    DESTROY = 1254594080, // DESTROY���¿����� ��ü�� �Ҹ��Ű�� �迭bool���� true�� �ٲ۴�.
};

public class PixelpieceController : MonoBehaviour
{
    public PIXEL_STATE CurrentState = PIXEL_STATE.IDLE;
    public GameObject SponPose;
    private float stay_time = 10.0f; //���̵�
    public bool posetrigger = false;
    public int sponindex;

    void Start()
    {
        //������ ���ĺ��� ī��Ʈ ����. �ϴ��� 7�ʵڿ� �÷��̾ ������ ���� ������ �Ҹ�.
        Destroy(gameObject, 7f);

        //corutine ������� �ذ�
        //������ ���Ŀ��� DELAY���·� ��ȯ��.(time count)
        StartCoroutine(State_Delay());

        //�����Ǹ鼭 �ڽ��� ��ġ�� �����Ѵ�.
        //��ġ���� ���ΰ�, ZenPos�� �浹�� �̿��� �˾Ƴ���. �浹�� tag�� ���ؼ� Ư�� ��ü������ �浹�� �����ϵ��� �����Ѵ�.

    }

   public void Destroy_Pixel()
   {
       Debug.Log("[!]Player-Coin Interaction");
       Destroy(gameObject);//�ڱ� �ڽ� ����!
   }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //�÷��̾ �ȼ��� �����Ҷ��� ��Ȳ �Ǵ�.
        if (other.tag == "Player") //�±װ� �÷��̾����� Ȯ��
        {
            //PlayerMove�� �÷��̾� ������ ��ũ��Ʈ �Դϴ�.���Ƿ� �����صаŶ� playercontroller�� �̸� �ٲܰԿ�!
            PlayerMove playerController = other.GetComponent<PlayerMove>();

            //�������κ���  PlayerController������Ʈ�� �������µ� �����ߴٸ�
            if (playerController != null) 
            {
                //playerController.GetPixel(GameObject); �޼��� ����: �÷��̾�� ȹ���� �ȼ��� ������ ������.
                //Debug.Log("ȹ���� �ȼ�->�÷��̾� ���� ���� �Ϸ�");
                Debug.Log("ȹ���� �ȼ�->�÷��̾� ���� ���� ��û");
                //�����ϱ��� ��ġ�� �������°Ŵϱ� �޸𸮵� ���� ��û �ٸ� ��ũ��Ʈ�� ������.
                Destroy(gameObject);//�ڱ� �ڽ� ����!
            }
        }
       
        //������ ��ġ�� ������ �ѹ��� ���������� �Ѵ�.
        if(other.tag == "Untagged" && posetrigger == false)
        {
           //�浹�� ��ġ�� �θ������Ʈ�� ���° �ڽ����� ����(�׷����� �迭 ���� ����)
            sponindex = other.GetComponent<Transform>().GetSiblingIndex();
            //�浹�� ��ġ�� �θ������Ʈ ����(�θ������Ʈ�� ��ũ��Ʈ�� �پ�����)
            SponPose = other.GetComponent<Transform>().parent.gameObject;

            
            //�� �۾��� ������ �� �ѹ��� ����Ǿ�� �ϹǷ�, Ʈ���Ÿ� ���� �����Ѵ�.
            posetrigger = true;
        }
    }

    public IEnumerator State_Idle()
    {
        CurrentState = PIXEL_STATE.IDLE;

        yield return null;
    }

    public IEnumerator State_Delay()
    {
        CurrentState = PIXEL_STATE.DELAY;

        while (CurrentState == PIXEL_STATE.DELAY)
        {
            // �ð� �ʰ� ��� ����
            float ElapsedTime = 0f;
            while (true)
            {
                //�ð��� ������Ų��
                ElapsedTime += Time.deltaTime;

                //���������ӱ��� ��ٸ���.
                yield return null;

                if (ElapsedTime >= stay_time)
                {
                    StartCoroutine(State_Destroy());
                    yield break;
                }
            }
        }

        yield return null;
    }

    //�ڷ�ƾ ���������� �ѹ� ������ �ٷ� ��ü�� �����ȴ�.
    public IEnumerator State_Destroy()
    {
        CurrentState = PIXEL_STATE.DESTROY;

        //1. � ��ġ���� ���� �Ǿ��°�?   V
        //2. �� ��ġ�� �ε����� �����ΰ�?  V _1,2���� OnTrigger�ż��忡�� �Ǵ�.
        //3. �迭���� false�� �ٲ��ش�.  V

        //SponPos ������Ʈ�� �ִ� ��ũ��Ʈ�� ���� ��, �ش� ��ü���ΰ� ����� �迭���� bool�� ����.
        //false�� �ڸ��� ��ü�� ���ٴ� ��!
        SponPose.GetComponent<SponPosManager>().sponposes[sponindex] = false;

        //��ü ����
        Destroy(gameObject);
        yield return null;
    }

}
