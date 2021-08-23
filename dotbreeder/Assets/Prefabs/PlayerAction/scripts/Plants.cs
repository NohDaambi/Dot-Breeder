using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{


    public PlayerAction player;
    public GameManager manager;

    public GameObject[] Flower;
    public GameObject[] Rock;
    public GameObject[] Box;

    public int Fhealth = 2;
    public int Rhealth = 3;
    public int Bhealth = 2;


    public Animator[] FloAnim = new Animator[6];

    public Animator[] RockAnim = new Animator[6];

    public Animator[] BoxAnim = new Animator[2];

    private static bool PlantExist;

    Animator Anim;
    
    void Awake()
    {
        Anim = GetComponent<Animator>();

        Time.timeScale = 1;
       
    }


    //Flower Destroy
    public void FlowerDestory()
    {
        if (player.scanObject.name == "Flower")
        {
            FlowerDest(0);
        }    
        else if (player.scanObject.name == "Flower1")
        {
            FlowerDest(1);
        }
        else if (player.scanObject.name == "Flower2")
        {
            FlowerDest(2);
        }
        else if (player.scanObject.name == "Flower3")
        {
            FlowerDest(3);
        }
        else if (player.scanObject.name == "Flower4")
        {
            FlowerDest(4);
        }
        else if (player.scanObject.name == "Flower5")
        {
            FlowerDest(5);
        }
  

    }

    //Rock Destory
    public void RockDestory()
    {
        if (player.scanObject.name == "Rock")
        {
            RockDest(0);
        }
        else if (player.scanObject.name == "Rock1")
        {
            RockDest(1);
        }
        else if (player.scanObject.name == "Rock2")
        {
            RockDest(2);
        }
        else if (player.scanObject.name == "Rock3")
        {
            RockDest(3);
        }
        else if (player.scanObject.name == "Rock4")
        {
            RockDest(4);
        }
        else if (player.scanObject.name == "Rock5")
        {
            RockDest(5);
        }
    }

    //Box Destory
    public void BoxDestory()
    {
        if (player.scanObject.name == "Box")
        {
            BoxDest(0);
        }
        if (player.scanObject.name == "Box1")
        {
            BoxDest(1);
        }
    }

    public void FlowerDest(int num)
    {
        Fhealth -= 1;
        if (Fhealth <= 0)
        {
            FloAnim[num].SetTrigger("isDestroy");
            Fhealth = 2;
            manager.Gcount++;
            Destroy(Flower[num], 0.4f);
            
        }
    }


    public void RockDest(int num)
    {
        Rhealth -= 1;
        if (Rhealth <= 0)
        {
            RockAnim[num].SetTrigger("isDestroy");            
            Rhealth = 3;
            manager.Rcount++;
            Destroy(Rock[num], 0.4f);
        }
    }



    public void BoxDest(int num)
    {
        Bhealth -= 1;
        if (Bhealth <= 0)
        {            
            BoxAnim[num].SetTrigger("isDestroy");
            Bhealth = 2;
            manager.Bcount++;            
            Destroy(Box[num], 0.4f);
        }
    }

    }
