using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deserttile_PlayerMove : MonoBehaviour
{
    public float Speed = 5.0f;
    public float unMoveTime = 1.2f;//ĳ���Ͱ� �����̱� �����ϴ� �ð�
                                   //�� Ÿ���� ������� �ð�(unVisibleTime)�� �Ȱ��� �ؾ��� �ƴϸ� 0.2f��ŭ �� �־�� ��.
    Rigidbody2D Rigid;
    Animator animator;

    float h = 0;
    float v = 0;
    bool isHorizonMove;
    bool isfirstMove = true;
    bool isplayermove = false;
    Vector3 dirVec3;
    GameObject scanObject;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isplayermove == true)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            //Check Button Down & Up
            bool hDown = Input.GetButtonDown("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vUp = Input.GetButtonUp("Vertical");
            //Check Horizontal Move
            //Ű �ߺ� �ȵǰ�
            if (hDown)
            {
                isHorizonMove = true;
            }
            else if (vDown)
            {
                isHorizonMove = false;
            }
            else if (vUp || hUp)
            {
                isHorizonMove = h != 0;
            }

            //Raycast Direction
            if (vDown && v == 1)
            {
                dirVec3 = Vector3.up;
            }
            else if (vDown && v == -1)
            {
                dirVec3 = Vector3.down;
            }
            else if (hDown && h == 1)
            {
                dirVec3 = Vector3.right;
            }
            else if (hDown && h == -1)
            {
                dirVec3 = Vector3.left;
            }
        }
        //ó�� �÷��̾� ��ġ�� ���� �� �����ִ� ���� ����
        if (h == 1 || v == 1)
        {
            isfirstMove = false;
        }
        
    }

    void FixedUpdate()
    {
        if (unMoveTime > 0)
        {
            unMoveTime -= Time.deltaTime;
            h = 0;
            v = 0;
        }
        else
        {
            //Move
            Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
            Rigid.velocity = moveVec * Speed;

            //Animation
            if (animator.GetInteger("hAxisRaw") != h)
            {
                animator.SetBool("isChange", true);
                animator.SetInteger("hAxisRaw", (int)h);
            }
            else if (animator.GetInteger("vAxisRaw") != v)
            {
                animator.SetBool("isChange", true);
                animator.SetInteger("vAxisRaw", (int)v);
            }
            else
                animator.SetBool("isChange", false);
            isplayermove = true;
        }

        

        //Ray
        Debug.DrawRay(Rigid.position, dirVec3 * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(Rigid.position, dirVec3, 0.7f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ClearFront")
        {
            Debug.Log("Ŭ����");
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            Debug.Log("���� ��� �� ����� ���� ó������ ���ư���");
            transform.position = new Vector2(0.5f, -8);
            isplayermove = false;
            //unMoveTime = 1.2f;//ó������ ���� �ʱ�ȭ

            //�÷��̾ ���� ����� ���� 1�ʰ� �����ְԲ�
            if (transform.position.x == 0.5f && transform.position.y == -8 && isfirstMove == false)// ���� �Ŀ� ������ ���� ����
            {
                DesertScript.unVisibleTime = 1.0f;
            }
        }
    }
}