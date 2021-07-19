using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArr : MonoBehaviour
{

    public GameObject[] DropBoxArr = new GameObject[4];
    public PlayerAction player;

    public Text DropText1;
    public Text DropText2;
    public Text DropText3;

    public string[] PrevName = new string[3];

    //드랍 텍스트 사라지기
    IEnumerator TextDestroyDelay(GameObject DropBox)
    {
        //딜레이
        yield return new WaitForSecondsRealtime(10f);
        DropBox.SetActive(false);

    }

    //드랍 텍스트
    public void Drop(string name, int count, int prevCount)
    {
        if ((count != prevCount && !DropBoxArr[0].activeSelf) 
            || (DropBoxArr[0].activeSelf && name == PrevName[0])) // 1 , 0  // 2 , 1
        {
            DropBoxArr[0].SetActive(true);
            prevCount = count; // 1 , 1 // 2 , 2
            if (!DropBoxArr[1].activeSelf
                || (DropBoxArr[1].activeSelf && PrevName[0] == name))
            {
                DropText1.text = name + ": " + count.ToString(); // R: 0
            }
            PrevName[0] = name; // R , R
            StartCoroutine(TextDestroyDelay(DropBoxArr[0]));

        }

        if (PrevName[0] != null && count != prevCount && name != PrevName[0] 
                                && DropBoxArr[0].activeSelf)
        {
            DropBoxArr[1].SetActive(true);
            prevCount = count; // 1 , 1 // 2 , 2
            if (!DropBoxArr[2].activeSelf
                || (DropBoxArr[2].activeSelf && PrevName[1] == name))
            {
                DropText2.text = name + ": " + count.ToString(); // G: 0
            }
            PrevName[1] = name; // R , R
            StartCoroutine(TextDestroyDelay(DropBoxArr[1]));


        }

        // count != prevCount 가 왜 false일까..
        if (PrevName[1] != null && count != prevCount 
                                && name != PrevName[0] && name != PrevName[1]
                                && DropBoxArr[0].activeSelf && DropBoxArr[1].activeSelf)     
        {
            DropBoxArr[2].SetActive(true);
            prevCount = count; // 1 , 1 // 2 , 2           
            if (!DropBoxArr[3].activeSelf
                || (DropBoxArr[3].activeSelf && PrevName[2] == name))
            {
                DropText3.text = name + ": " + count.ToString(); // B: 0
            }
            PrevName[2] = name; // R , R
            StartCoroutine(TextDestroyDelay(DropBoxArr[2]));
        }


    }

}
