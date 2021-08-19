using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject CombineEnd;
    public GameObject CombineIng;
    public GameObject House;
    public GameObject Player;
    public GameObject Combination;

    public Combination combine;    

    public Slider timerSlider;
    public Text timerText;
    public float combineTIme;
    public float transTime;
    public float timeFlow;
    public float currentTime;
    public float TImeIng;

    public bool isPlus;
    public bool HouseOn;

    //���ճ� UI
    public Text TitleEnd;
    public Image imageEnd;

    //���� �������� �� 1~10���� ���๰ 100���� ���� ���������� �з�
    public int CurrentCombinging;

    public bool isGive = false;
    public bool isOnHouse = false;


    IEnumerator CurrentTime()
    {  
        yield return null;
        currentTime = Time.time;
        timerSlider.maxValue = combineTIme * combine.produceNum;
    }
    void Update()
    {
        TImeIng = Time.time;

        if (combine.isCombining)
        {
            if (currentTime == 0)
                StartCoroutine(CurrentTime());
            else            
                StopCoroutine(CurrentTime());                
            
            timeFlow = (currentTime + combineTIme * combine.produceNum) - Time.time; // 9 8 7 6 5 4 3 2 1

            int min = Mathf.FloorToInt(timeFlow / 60);
            int sec = Mathf.FloorToInt(timeFlow - min * 60);

            string textTIme = string.Format("{0:0}:{1:00}", min, sec);

            CombineEnded();

            timerText.text = textTIme;
            timerSlider.value = combineTIme * combine.produceNum - timeFlow + transTime * combine.produceNum; // 1 2 3 4 5 6 7 8 9 

            if(timeFlow > 0)
                isPlus = true;
        }

        //�� ���� UI�Ⱥ��̰��ϰ�
        if (SceneManager.GetActiveScene().name == "House")
            House.SetActive(false);
        //�� ���ͼ� ���� �� �����ִ��Ŷ�� ����
        else if (HouseOn && SceneManager.GetActiveScene().name == "Forest1")
            House.SetActive(true);

        //�볪�� ��
        if (CurrentCombinging == 1 && isGive)
        {
            HouseOn = true;
            House.SetActive(true);            
            Player.transform.position = new Vector3(5.8f, -4f, -1);
            isGive = false;
        }
        if (SceneManager.GetActiveScene().name == "House")
        {            
            Combination.SetActive(true);
            Combination.transform.position = new Vector3(4.48f, 1.11f, -1);
        }
        if(SceneManager.GetActiveScene().name != "House" && HouseOn)
        {
            Combination.SetActive(false);
        }

        //ħ��
        if (CurrentCombinging == 2 && isOnHouse)
        {
            Debug.Log("ħ�� ��ȯ");
            isOnHouse = false;
        }
        //����
        if (CurrentCombinging == 3 && isOnHouse)
        {
            Debug.Log("���� ��ȯ");
            isOnHouse = false;
        }
        //���̺�
        if (CurrentCombinging == 4 && isOnHouse)
        {
            Debug.Log("���̺� ��ȯ");
            isOnHouse = false;
        }

    }
    public void CombineEnded()
    {
        if (timeFlow <= 0 && isPlus)
        {            
            combine.isCombining = false;
            currentTime = 0;
            transTime = 0;

            //���տϼ� UI
            CombineEnd.SetActive(true);

            TitleEnd.text = combine.TitleIng.text;
            //imageEnd.sprite = combine.imageIng.sprite;

            isPlus = false;
        }
    }
}
