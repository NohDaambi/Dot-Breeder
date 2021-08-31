using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deserttile_PlayerMove : MonoBehaviour
{
    public float Speed = 5.0f;
    public float unMoveTime = 1.0f;

    Rigidbody2D Rigid;
    Animator animator;
    SpriteRenderer spriterenderer;

    float h = 0;
    float v = 0;
    bool isHorizonMove;

    public bool isplayermove = false;

    Vector3 dirVec3;
    GameObject scanObject;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
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
        else
        {
            animator.Play("Player_up_Idle", -1, 0f);
        }
        
    }

    void FixedUpdate()
    {
        if (unMoveTime > 0)
        {
            isplayermove = false;
            unMoveTime -= Time.deltaTime;
            animator.Play("Player_up_Idle", -1, 0f);
            Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
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
            Rigid.constraints = RigidbodyConstraints2D.None;
            Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Road")
        {
            unMoveTime = 3.0f;
            Debug.Log("Fail");
            StartCoroutine("SandFall");
        }
    }

    IEnumerator SandFall()
    {
        float rotationAngley = 0;
        float rotationAnglez = 0;
        int maxrotationAngez = 30;
        //2second
        while (rotationAngley < 1200)
        {
            transform.rotation = Quaternion.Euler(0, rotationAngley, rotationAnglez);
            if (rotationAnglez <= maxrotationAngez && rotationAnglez >= -maxrotationAngez)
            {
                rotationAnglez += 0.1f;
                
            }
            //Wait Update Frame
            yield return new WaitForSeconds(0.01f);
            rotationAngley += 10;
        }
        //End
        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.position = new Vector2(0.5f, -8.0f);
        DesertScript.unVisibleTime = 1.0f;
        StartCoroutine("BlinkingPlayer");
        yield return null;
    }

    IEnumerator BlinkingPlayer()
    {
        int countTime = 0;

        while (countTime < 5)
        {//Alpha Effect
            if (countTime % 2 == 0)
            {
                spriterenderer.color = new Color32(255, 255, 255, 90);
            }
            else
                spriterenderer.color = new Color32(255, 255, 255, 180);
            //Wait Update Frame
            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        //Alpha Effect End
        spriterenderer.color = new Color32(255, 255, 255, 255);
        transform.position = new Vector2(0.5f, -8.0f);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ClearFront")
        {
            Debug.Log("Clear");
            SceneManager.LoadScene("Desert2");
        }
    }
}