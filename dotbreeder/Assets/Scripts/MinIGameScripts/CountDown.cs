using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CountDown : MonoBehaviour
{
    public float setTime = 10;
    public Text countDownText;
    public MiniGame miniGame;
    public GameObject GameOver;
    public GameObject MiniGame;
    public GameManager manger;


    void Awake()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (setTime > 0)
            setTime -= Time.deltaTime;
        else if (setTime <= 0)
        {
            //�ð� ����
            Time.timeScale = 0;
            GameOver.SetActive(true);
            //Ű �Է� ����
            miniGame.isAlive = false;
        }

        countDownText.text = Mathf.Round(setTime).ToString();

    }

    public void Restart()
    {
        InitGame();
    }

    public void Exit()
    {
        MiniGame.SetActive(false);
        InitGame();
        manger.isAction = false;

        //���� �Ҵ�
    }

    public void InitGame()
    {
        setTime = 10;
        //�ð� �帧
        Time.timeScale = 1;

        miniGame.isAlive = true;
        GameOver.SetActive(false);

        miniGame.InputInit();
        miniGame.AnswerInit();
        miniGame.ResultInit();
        miniGame.InputTextInit();
        miniGame.InputIndex = 0;
        miniGame.AnswerIndex = 0;
        miniGame.InputNum = 0;
        miniGame.Score = 0;

        miniGame.InitKey();
    }


}
