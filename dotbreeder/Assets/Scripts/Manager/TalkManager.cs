using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> PortraitData;

    public Sprite[] portraitArr;
    public ObjData objData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        PortraitData = new Dictionary<int, Sprite>();
        GenerateData();
        Time.timeScale = 1;
       
    }
   
    //대화 할당
    void GenerateData()
    {
        //Talk
        talkData.Add(1000, new string[] { "말걸지 말아줄래?:3"});
        talkData.Add(2000, new string[] { "넌 누구니?:3" });


        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "안녕 만나서 반가워:0", "일단 옆 동네 친구에게 가볼래?:1" });
        talkData.Add(11 + 2000, new string[] { "안녕:0", "풀 3개만 구해줄래?:1" });

        talkData.Add(20 + 1000, new string[] { "빨리 수집해줘!:3" });
        talkData.Add(20 + 2000, new string[] { "빨리 수집해줘!:3" });

        talkData.Add(30 + 2000, new string[] { "고마워 장난감 줄겡:2" });

        //초상화 (0 : 평소, 1 : 말하기, 2 : 웃음, 3 : 화남)
        PortraitData.Add(1000 + 0, portraitArr[0]);
        PortraitData.Add(1000 + 1, portraitArr[1]);
        PortraitData.Add(1000 + 2, portraitArr[2]);
        PortraitData.Add(1000 + 3, portraitArr[3]);

        PortraitData.Add(2000 + 0, portraitArr[4]);
        PortraitData.Add(2000 + 1, portraitArr[5]);
        PortraitData.Add(2000 + 2, portraitArr[6]);
        PortraitData.Add(2000 + 3, portraitArr[7]);


    }


    //대화 가져오기
    public string GetTalk(int id, int talkIndex)
    {
    
        if (!talkData.ContainsKey(id))
        {
                if (!talkData.ContainsKey(id - id % 10))
                {   //기본 대사를 가지고 옴               
                    if (talkIndex == talkData[id - id % 100].Length)
                        return null;
                    else
                        return talkData[id - id % 100][talkIndex];
                }
                else //해당 퀘스트 진행 중 대사가 없을 때 맨 처음 대사 가지고 옴
                {
                    if (talkIndex == talkData[id - id % 10].Length)
                        return null;
                    else
                        return talkData[id - id % 10][talkIndex];
                }
         
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    //초상화 관리
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return PortraitData[id + portraitIndex];
    }
}
