using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ó�� Ʃ�丮�� ��ǳ�� ������ ���� ��ũ��Ʈ!
//QuestDataManager ������Ʈ �ȿ� �־� ����.
public class TutorialManager : MonoBehaviour
{
    private GameObject broken_combiner;
    private GameObject data_piece;

    //�ش� ���� �����ϴ� ������Ʈ�� �ҷ��´�.
    public IEnumerator SetObject()
    {
       QuestDataLoader questDB = transform.GetComponent<QuestDataLoader>();
        //�ϴ� ���ձ� �ۿ� ���..���ձ� ��ȸ������ SET
       broken_combiner = GameObject.Find("CombinationObj");
       Debug.Log("[!]Tutorial_System : Find Broken_Combiner");
       QuestObj questobj = broken_combiner.GetComponent<QuestObj>();
       StartCoroutine(questDB.MatchHash((int)INTERACTION_STRUCTURE.TUTORIAL_SIGN));
       StartCoroutine(questobj.BeOnCall((int)INTERACTION_STRUCTURE.BROKEN_COMBINER));
       
       //BeOnCall �Լ�: �ش� OBJ�� ��ǳ���� ����.


       yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
