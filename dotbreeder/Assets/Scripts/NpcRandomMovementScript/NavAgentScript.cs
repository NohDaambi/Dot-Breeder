using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgentScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D myRigidbody;
    public bool isWalking;
    public float walkTime = 1f;
    private float walkCounter;
    public float waitTime = 3f;
    private float waitCounter;
    private int WalkDirection;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }
    private void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
            switch (WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
