using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    float h;
    float v;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(!ForestDungeonManager.isDelay)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                h = 1;
                v = 0;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                h = -1;
                v = 0;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                h = 0;
                v = 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                h = 0;
                v = -1;
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
            {
                anim.SetBool("isChange", false);
            }
        }
        
    }
    public bool Move(Vector2 direction)
    {
        //Debug.Log("Player is moving");
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        if (Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
