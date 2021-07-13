using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ȼ������� ���� Ŭ�����̴�. �ȼ����� ��������Ʈ�� ����, ���������� ���¿� ����Ǿ��ִ�.
//<���>
//1. �÷��̾�� �浹�� �̹��� ������� �����͵� �Ҹ�(0)
//2. �浹 �� �÷��̾�� �޼����� ������. �ȼ����� �����϶��.(0)
//3. �������� Ư���ð��� �Ǿ��µ��� �浹�� ���ٸ� �ڵ� �Ҹ��Ѵ�.(0)
public class PixelpieceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������ ���ĺ��� ī��Ʈ ����. �ϴ��� 7�ʵڿ� �÷��̾ ������ ���� ������ �Ҹ�.
        Destroy(gameObject, 7f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        //else
          //  Debug.Log("not collision with pixel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
