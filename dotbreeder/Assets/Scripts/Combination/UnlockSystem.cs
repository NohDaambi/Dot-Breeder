using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSystem : MonoBehaviour
{
    public Combination combine;

    public GameObject[] LockBtn = new GameObject[6];

    public int DotLevel;
    public bool[] pageActive = new bool[4];


    void Update()
    {
        if(DotLevel == 1)
        {
            //1������ 1,2,3�� ������ �ر�
            for (int i = 0; i < 3; i++)
            {
                LockBtn[i].SetActive(false);
            }

            pageActive[0] = true;
          
        }
        if (DotLevel == 2)
        {
            //1������ 4,5,6�� ������ �ر�
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[1] = true;
        }
        if (DotLevel == 3)
        {
            //2������ 1,2,3�� ������ �ر�
            for (int i = 0; i < 3; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[2] = true;
        }
        if (DotLevel == 4)
        {
            //2������ 4,5,6�� ������ �ر�
            for (int i = 3; i < 6; i++)
            {
                LockBtn[i].SetActive(false);
            }
            pageActive[3] = true;
        }
        //1������
        if (combine.pageNum == 1)
        {
            PageActiveFuncA(0);
            PageActiveFuncB(1);
        }
        //2������
        else if (combine.pageNum == 2)
        {
            PageActiveFuncA(2);
            PageActiveFuncB(3);
        }
        //3������
        else if (combine.pageNum == 3)
        {
            if(DotLevel == 1)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(true);
                LockBtn[2].SetActive(true);
                LockBtn[3].SetActive(true);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
            if (DotLevel == 2)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(false);
                LockBtn[2].SetActive(true);
                LockBtn[3].SetActive(true);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
            if (DotLevel == 3)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(false);
                LockBtn[2].SetActive(false);
                LockBtn[3].SetActive(true);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
            if (DotLevel == 4)
            {
                LockBtn[0].SetActive(false);
                LockBtn[1].SetActive(false);
                LockBtn[2].SetActive(false);
                LockBtn[3].SetActive(false);
                LockBtn[4].SetActive(true);
                LockBtn[5].SetActive(true);
            }
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
        if(DotLevel < 4)
            DotLevel++;
    }
}
