using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public GameObject BarPrefab;

    private GameManager Manager;
    private List<Bar> totalBar;
    private float total = 0;

    int barCounter = 0;

    public class Bar
    {
        public float fill;
        public string name;
        public Image img;
        public Color col;

        
        
        public Bar(float fill, string name, Image img, Color col)
        {
            this.fill = fill;
            this.name = name;
            this.img = img;
            this.col = col;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
       Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

   //GameManager에서 업로드 해주는 함수. 이렇게 안하면 순서 꼬여서 NULLEXEPTION 오류 남!..
    public void BarDataLoad()
    {
       totalBar = new List<Bar>();
       LoadBar();
       barCounter = totalBar.Count;

       Debug.Log("barCounter"+barCounter); // must be 5

       UpadateAllBar();

    }

    private Color SetColor(string name)
    {
        switch(name)
        {
            case "R":
            return Color.red;
            case "G":
            return Color.green;
            case "B":
            return Color.blue;
            case "E":
            return Color.gray;
            default:
              Debug.Log("!Debug:Color default");
              return Color.clear;
        }
    }

    private void LoadBar()
    {
        string R = "R"+','+Manager.totalR.ToString();
        string G = "G"+','+Manager.totalG.ToString();
        string B = "B"+','+Manager.totalB.ToString();
        
        string[] TotalRGB = {R,G,B};

        foreach(string info in TotalRGB)
        {
           string[] values = info.Split(',');

           //Creat the new var and make it a child of our full bar
           GameObject barObj = Instantiate(BarPrefab,transform.position,transform.rotation);
           barObj.transform.SetParent(transform);
           barObj.transform.localScale=transform.localScale;

           barObj.SetActive(false);
           Image img = barObj.GetComponent<Image>();
           float fillVal = 0;

           //We check to see if the value field is in fact a floating-point value
           //If it is not it is just skipped (left out of the total as well)
           bool floating = float.TryParse(values[1], out fillVal);
           if(floating)
         {
                string name = values[0];
                //Radomly selected color
                //NO RANDOM : R: RED / G:GREEN / B:BLUE / E:GRAY OR WHITE
                //return color function
                //Color col = new Color(UnityEngine.Random.Range(0.0f, 1f), UnityEngine.Random.Range(0.0f, 1f),UnityEngine.Random.Range(0.0f, 1f));
                Color col = SetColor(name);
                Bar bar = new Bar(fillVal, name, img, col);
                img.color = col;

                total += fillVal;
                totalBar.Add(bar);  
          }
        }

    }

    private void UpadateAllBar()
    {
        //PrevZ is the Z rotation of the previous wedge, We need to store this information to calculate the z rotation
        //of the next wedge.

        float prevY = 0;

        //Looping in reverse here, try to understand why we need to loop in reverse. Try looping normally and
        //see what happens.

        //piewedges.Count must be 5. It means the length of array.
        //SO, If you want to check it out as index. You have to minus 1 from total. Because Index is start with no.0
        for(int i = totalBar.Count-1; i>=0;i--)
        {
            //int i = piewedges.Count -1( =4 / 0,1,2,3,4 => total 5 values in it)
            prevY = UpdateSpecificBar(i,prevY);
        }
    }

    //total pixel 개수에 따른 개별 바 생성
    private float UpdateSpecificBar(int BarIndex, float prevy = 0)
    {
       Bar bar = totalBar[BarIndex];
       float yHor = _HorizonCalculator(prevy, bar.fill);
       prevy = yHor;
       bar.img.fillAmount = bar.fill/total;
       bar.img.transform.SetAsFirstSibling();

       bar.img.gameObject.SetActive(true);

       return prevy;
    }

    private float _HorizonCalculator(float prevY, float fillAmount)
    {
        return(fillAmount / ((float)(total)))+prevY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
