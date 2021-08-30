using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameManager manager;
    public int questId;
    public int questActionIndex;


    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    //퀘스트 번호별로 할당
    void GenerateData()
    {
        questList.Add(10, new QuestData("NPC와 대화하기"
                                        , new int[] { 1000 , 2000}));
        questList.Add(20, new QuestData("풀 3개 뽑아주기"
                                        , new int[] { 2000, 1000 }));
        questList.Add(30, new QuestData("퀘스트 클리어!!"
                                        , new int[] { 0 }));
    }
   
    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    //Quest 체크
    public string CheckQuest(int id)
    {
        //Next Talk Target
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;
        
        //Talk 끝
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        //Quest 이름
        return questList[questId].questName;
    }

    //Quest 이름
    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    //다음 Quest
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }


}
