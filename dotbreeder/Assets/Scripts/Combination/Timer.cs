using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject CombineEnd;
    public GameObject CombineIng;

    public Combination combine;    

    public Slider timerSlider;
    public Text timerText;
    public float combineTIme;
    public float transTime;
    public float timeFlow;
    public float currentTime;
    public float TImeIng;

    public bool isPlus;

    //조합끝 UI
    public Text TitleEnd;
    public Image imageEnd;

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
            timerSlider.value = combineTIme * combine.produceNum - timeFlow + transTime; // 1 2 3 4 5 6 7 8 9 

            if(timeFlow > 0)
                isPlus = true;
        }
     
    }

    public void CombineEnded()
    {
        if (timeFlow <= 0 && isPlus)
        {            
            combine.isCombining = false;
            currentTime = 0;
            transTime = 0;

            //조합완성 UI
            CombineEnd.SetActive(true);

            TitleEnd.text = combine.TitleIng.text;
            //imageEnd.sprite = combine.imageIng.sprite;

            isPlus = false;
        }
    }
   
}
