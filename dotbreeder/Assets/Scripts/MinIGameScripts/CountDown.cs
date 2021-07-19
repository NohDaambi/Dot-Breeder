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
        //�ð� �帧
        Time.timeScale = 1;

        SceneManager.LoadScene("MiniGame");        
    }

    public void Exit()
    {
        //manger.isAction = false;
        GameOver.SetActive(false);

        if (!PlayerPrefs.HasKey("SceneNum"))
            return;

        int ScNum = PlayerPrefs.GetInt("SceneNum");
        
        //�� ��ȣ ����Ǿ��ִ� ������ �̵���Ű��
        SceneManager.LoadScene(ScNum);

    }



}
