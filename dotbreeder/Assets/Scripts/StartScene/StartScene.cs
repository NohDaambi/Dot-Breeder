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
        //�����ϱ� �̾��ϱ� �˾�â ��Ƽ��
        StartBox.SetActive(true);

        //������ ����� �ִٸ� ������ �ҷ�����
        if (PlayerPrefs.HasKey("PlayerX"))
            ContinueBtn.interactable = true;
        else
            ContinueBtn.interactable = false;


    }

    public void NewGame()
    {
        //��-1 
        SceneManager.LoadScene(1);
    }
    public void ContinueGame()
    {        
        //���尪
        Manager.GameLoad();    
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
