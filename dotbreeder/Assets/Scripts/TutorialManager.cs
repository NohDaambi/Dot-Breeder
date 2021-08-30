using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//딱 처음 튜토리얼 말풍선 띄우려고 만든 스크립트!
//QuestDataManager 오브젝트 안에 넣어 놓음.
public class TutorialManager : MonoBehaviour
{
    private GameObject broken_combiner;
    private GameObject data_piece;

    //해당 씬에 존재하는 오브젝트를 불러온다.
    public IEnumerator SetObject()
    {
       QuestDataLoader questDB = transform.GetComponent<QuestDataLoader>();
        //일단 조합기 밖에 없어서..조합기 일회성으로 SET
       broken_combiner = GameObject.Find("CombinationObj");
       Debug.Log("[!]Tutorial_System : Find Broken_Combiner");
       QuestObj questobj = broken_combiner.GetComponent<QuestObj>();
       StartCoroutine(questDB.MatchHash((int)INTERACTION_STRUCTURE.TUTORIAL_SIGN));
       StartCoroutine(questobj.BeOnCall((int)INTERACTION_STRUCTURE.BROKEN_COMBINER));
       
       //BeOnCall 함수: 해당 OBJ에 말풍선을 띄운다.


       yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
