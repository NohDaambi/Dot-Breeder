using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���
//����Ʈ�� �����ϴ� ������Ʈ���� �����Ǵ� ��ũ��Ʈ�̴�.
//1. ����Ʈtrigger�� ����Ǹ� �ٸ� ��� ����ȭ
//2. ��ǳ�� ���ִ� ���¿����� EŰ ������ ����Ʈ �ڷ�ƾ�� �����.
//3. ����Ʈ�ڷ�ƾ-> ���̾�α� ������, ����Ʈ ����. ��

public class QuestObj : MonoBehaviour
{
    //�ϴ� combination.cs�� ���� �Լ��� ���⿡�ٰ� �ۼ� �� ����
    //��ȣ�ۿ� EŰ BOOL
    private GameManager Manager;
    private DoteStateManager DoteStateManager;
    private GameObject questobj;
    private int descount=0;
    public QuestDataLoader DBloader;
    public INTERACTION_STRUCTURE Interaction;//�ܺο��� ����. ���ձ��� ��� Broken_combiner
    public bool IsbeonCall;
    public bool IsAvtive;
    
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        questobj = GameObject.Find("Combination"); //combination img,collider
        DBloader = GameObject.Find("QuestDataManager").GetComponent<QuestDataLoader>(); 
    }
    


     public IEnumerator SearchQuest(int hash)
    {
        //yield return StartCoroutine(DBloader.MatchHash(hash)); //������ ���� �Ľ��ڷ�ƾ�� null���� �Ǹ� �Ʒ��� ����.
           //yield return StartCoroutine(UploadQuest()); //UI�� ����Ʈ�� ���ε� �Ѵ�.
            yield return null;
    }


    //����Ʈ ��� ����
    public IEnumerator BeOnCall(int hash)
    {
        IsbeonCall=true;
        Debug.Log("[!]Tutorial_System : ACCESS BEONCALL");
        GameObject combination = Resources.Load<GameObject>("ingame/QuestMark");
        GameObject QuestFlag = Instantiate(combination,combination.transform.position,combination.transform.rotation);
        QuestFlag.transform.SetParent(questobj.transform,false);

        while(true)
        {
            //�����°� ����ɶ�,
            if(IsbeonCall==false) 
            {
                //����ǥ ��ǳ���� �������,
                QuestFlag.SetActive(false);
                Debug.Log("test"+(int)Interaction);
                //combination ����Ʈ �ڷ�ƾ ����.
                IsAvtive=true; //���߿� �ڷ�ƾ ���η� �ű濹��!!
                //�ش� ����Ʈ�� �ҷ��´�.
               // StartCoroutine(DBloader.MatchHash((int)Interaction));
               
               // DBloader.MatchHash((int)Interaction);

                //null���� return�Ͽ� ��� �ڷ�ƾ���� �����.
                yield return new WaitForSeconds(0.2f);
            }
            yield return null;
        }
        
    }
    
    //�޼����� �����ش�.
    public void ShowMessage()
    {
      Debug.Log("[!]Tutorial_System : �ȼ������� ��� ���ձ⸦ �����ּ���.");
    }
    

    //�������� ����Ʈ ������¸� üũ�Ѵ�.
    public IEnumerator CheckingQuestState()
    {
        StopCoroutine(BeOnCall((int)Interaction));
        //DB�� �ִ� Quest����Ʈ���� �ڱ� �ڽſ� ���� ����Ʈ�� �ִ��� Ȯ���Ѵ�. ������ null, ������ �Ʒ� �����Ѵ�.
        //Ȥ�� �� ���׸� ���� �����͸� �ѹ� üũ���ش�.
        if(DBloader.GetMyQuest(Interaction.GetHashCode())==null) yield return null; //quest�� null�� �ƴϸ�? �Ʒ� ����.

        Quest quest = DBloader.GetMyQuest(Interaction.GetHashCode()); //�θ� ����Ʈ�� �ҷ����´�.

        //�ش� ����Ʈ�� clear int ������ true�� �Ǹ� �ݺ����� �����.
        while(this.gameObject.GetComponent<Quest>().Clear == 0)
        {   
            switch((int)Interaction)
            {
                case (int)INTERACTION_STRUCTURE.TUTORIAL_SIGN:
                break;
                case (int)INTERACTION_STRUCTURE.BROKEN_COMBINER:
                Combination(quest);
                break;
                case (int)INTERACTION_STRUCTURE.DATA_PIECE:
                break;
            }

            yield return null;
           
        }
        yield return null; //yield return�� null�� �� �� ���� ���ư���.
    }



    //Quest Action : Quest�׸� ���� �Լ�
    //[!] While�� �ȿ��� ����ǹǷ� �������� �����,��ƾ�� ���������� ���� �ʱ�ȭ �ȴ�.


    //Hash: 989052692 : ������ �ѷ����� : ����ǥ ��ǳ�� ��� Ȯ���ϱ� : ��ó�� ���ƴٴϸ� ������ �ɸ���....: 10�� ��ǳ�� Ȯ���ϱ�
    //ù��° ����Ʈ! : �켱�� ���ձ⸦ Ȯ���ϸ� ������ �ɷ� �ϱ�.
    private void Tutorial()
    {
    
    }
    
    //Hash: 452260499 : ���ձ⸦ ��ġ�� : ������ ���ձ� ��ġ�� : R10,G10,B10 �ȼ� ������
    //�ڷ�ƾ�� ���� ���������� �Լ��� ����ȴ�. 
    private void Combination(Quest quest)
    {
        //GameManager�� �ִ� player RGB������ UI�� �ԽõǾ��ִ� RGB text ������ �޾ƿ´�.
        List<int> RGB = new List<int>() {GetComponent<GameManager>().Rcount,GetComponent<GameManager>().Gcount,GetComponent<GameManager>().Bcount};
        List<string> RGBtxt = new List<string>() {quest.DesList[0].GetComponent<Text>().text,quest.DesList[1].GetComponent<Text>().text,quest.DesList[2].GetComponent<Text>().text};
        const int goal=15; //������ �ʴ� ��ǥ ���̴�.
          
        for(int i=0;i<RGB.Count;i++)  //RGB ��ȸ
        {
              //�θ� ����Ʈ Ŭ���� ������ �޼��� ��쿡�� ����Ʈ �Ϸ���� UI��ȯ�� �Ѵ�.
            if(descount==quest.Count) 
            {
                //UI��ȯ���� �Լ� �ε� �� �Ʒ� �ڵ�� ���� X
                DBloader.ChageClearQuest((int)Interaction);
                IsAvtive=false;
                DBloader.GetMyQuest((int)Interaction).Clear=1;
                //������������?
                continue;
            }

            for(int j=0;j<RGBtxt.Count;j++) //RGBtxt ��ȸ
            {
                if(i!=j) continue; //�ε����� ���� ���� ��쿡�� �۾��� �Ѵ�.
                //���� ���� RGB������ UI���� ������ ��ġ���� ������ ������Ʈ ���ش�.
                if(RGB[i]!=int.Parse(RGBtxt[j])) RGBtxt[j]=RGB[i].ToString();
                 //�÷��̾ ������ �ִ� RGB�� goal�� ��� ���� ��, �ش� ����Ʈ�� ���� ī��Ʈ�� �����Ѵ�.
                if(RGB[i]==goal) descount+=1;
              }
        }

    }

    //Hash: 1804506409 : ������ ������ ������ : �ɿ� ������ ������ ���� 10���� ã�� : 10�� ��� ������.
    //����ǥ ��ǳ�� Ȯ���ϸ� ȹ�� ����.
    private void DataPiece()
    {
        
    }
    
}

