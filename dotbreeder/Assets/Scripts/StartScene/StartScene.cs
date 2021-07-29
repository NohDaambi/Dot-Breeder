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
        //저장한 기록이 있다면 저장기록 불러오기
        if (PlayerPrefs.HasKey("PlayerX"))
            Manager.GameLoad();
        else //아니면 걍 숲-1
            SceneManager.LoadScene(1);
    }

    public void GameExit()
    {
        //종료하냐고 팝업창 하나 띄우고
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
