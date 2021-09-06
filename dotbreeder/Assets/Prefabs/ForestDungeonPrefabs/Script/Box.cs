using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Sprite m_SpriteBox;
    public Sprite m_SpriteBoxEnd;
    private SpriteRenderer render;
    public bool m_OnCross;//true if box has been pushed on to a cross

    private void Start()
    {
        this.render = GetComponent<SpriteRenderer>();
        
    }
    private void Update()
    {
        //플레이어 위에 물병이 있으면 플레이어 보다 뒤에 있어보이게끔
        if (this.gameObject.transform.position.y > GameObject.FindWithTag("Player").transform.position.y)
        {
            this.render.sortingOrder = -1;
        }
        else
        {
            this.render.sortingOrder = 1;
        }
    }
    public bool Move(Vector2 direction)//Avoid ability to move diagonally
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            TestForOnCross();
            
            return true;
        }
    }

    bool BoxBlocked(Vector3 position, Vector2 direction)
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

    void TestForOnCross()
    {
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
        foreach (var cross in crosses)
        {
            if (transform.position.x == cross.transform.position.x && transform.position.y == cross.transform.position.y)
            {//On a cross
                GetComponent<SpriteRenderer>().sprite = m_SpriteBoxEnd;
                m_OnCross = true;
                return;
            }
        }
        GetComponent<SpriteRenderer>().sprite = m_SpriteBox;
        m_OnCross = false;
    }
}
