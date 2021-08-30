using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���
//����Ʈ�� �����ϴ� ������Ʈ���� �����Ǵ� ��ũ��Ʈ�̴�.
//1. ����Ʈtrigger�� ����Ǹ� �ٸ� ��� ����ȭ
//2. ��ǳ�� ���ִ� ���¿����� EŰ ������ ����Ʈ �ڷ�ƾ�� �����.
//3. ����Ʈ�ڷ�ƾ-> ���̾�α� ������, ����Ʈ ����. ��

//����Ʈ�� �߻��Ǵ� gamestructure�� �����ϴ� �ؽ��ڵ尡 �ִ�.
public enum INTERACTION_STRUCTURE
{
   TUTORIAL_SIGN = 989052692,
   BROKEN_COMBINER = 452260499,
   DATA_PIECE = 1804506409,
   RESOURCE = -1181451190,
   PIXEL_PIECE = 766080093,
   WOOD_SIGN = -1945051929,
   BUILDING_RUBBLE = 467765935,
   STUB = -648713566
   
}

public class QuestObj : MonoBehaviour
{
    //�ϴ� combination.cs�� ���� �Լ��� ���⿡�ٰ� �ۼ� �� ����
    //��ȣ�ۿ� EŰ BOOL
    private GameManager Manager;
    public QuestDataLoader DBloader;
    public INTERACTION_STRUCTURE Interaction;//�ܺο��� ����. ���ձ��� ��� Broken_combiner
    public bool EActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnTriggerStay2D(Collider2D col)
    {
       //scan��� ��� �ϴ� �浹�� ó���ؼ� ������ϴ���

       //�浹�� ���ؼ� Ư�� ������ ���� EŰ�� ���� �� ��ȣ�ۿ� Ȱ��ȭ. V
       //Quest���� ��Ȳ Ȯ�� �� Ʃ�� ����Ʈ �������� UI OPEN
       //Ʃ���� ���� ���� X -> tutorial dialog�߻� �� ����Ʈ ��.
       if(EActive==false) return;
       Debug.Log("�浹");
       

       //EActive�� true�϶� �׸��� Player�϶�
       //��� ������Ʈ�� ����Ʈ ����
       Debug.Log("���� ����Ʈ ������"); 
       int hashcode =Interaction.GetHashCode();
       Debug.Log("Load HashCode Num:"+hashcode);
       StartCoroutine(SearchQuest(hashcode)); //hashcode�� �ش� ����Ʈ ã�Ƽ� isActive()
       EActive=false; //���� �Լ����� ���߽��� ���� �ʵ��� EActive ��Ȱ��ȭ.
    }

     public IEnumerator SearchQuest(int hash)
    {
        yield return StartCoroutine(DBloader.MatchHash(hash)); //������ ���� �Ľ��ڷ�ƾ�� null���� �Ǹ� �Ʒ��� ����.
           //yield return StartCoroutine(UploadQuest()); //UI�� ����Ʈ�� ���ε� �Ѵ�.
    }

    public void Combination_tutorial()
    {
       //������ �ѷ����� Ʃ�丮���� ����Ǹ� 
       //���� Ʃ�丮��Level=1�� ��.
       
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

