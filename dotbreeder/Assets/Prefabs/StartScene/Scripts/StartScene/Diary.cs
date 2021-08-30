using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    public GameObject Diary1;
    public GameObject Image;
    public Image sceneImg;
    public GameObject ConstraintImg;

    public Text[] text = new Text[4];
    public Button[] Btn = new Button[32];

    public GameObject[] textObj = new GameObject[4];
    public GameObject[] btnObj = new GameObject[32];

    public Animator ImgAnim1;
    public Animator Change1;
    public Animator Change2;
    public Animator Change3;
    public Animator Change4;


    public int num = 0;

    public int btnNum = 0;
    public int textNum = 0;

    //코루틴
    IEnumerator ImgHide()
    {        
        yield return new WaitForSecondsRealtime(0.35f);
        Image.SetActive(false);
    }

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ConstraintImg.SetActive(false);
            if (num == 1)
            {
                ImgAnim1.SetBool("isBtn1", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 2)
            {
                ImgAnim1.SetBool("isBtn2", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 3)
            {
                ImgAnim1.SetBool("isBtn3", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 4)
            {
                ImgAnim1.SetBool("isBtn4", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 5)
            {
                ImgAnim1.SetBool("isBtn5", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 6)
            {
                ImgAnim1.SetBool("isBtn6", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 7)
            {
                ImgAnim1.SetBool("isBtn7", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 8)
            {
                ImgAnim1.SetBool("isBtn8", false);
                StartCoroutine(ImgHide());
                num = 0;
            }
            else if (num == 0)
            {
                Diary1.SetActive(false);
            }
        }
    }
   
    public void LeftBtn()
    {
        if(textObj[0].activeSelf)
            Change4.SetTrigger("isChange");
        else if (textObj[1].activeSelf)
            Change1.SetTrigger("isChange");
        else if (textObj[2].activeSelf)
            Change2.SetTrigger("isChange");
        else if (textObj[3].activeSelf)
            Change3.SetTrigger("isChange");

        //버튼 번호 -8씩
        if (btnNum > 0 && btnNum <= 24) // 24 16 8 0
            btnNum -= 8;
        else if (btnNum <= 0)
            btnNum = 24;
        //텍스트 번호 -1씩
        if (textNum > 0 && textNum <= 3)
            textNum -= 1;
        else if (textNum <= 0)
            textNum = 3;
        //-8씩인 버튼들 활성화
        BtnAcitveTrue(btnNum, textNum);
        //현재 버튼들 비활성화
        BtnAcitveFalseL(btnNum, textNum);


    }
    public void RightBtn()
    {
        if (textObj[0].activeSelf)
            Change2.SetTrigger("isChange");
        else if (textObj[1].activeSelf)
            Change3.SetTrigger("isChange");
        else if (textObj[2].activeSelf)
            Change4.SetTrigger("isChange");
        else if (textObj[3].activeSelf)
            Change1.SetTrigger("isChange");

        //버튼 번호 +8씩
        if (btnNum >= 0 && btnNum < 24) // 0 8 16 24
            btnNum += 8;
        else if (btnNum >= 24)
            btnNum = 0;
        //텍스트 번호 +1씩
        if (textNum >= 0 && textNum < 3)
            textNum += 1;
        else if (textNum >= 3)
            textNum = 0;
        //+8씩인 버튼들 활성화
        BtnAcitveTrue(btnNum, textNum);
        //현재 버튼들 비활성화
        BtnAcitveFalseR(btnNum, textNum);
    }

    public void BtnAcitveTrue(int btnArr,int textArr)
    {
        for (int i = 0 + btnArr; i < 8 + btnArr; i++)
        {
            btnObj[i].SetActive(true);
        }

        textObj[textArr].SetActive(true);
    }
    //right버튼시
    public void BtnAcitveFalseR(int btnArr, int textArr)
    {
       
        if (btnArr > 0) // 8 16 24
        {
            for (int i = btnArr - 8; i < btnArr; i++)
            {
                btnObj[i].SetActive(false);
            }
            textObj[textArr - 1].SetActive(false);
        }
        else if(btnArr == 0) // 0
        {
            for (int i = 24; i < 32; i++)
            {
                btnObj[i].SetActive(false);
            }
            textObj[3].SetActive(false);
        }
    }   
    //Left버튼시
    public void BtnAcitveFalseL(int btnArr, int textArr)
    {
        
        if (btnArr < 24) // 16 8 0
        {
            for (int i = btnArr + 8; i < btnArr + 16; i++)
            {
                btnObj[i].SetActive(false);
            }
            textObj[textArr + 1].SetActive(false);
        }
        else if (btnArr == 24) // 24
        {
            for (int i = 0; i < 8; i++)
            {
                btnObj[i].SetActive(false);
            }
            textObj[0].SetActive(false);
        }
    }

    //버튼 이미지 가져오기
    public void ImgControl(int arr, int n)
    {
        ConstraintImg.SetActive(true);
        Image.SetActive(true);
        sceneImg.sprite = Btn[arr + btnNum].image.sprite;
        num = n;
    }
    public void button1()
    {
        ImgControl(0, 1);
        ImgAnim1.SetBool("isBtn1", true);
    }
    public void button2()
    {
        ImgControl(1, 2);
        ImgAnim1.SetBool("isBtn2", true);
    }
    public void button3()
    {
        ImgControl(2, 3);
        ImgAnim1.SetBool("isBtn3", true);
    }
    public void button4()
    {
        ImgControl(3, 4);
        ImgAnim1.SetBool("isBtn4", true);
    }
    public void button5()
    {
        ImgControl(4, 5);
        ImgAnim1.SetBool("isBtn5", true);
    }
    public void button6()
    {
        ImgControl(5, 6);
        ImgAnim1.SetBool("isBtn6", true);
    }
    public void button7()
    {
        ImgControl(6, 7);
        ImgAnim1.SetBool("isBtn7", true);
    }
    public void button8()
    {
        ImgControl(7, 8);
        ImgAnim1.SetBool("isBtn8", true);
    }
}
