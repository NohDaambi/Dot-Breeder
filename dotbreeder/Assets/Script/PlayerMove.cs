using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5.0f;

    Rigidbody2D Rigid;
    Animator anim;

    float h = 0;
    float v = 0;
    bool isHorizonMove;
    Vector3 dirVec3;
    GameObject scanObject;

    public bool isWallTouch = false;
    public bool isfirst = true;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (scanObject != null)//기둥에 부딪혔을 때는 멈추고 이동할수있게끔
        {
            Debug.Log("기둥 충돌");
            isWallTouch = true;
        }
        if (scanObject == null)//기둥에 부딪히지 않았을 때 계속이동하게끔
        {
            isWallTouch = false;
        }

        if (isWallTouch == true || isfirst == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isfirst = false;
                isWallTouch = false;
                h = 1;
                v = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isfirst = false;
                isWallTouch = false;
                h = -1;
                v = 0;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isfirst = false;
                isWallTouch = false;
                h = 0;
                v = 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isfirst = false;
                isWallTouch = false;
                h = 0;
                v = -1;
            }
        }
        if (isWallTouch == true)
        {
            Rigid.velocity = Vector2.zero;
            Debug.Log("멈춤");
        }

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

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

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

    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = new Vector2(h, v);
        Rigid.velocity = moveVec * Speed;


        //Ray
        Debug.DrawRay(Rigid.position, dirVec3 * 0.7f, new Color(0, 1, 0));
        //기둥을 감지하고 scanObject에 넣는다.
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
            h = 0;
            v = 0;
        }
    }
}