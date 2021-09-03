using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DropTextBox : MonoBehaviour
{
    public GameObject[] DropBox = new GameObject[4];

    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;

    public Animator Anim1;
    public Animator Anim2;
    public Animator Anim3;
    public Animator Anim4;

    RectTransform Pos;

    public int num = 0;
    public bool Rotate;

    public Image[] RGBarr = new Image[3]; // 이미지 값 0 : R ,1 : G ,2 : B
    public Image[] RGBImgArr = new Image[4]; // 이미지 UI

    public void Start()
    {
        Pos = GetComponent<RectTransform>();
    }
   
    public void DropPixel(string name, int RandomCount)
    {
        //num = 0
        if (!Rotate && num == 0 && !DropBox[0].activeSelf)
        {
            Num0(name, RandomCount);
            Invoke("TextBoxDestroy0", 5f);
        }
        //회전했으면
        else if(Rotate && num == 0 && DropBox[0].activeSelf)
        {
            CancelInvoke("TextBoxDestroy0");
            DropBox[0].SetActive(false);
            Num0(name, RandomCount);
            Invoke("TextBoxDestroy0", 5f);
        }

        //num = 1
        if(num == 1  && !DropBox[1].activeSelf && DropBox[0].activeSelf)          
        {            
            Num1(name, RandomCount);
            Invoke("TextBoxDestroy1", 5f);
        }
        else if (Rotate && num == 1 && DropBox[1].activeSelf && DropBox[0].activeSelf)
        {
            CancelInvoke("TextBoxDestroy1");
            DropBox[1].SetActive(false);
            Num1(name, RandomCount);
            Invoke("TextBoxDestroy1", 5f);
        }

        //num = 2
        if (num == 2 && !DropBox[2].activeSelf && DropBox[1].activeSelf)             
        {
            Num2(name, RandomCount);
            Invoke("TextBoxDestroy2", 5f);
        }
        else if (Rotate && num == 2 && DropBox[2].activeSelf && DropBox[1].activeSelf)
        {
            CancelInvoke("TextBoxDestroy2");
            DropBox[2].SetActive(false); 
            Num2(name, RandomCount);
            Invoke("TextBoxDestroy2", 5f);
        }

        if (num == 3 && !DropBox[3].activeSelf && DropBox[2].activeSelf)           
        {
            Num3(name, RandomCount);
            Invoke("TextBoxDestroy3", 5f);
        }
        else if (Rotate && num == 3 && DropBox[3].activeSelf && DropBox[2].activeSelf)
        {
            CancelInvoke("TextBoxDestroy3");
            DropBox[3].SetActive(false);
            Num3(name, RandomCount);
            Invoke("TextBoxDestroy3", 5f);
        }

        num++;

        //회전 할 때
        if (num >= 4 && DropBox[0].activeSelf && DropBox[1].activeSelf
                     && DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            Rotate = true;
            num = 0;
        }
        else if (num >= 4 && !DropBox[0].activeSelf && DropBox[1].activeSelf
                    && DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            Rotate = false;
            num = 0;
        }
        else if (num >= 4 && !DropBox[0].activeSelf && !DropBox[1].activeSelf
                    && DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            Rotate = false;
            num = 0;
        }

    }

    public void TextBoxDestroy0()
    {
        DropBox[0].SetActive(false);
        //1번만 삭제시
        if (!DropBox[0].activeSelf && DropBox[1].activeSelf 
          && DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            num = 0;
        }
        //4번 1번 삭제시
        else if(!DropBox[0].activeSelf && DropBox[1].activeSelf
              && DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 3;
        }
        //3번 4번 1번 삭제시
        else if(!DropBox[0].activeSelf && DropBox[1].activeSelf
             && !DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 2;
        }
        // 2번 3번 4번 1번 삭제시
        else if(!DropBox[0].activeSelf && !DropBox[1].activeSelf
             && !DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 0;
        }
        Rotate = false;
    }
    public void TextBoxDestroy1()
    {
        DropBox[1].SetActive(false);
        //2번만 삭제시
        if (DropBox[0].activeSelf && !DropBox[1].activeSelf
         && DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            num = 1;
        }
        //1번 2번 삭제시
        else if (!DropBox[0].activeSelf && !DropBox[1].activeSelf
               && DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            num = 0;
        }
        //4번 1번 2번 삭제시
        else if (!DropBox[0].activeSelf && !DropBox[1].activeSelf
               && DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 3;
        }
        // 3번 4번 1번 2번 삭제시
        else if (!DropBox[0].activeSelf && !DropBox[1].activeSelf
              && !DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 0;
        }
        Rotate = false;
    }
    public void TextBoxDestroy2()
    {
        DropBox[2].SetActive(false);
        //3번만 삭제시
        if (DropBox[0].activeSelf && DropBox[1].activeSelf &&
           !DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            num = 2;
        }
        //2번 3번 삭제시
        else if (DropBox[0].activeSelf && !DropBox[1].activeSelf
             && !DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            num = 1;
        }
        //1번 2번 3번 삭제시
        else if (!DropBox[0].activeSelf && !DropBox[1].activeSelf
              && !DropBox[2].activeSelf && DropBox[3].activeSelf)
        {
            num = 0;
        }
        //1번 2번 3번 4번 삭제시
        else if (!DropBox[0].activeSelf && !DropBox[1].activeSelf
              && !DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 0;
        }
        Rotate = false;
    }
    public void TextBoxDestroy3()
    {
        DropBox[3].SetActive(false);
        //4번만 삭제시
        if (DropBox[0].activeSelf && DropBox[1].activeSelf 
         && DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 3;
        }
        //3번 4번 삭제시
        else if (DropBox[0].activeSelf && DropBox[1].activeSelf
             && !DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 2;
        }
        //2번 3번 4번 삭제시
        else if (DropBox[0].activeSelf && !DropBox[1].activeSelf 
             && !DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 1;
        }
        //2번 3번 4번 1번 삭제시
        else if (!DropBox[0].activeSelf && !DropBox[1].activeSelf 
              && !DropBox[2].activeSelf && !DropBox[3].activeSelf)
        {
            num = 0;
        }
        Rotate = false;
    }

    //RandomCount로 몇 개 드랍되었는지 텍스트 출력하면 됨
    public void Num0(string Name, int randomCount)
    {
        if(DropBox[3].activeSelf)
            Anim4.SetTrigger("isUp1");
        if (DropBox[2].activeSelf)
            Anim3.SetTrigger("isUp2");
        if (DropBox[1].activeSelf)
            Anim2.SetTrigger("isUp3");

        DropBox[0].SetActive(true);
        Anim1.SetTrigger("isShow");
        Text1.text = Name + " 픽셀 조각 ";
        if(Name == "R")
            RGBImgArr[0].sprite = RGBarr[0].sprite;
        else if(Name == "G")
            RGBImgArr[0].sprite = RGBarr[1].sprite;
        else if (Name == "B")
            RGBImgArr[0].sprite = RGBarr[2].sprite;
    }

    public void Num1(string Name, int randomCount)
    {
        if (DropBox[3].activeSelf)
            Anim4.SetTrigger("isUp2");
        if (DropBox[2].activeSelf)
            Anim3.SetTrigger("isUp3");
        if (DropBox[0].activeSelf)
            Anim1.SetTrigger("isUp1");

        DropBox[1].SetActive(true);
        Anim2.SetTrigger("isShow");
        Text2.text = Name + " 픽셀 조각 ";
        if (Name == "R")
            RGBImgArr[1].sprite = RGBarr[0].sprite;
        else if (Name == "G")
            RGBImgArr[1].sprite = RGBarr[1].sprite;
        else if (Name == "B")
            RGBImgArr[1].sprite = RGBarr[2].sprite;
    }
    public void Num2(string Name, int randomCount)
    {
        if (DropBox[3].activeSelf)
            Anim4.SetTrigger("isUp3");
        if (DropBox[1].activeSelf)
            Anim2.SetTrigger("isUp1");
        if (DropBox[0].activeSelf)
            Anim1.SetTrigger("isUp2");

        DropBox[2].SetActive(true);       
        Anim3.SetTrigger("isShow");
        Text3.text = Name + " 픽셀 조각 ";
        if (Name == "R")
            RGBImgArr[2].sprite = RGBarr[0].sprite;
        else if (Name == "G")
            RGBImgArr[2].sprite = RGBarr[1].sprite;
        else if (Name == "B")
            RGBImgArr[2].sprite = RGBarr[2].sprite;
    }

    public void Num3(string Name, int randomCount)
    {
        if (DropBox[2].activeSelf)
            Anim3.SetTrigger("isUp1");
        if (DropBox[1].activeSelf)
            Anim2.SetTrigger("isUp2");
        if (DropBox[0].activeSelf)
            Anim1.SetTrigger("isUp3");

        DropBox[3].SetActive(true);     
        Anim4.SetTrigger("isShow");
        Text4.text = Name + " 픽셀 조각 ";
        if (Name == "R")
            RGBImgArr[3].sprite = RGBarr[0].sprite;
        else if (Name == "G")
            RGBImgArr[3].sprite = RGBarr[1].sprite;
        else if (Name == "B")
            RGBImgArr[3].sprite = RGBarr[2].sprite;
    }

}
