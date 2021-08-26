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
            //1������ 1,2,3�� ������ �ر�
            for (int i = 0; i < 3; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[0] = true;
        }
        if (Manager.DotLevel == 2)
        {
            //1������ 4,5,6�� ������ �ر�
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[1] = true;
        }
        if (Manager.DotLevel == 3)
        {
            //2������ 1,2,3�� ������ �ر�
            for (int i = 0; i < 3; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[2] = true;
        }
        if (Manager.DotLevel == 4)
        {
            //2������ 4,5,6�� ������ �ر�
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[3] = true;
        }
        //1������
        if (combine.pageNumItem == 1)
        {
            PageActiveFuncA(0);
            PageActiveFuncB(1);
        }
        //2������
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

        //���๰ 1������
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
        // 2������
        if (combine.pageNumBuilding == 2 && combine.BuildingPage)
        {
            LockBtn[0].SetActive(true);
            LockBtn[1].SetActive(true);
            LockBtn[2].SetActive(true);
            LockBtn[3].SetActive(true);
            LockBtn[4].SetActive(true);
            LockBtn[5].SetActive(true);
        }
        // 3������
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
    //Ȧ�� ����
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
    //¦�� ����
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
    //�ϴ� ��Ʈ ���� ����
    public void LevelUp()
    {
        if(Manager.DotLevel < 4)
            Manager.DotLevel++;        
    }
}
