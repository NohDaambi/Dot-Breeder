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

    //����Ʈ ��ȣ���� �Ҵ�
    void GenerateData()
    {
        questList.Add(10, new QuestData("NPC�� ��ȭ�ϱ�"
                                        , new int[] { 1000 , 2000}));
        questList.Add(20, new QuestData("Ǯ 3�� �̾��ֱ�"
                                        , new int[] { 2000, 1000 }));
        questList.Add(30, new QuestData("����Ʈ Ŭ����!!"
                                        , new int[] { 0 }));
    }
   
    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    //Quest üũ
    public string CheckQuest(int id)
    {
        //Next Talk Target
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;
        
        //Talk ��
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        //Quest �̸�
        return questList[questId].questName;
    }

    //Quest �̸�
    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    //���� Quest
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }


}
