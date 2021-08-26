using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSystem : MonoBehaviour
{
    public Combination combine;
    public GameManager Manager;

    public GameObject[] LockBtn = new GameObject[6];

    public bool[] pageActive = new bool[4];

    void Update()
    {
        if(Manager.DotLevel == 1)
        {
            //1페이지 1,2,3번 아이템 해금
            for (int i = 0; i < 3; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[0] = true;
        }
        if (Manager.DotLevel == 2)
        {
            //1페이지 4,5,6번 아이템 해금
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[1] = true;
        }
        if (Manager.DotLevel == 3)
        {
            //2페이지 1,2,3번 아이템 해금
            for (int i = 0; i < 3; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[2] = true;
        }
        if (Manager.DotLevel == 4)
        {
            //2페이지 4,5,6번 아이템 해금
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[3] = true;
        }
        //1페이지
        if (combine.pageNumItem == 1)
        {
            PageActiveFuncA(0);
            PageActiveFuncB(1);
        }
        //2페이지
        else if (combine.pageNumItem == 2)
        {
            PageActiveFuncA(2);
            PageActiveFuncB(3);
        }
        else if (combine.pageNumItem == 3)
        {
            LockBtn[0].SetActive(true);
            LockBtn[1].SetActive(true);
            LockBtn[2].SetActive(true);
            LockBtn[3].SetActive(true);
            LockBtn[4].SetActive(true);
            LockBtn[5].SetActive(true);
        }

        //건축물 1페이지
        if (combine.pageNumBuilding == 1 && combine.BuildingPage)
        {
            if(Manager.DotLevel == 1)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(true);
                LockBtn[2].SetActive(true);
                LockBtn[3].SetActive(true);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
            if (Manager.DotLevel == 2)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(false);
                LockBtn[2].SetActive(true);
                LockBtn[3].SetActive(true);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
            if (Manager.DotLevel == 3)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(false);
                LockBtn[2].SetActive(false);
                LockBtn[3].SetActive(true);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
            if (Manager.DotLevel == 4)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(false);
                LockBtn[2].SetActive(false);
                LockBtn[3].SetActive(false);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
        }
        // 2페이지
        if (combine.pageNumBuilding == 2 && combine.BuildingPage)
        {
            LockBtn[0].SetActive(true);
            LockBtn[1].SetActive(true);
            LockBtn[2].SetActive(true);
            LockBtn[3].SetActive(true);
            LockBtn[4].SetActive(true);
            LockBtn[5].SetActive(true);
        }
        // 3페이지
        if (combine.pageNumBuilding == 3 && combine.BuildingPage)
        {
            LockBtn[0].SetActive(true);
            LockBtn[1].SetActive(true);
            LockBtn[2].SetActive(true);
            LockBtn[3].SetActive(true);
            LockBtn[4].SetActive(true);
            LockBtn[5].SetActive(true);
        }

    }
    //홀수 레벨
    public void PageActiveFuncA(int num)
    {        
            if (pageActive[num])
            {
                for (int i = 0; i < 3; i++)
                {
                    LockBtn[i].SetActive(false);
                }
            }
            else if (!pageActive[num])
            {
                for (int i = 0; i < 3; i++)
                {
                    LockBtn[i].SetActive(true);
                }
            }
    }
    //짝수 레벨
    public void PageActiveFuncB(int num)
    {
        if (pageActive[num])
        {
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(false);
            }
        }
        else if (!pageActive[num])
        {
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(true);
            }
        }
    }
    //일단 도트 성장 예시
    public void LevelUp()
    {
        if(Manager.DotLevel < 4)
            Manager.DotLevel++;        
    }
}
