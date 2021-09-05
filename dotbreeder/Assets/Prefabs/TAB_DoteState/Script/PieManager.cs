using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine;

public class PieManager : MonoBehaviour
{
    public DoteStateManager DoteStateManager;
    private GameManager Manager;
    private List<Wedge> pieWedges;
    public GameObject wedgePrefab;
    public Transform TotalPixelRate;
    //public GameObject legendItemPrefab;

    public bool LoadSlow = false;

    private float total = 0;

    int wedgeCounter = 0;

    public class Wedge
    {
        public float fill;
        public string name;
        public Image img;
        public Color col;
        
        public Wedge(float fill, string name, Image img, Color col)
        {
            this.fill = fill;
            this.name = name;
            this.img = img;
            this.col = col;

        }
    }
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


     //픽셀을 사용하거나, 획득하면 이 함수로 업데이트 해줘야 한다.
    public void PixelDataLoad()
    {
       pieWedges = new List<Wedge>();
       LoadWedge();
       wedgeCounter = pieWedges.Count;

        //Debug
       //Debug.Log("WedgeCounter"+wedgeCounter); // must be 5

       if(LoadSlow)
        StartCoroutine(SlowLoadPieChart(1,0));
       else{
        UpadateAllWedges();
       }

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
    
    //플레이어가 모아야 할 픽셀 개수를 계산한다.
    private int CheckRemaining(int R,int G, int B)
    {
       int goal = DoteStateManager.GetGoalOfPixel((int)GROWTH_CONDITION.TOTAL_PIXEL);
       int remaining= goal - (R+G+B);
       if(remaining>0) return remaining;
       return 0; 
    }

    private void LoadWedge()
    {
        //newArray = 2d array
        //[R , 10]
        //[G , 20]
        //[B , 30]
        string R = "R"+','+Manager.Rcount.ToString();
        string G = "G"+','+Manager.Gcount.ToString();
        string B = "B"+','+Manager.Bcount.ToString();
        string E = "E"+','+CheckRemaining(Manager.Rcount,Manager.Gcount, Manager.Bcount).ToString();

        string[] RGBData = {R,G,B,E};


        var RGBArray = new string[4]; 

        int indexcount=0;
        float totalRate =0;
        foreach(string info in RGBData)
        {
    
            string[] values = info.Split(',');
   
            
            indexcount++;
            if(indexcount<=3) totalRate += float.Parse(values[1]);
            else
            {
              TotalPixelRate.GetComponentInChildren<Text>().text= totalRate.ToString();
            }
         

            //Creat the new wedge and make it a child of our full circle
            GameObject wedgeObj = Instantiate(wedgePrefab);
            wedgeObj.transform.SetParent(transform);
            wedgeObj.transform.localScale=transform.localScale;

            //Reset the position, because instantiated objects tend to get random positions for some reason
            wedgeObj.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
            wedgeObj.SetActive(false);
            Image img = wedgeObj.GetComponent<Image>();
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
                Wedge wedge = new Wedge(fillVal, name, img, col);
                img.color = col;

                total += fillVal;
                pieWedges.Add(wedge);

     
            }
        }

    }

    private void UpadateAllWedges()
    {
        //PrevZ is the Z rotation of the previous wedge, We need to store this information to calculate the z rotation
        //of the next wedge.

        float prevZ = 0;

        //Looping in reverse here, try to understand why we need to loop in reverse. Try looping normally and
        //see what happens.

        //piewedges.Count must be 5. It means the length of array.
        //SO, If you want to check it out as index. You have to minus 1 from total. Because Index is start with no.0
        for(int i = pieWedges.Count -1; i>=0;i--)
        {
            //int i = piewedges.Count -1( =4 / 0,1,2,3,4 => total 5 values in it)
            prevZ = UpadateSpecificWedge(i,prevZ);
        }
    }

    private float UpadateSpecificWedge(int WedgeIndex, float prevz = 0)
    {
        Wedge wedge = pieWedges[WedgeIndex];
        float zRot = _ZRotCalculator(prevz, wedge.fill);
        prevz = zRot;
        Vector3 rot = wedge.img.transform.eulerAngles;
        rot.z += zRot;
        wedge.img.transform.eulerAngles =rot;

        wedge.img.fillAmount = wedge.fill / total;
        //Text txt = wedge.img.GetComponentInChildren<Text>();
        wedge.img.transform.SetAsFirstSibling();

        //The Text gets flipped whend the rotatin is greater than 90 degrees;
        //so we flip it again to make it normal
        if(zRot > 90)
        {
            //Vector3 rotation = txt.transform.localEulerAngles;
            //rotation.z *= -1;
            //txt.transform.localEulerAngles = rotation;
        }

        //txt.text = (wedge.img.fillAmount*total).ToString();
        //txt.color = wedge.col;
        wedge.img.gameObject.SetActive(true);
        return prevz;
    }

    private IEnumerator SlowLoadPieChart(int waitTime, float prevZ)
    {
      if(wedgeCounter < 0)
        yield break;
    
      yield return new WaitForSeconds(waitTime);
      prevZ = UpadateSpecificWedge(wedgeCounter, prevZ);
      wedgeCounter--;
      StartCoroutine(SlowLoadPieChart(waitTime,prevZ));

    }

    //This formula gives is our next ZRotatin based on the previous ZRotatin of the previous Wedge, and based
    //on the fillAmount of our current Wedge
    //Basically we need to turn a decimaal amount into angles since the fill value for the wedge is between 0 and 1
    //Therefor 0.25 is 90 dgress, 0.5 is 180 degrees, and so forth.

    private float _ZRotCalculator(float prevZ, float fillAmount)
    {
        return(360*(fillAmount / ((float)(total))))+prevZ;
    }

}
