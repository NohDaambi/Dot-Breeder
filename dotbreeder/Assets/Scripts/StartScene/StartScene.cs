using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public GameManager Manager;

    public GameObject ExitBox;
    public GameObject DiaryBox;
    public GameObject StartBox;

    public Button ContinueBtn;

    public 

    void Update()
    {
        if(ExitBox.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ExitBox.SetActive(false);
        }
        if (StartBox.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                StartBox.SetActive(false);
        }
    }


    public void GameStart()
    {
        //새로하기 이어하기 팝업창 액티브
        StartBox.SetActive(true);

        //저장한 기록이 있다면 저장기록 불러오기
        if (PlayerPrefs.HasKey("PlayerX"))
            ContinueBtn.interactable = true;
        else
            ContinueBtn.interactable = false;


    }

    public void NewGame()
    {
        //숲-1 
        SceneManager.LoadScene(1);
    }
    public void ContinueGame()
    {        
        //저장값
        Manager.GameLoad();    
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
