using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deserttile_PlayerMove : MonoBehaviour
{
    public float Speed = 5.0f;
    public float unMoveTime = 1.2f;//캐릭터가 움직이기 시작하는 시간
                                   //길 타일이 사라지는 시간(unVisibleTime)과 똑같이 해야함 아니면 0.2f만큼 더 주어야 함.
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
            //키 중복 안되게
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
        //처음 플레이어 위치에 서면 길 보여주는 버그 방지
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
            Debug.Log("클리어");
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            Debug.Log("길을 벗어나 모래 유사로 빠져 처음으로 돌아가짐");
            transform.position = new Vector2(0.5f, -8);
            isplayermove = false;
            //unMoveTime = 1.2f;//처음값과 같이 초기화

            //플레이어가 길을 벗어나면 길을 1초간 보여주게끔
            if (transform.position.x == 0.5f && transform.position.y == -8 && isfirstMove == false)// 값은 후에 변경할 수도 있음
            {
                DesertScript.unVisibleTime = 1.0f;
            }
        }
    }
}