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
    private GameObject questobj;
    public QuestDataLoader DBloader;
    public INTERACTION_STRUCTURE Interaction;//�ܺο��� ����. ���ձ��� ��� Broken_combiner
    public bool IsbeonCall;
    public bool IsAvtive;
    
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        questobj = GameObject.Find("Combination"); //combination img,collider
        //DBloader = GameObject.Find("QuestDataManager").GetComponent<"QuestDataLoader">(); 
    }
    


     public IEnumerator SearchQuest(int hash)
    {
        yield return StartCoroutine(DBloader.MatchHash(hash)); //������ ���� �Ľ��ڷ�ƾ�� null���� �Ǹ� �Ʒ��� ����.
           //yield return StartCoroutine(UploadQuest()); //UI�� ����Ʈ�� ���ε� �Ѵ�.
    }


    //����Ʈ ��� ����
    public IEnumerator BeOnCall(int hash)
    {
        IsbeonCall=true;
        Debug.Log("[!]Tutorial_System : ACCESS BEONCALL");
        GameObject combination = Resources.Load<GameObject>("Prefabs/QuestFlag");
        GameObject QuestFlag = Instantiate(combination,combination.transform.position,combination.transform.rotation);
        QuestFlag.transform.SetParent(questobj.transform,false);
        while(true)
        {
           yield return null;
        }
        yield return null;
    }
    
    //�޼����� �����ش�.
    public void ShowMessage()
    {
      Debug.Log("[!]Tutorial_System : �ȼ������� ��� ���ձ⸦ �����ּ���.");
    }
    

    //Tutorial ���� �ڷ�ƾ�̴�.
    private IEnumerator TutorialEvent()
    {
        //DB�� �ִ� Quest����Ʈ���� �ڱ� �ڽſ� ���� ����Ʈ�� �ִ��� Ȯ���Ѵ�. ������ null, ������ �Ʒ� �����Ѵ�.
        //Ȥ�� �� ���׸� ���� �����͸� �ѹ� üũ���ش�.
        if(DBloader.GetMyQuest(Interaction.GetHashCode())==null) yield return null; //quest�� null�� �ƴϸ�? �Ʒ� ����.
        Quest quest = DBloader.GetMyQuest(Interaction.GetHashCode()); //�θ� ����Ʈ�� �ҷ����´�.
        int goal = 10; //RGB �ȼ� ������ 10���̴�.
        int descount=0;
        

        //�÷��̾ ����Ʈ�� ������ �ش� ����Ʈ�� ��ưUI�� isActive(true)�� �Ǳ� ������, �̰����� ���� Ȯ���� �����ϴ�.
        while(this.gameObject.activeSelf == true)
        {
           
           //GameManager�� �ִ� player RGB������ UI�� �ԽõǾ��ִ� RGB text ������ �޾ƿ´�.
           List<int> RGB = new List<int>() {GetComponent<GameManager>().Rcount,GetComponent<GameManager>().Gcount,GetComponent<GameManager>().Bcount};
           List<string> RGBtxt = new List<string>() {quest.DesList[0].GetComponent<Text>().text,quest.DesList[1].GetComponent<Text>().text,quest.DesList[2].GetComponent<Text>().text};
           
          
           for(int i=0;i<RGB.Count;i++)  //RGB ��ȸ
           {
              //�θ� ����Ʈ Ŭ���� ������ �޼��� ��쿡�� ����Ʈ �Ϸ���� UI��ȯ�� �Ѵ�.
              if(descount==quest.Count) 
              {
                   //UI��ȯ���� �Լ� �ε� �� �Ʒ� �ڵ�� ���� X
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
        yield return null; //yield return�� null�� �� �� ���� ���ư���.
    }
}