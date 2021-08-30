using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArr : MonoBehaviour
{

    public GameObject[] DropBoxArr = new GameObject[3];
    public PlayerAction player;

    public Animator Anim1;
    public Animator Anim2;
    public Animator Anim3;

    public Text DropText1;
    public Text DropText2;
    public Text DropText3;

    public string[] PrevName = new string[3];


    //드랍 텍스트 사라지기
    IEnumerator TextDestroyDelay(GameObject DropBox)
    {
        //딜레이
        yield return new WaitForSecondsRealtime(20f);
        DropBox.SetActive(false);
    }

    //코루틴 실행 정지
    public void Coroutine(int num)
    {
        if (PrevName[num] == name)
            StopCoroutine(TextDestroyDelay(DropBoxArr[num]));
        else if (PrevName[num] != name)
            StartCoroutine(TextDestroyDelay(DropBoxArr[num]));
    }

    //드랍시 텍스트
    public void Drop(string name, int count, int prevCount)
    {
        //첫번째 텍스트 박스
        if ((count != prevCount && !DropBoxArr[0].activeSelf ) 
                                || (count != prevCount && DropBoxArr[0].activeSelf && name == PrevName[0]))
        {
            DropBoxArr[0].SetActive(true);           
            if (!DropBoxArr[1].activeSelf
                || (DropBoxArr[1].activeSelf && PrevName[0] == name))
            {
                Anim1.SetTrigger("isShowText");
                DropText1.text = name + ": " + count.ToString(); 
            }
            PrevName[0] = name;
            
            Coroutine(0);
        }

        //두번째 텍스트 박스
        if ((count != prevCount && name != PrevName[0] 
                                && name != PrevName[2] && DropBoxArr[0].activeSelf) 
                                || (count != prevCount && DropBoxArr[1].activeSelf && name == PrevName[1]))
        {
            DropBoxArr[1].SetActive(true);      
            if (!DropBoxArr[2].activeSelf
                || (DropBoxArr[2].activeSelf && PrevName[1] == name))
            {
                Anim2.SetTrigger("isShowText");
                DropText2.text = name + ": " + count.ToString(); 
            }
            PrevName[1] = name;
            Coroutine(1);
        }

        //세번째 텍스트 박스
        if ((name != PrevName[0] && name != PrevName[1] && DropBoxArr[1].activeSelf && !DropBoxArr[2].activeSelf) 
                                 || (count != prevCount && DropBoxArr[2].activeSelf && name == PrevName[2])) // DropBoxArr[0].activeSelf
        {
            DropBoxArr[2].SetActive(true);   
            DropText3.text = name + ": " + count.ToString();
            Anim3.SetTrigger("isShowText");
            PrevName[2] = name;
            Coroutine(2);

        }

    }

}
