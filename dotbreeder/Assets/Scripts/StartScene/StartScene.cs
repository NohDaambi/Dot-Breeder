using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameManager Manager;

    public GameObject ExitBox;
    public GameObject DiaryBox;

    void Update()
    {
        if(ExitBox.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ExitBox.SetActive(false);
        }
    }


    public void GameStart()
    {
        //������ ����� �ִٸ� ������ �ҷ�����
        if (PlayerPrefs.HasKey("PlayerX"))
            Manager.GameLoad();
        else //�ƴϸ� �� ��-1
            SceneManager.LoadScene(1);
    }

    public void GameExit()
    {
        //�����ϳİ� �˾�â �ϳ� ����
        ExitBox.SetActive(true);      
    }

    public void ExitYes()
    {
        Application.Quit();
    }
    public void ExitNo()
    {
        ExitBox.SetActive(false);
    }

    public void Diary()
    {
        DiaryBox.SetActive(true);
    }



}
