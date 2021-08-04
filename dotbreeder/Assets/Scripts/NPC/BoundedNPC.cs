using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : MonoBehaviour
{
    public enum NpcState
    {
        Idle = 0,   //대기 상태
        Walk        //이동 상태 Walk = 1;
    }
    public NpcState m_NpcState;
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    private bool isMoving;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSeconds;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSeconds;
    private bool isRight;
    private bool isLeft;
    private bool isUp;
    private bool isDown;

    void Start()
    {
        m_NpcState = NpcState.Idle;
        isMoving = false;
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    public void Update()
    {
        if (isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if (moveTimeSeconds <= 0)
            {

                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
            }
            //나중에 플레이어가 말을걸때 이곳에 if(!isPlayerCollision)하나 줘서 멈추면 됨
            Move();
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if (isRight)
            {
                anim.SetBool("DirectRight", true);
            }
            else if (isLeft)
            {
                anim.SetBool("DirectLeft", true);
            }
            else if (isUp)
            {
                anim.SetBool("DirectUp", true);
            }
            else if (isDown)
            {
                anim.SetBool("DirectDown", true);
            }
            if (waitTimeSeconds <= 0)
            {
                if (isRight)
                {
                    anim.SetBool("DirectRight", false);
                }
                else if (isLeft)
                {
                    anim.SetBool("DirectLeft", false);
                }
                else if (isUp)
                {
                    anim.SetBool("DirectUp", false);
                }
                else if (isDown)
                {
                    anim.SetBool("DirectDown", false);
                }
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
            }
        }
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        //Debug.Log(temp);
        if (bounds.bounds.Contains(temp))
        {
            //Debug.Log("범위 안에 있음");
            myRigidbody.MovePosition(temp);
        }
        else
        {
            //Debug.Log("방향바꿈");
            ChangeDirection();
        }
    }

    int ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Walking to the right
                IsRight();
                directionVector = Vector3.right;
                break;
            case 1:
                // Walking up
                IsUp();
                directionVector = Vector3.up;
                break;
            case 2:
                // Walking Left
                IsLeft();
                directionVector = Vector3.left;
                break;
            case 3:
                // Walking down
                IsDown();
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
        return direction;
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDifferentDirection();
    }
    void IsRight()
    {
        isRight = true;
        isLeft = false;
        isUp = false;
        isDown = false;
    }
    void IsLeft()
    {
        isRight = false;
        isLeft = true;
        isUp = false;
        isDown = false;
    }
    void IsUp()
    {
        isRight = false;
        isLeft = false;
        isUp = true;
        isDown = false;
    }
    void IsDown()
    {
        isRight = false;
        isLeft = false;
        isUp = false;
        isDown = true;
    }
}
