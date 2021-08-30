using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//기능
//퀘스트를 실행하는 오브젝트에만 부착되는 스크립트이다.
//1. 퀘스트trigger가 실행되면 다른 기능 무력화
//2. 말풍선 떠있는 상태에서는 E키 누르면 퀘스트 코루틴이 진행됨.
//3. 퀘스트코루틴-> 다이어로그 나오고, 퀘스트 받음. 해

//퀘스트가 발생되는 gamestructure과 대응하는 해쉬코드가 있다.
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
    //일단 combination.cs에 넣을 함수는 여기에다가 작성 할 예정
    //상호작용 E키 BOOL
    private GameManager Manager;
    public QuestDataLoader DBloader;
    public INTERACTION_STRUCTURE Interaction;//외부에서 지정. 조합기일 경우 Broken_combiner
    public bool EActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnTriggerStay2D(Collider2D col)
    {
       //scan기능 없어서 일단 충돌로 처리해서 디버깅하는중

       //충돌을 통해서 특정 구역에 들어와 E키를 누를 시 상호작용 활성화. V
       //Quest진행 상황 확인 후 튜토 퀘스트 지났으면 UI OPEN
       //튜토퀘 아직 진행 X -> tutorial dialog발생 및 퀘스트 줌.
       if(EActive==false) return;
       Debug.Log("충돌");
       

       //EActive가 true일때 그리고 Player일때
       //대상 오브젝트의 퀘스트 지정
       Debug.Log("이제 퀘스트 줄차레"); 
       int hashcode =Interaction.GetHashCode();
       Debug.Log("Load HashCode Num:"+hashcode);
       StartCoroutine(SearchQuest(hashcode)); //hashcode로 해당 퀘스트 찾아서 isActive()
       EActive=false; //위의 함수들이 다중실행 되지 않도록 EActive 비활성화.
    }

     public IEnumerator SearchQuest(int hash)
    {
        yield return StartCoroutine(DBloader.MatchHash(hash)); //아이템 정보 파싱코루틴이 null값이 되면 아래로 진행.
           //yield return StartCoroutine(UploadQuest()); //UI에 퀘스트를 업로드 한다.
    }

    public void Combination_tutorial()
    {
       //주위를 둘러보자 튜토리얼이 실행되면 
       //지금 튜토리얼Level=1이 됨.
       
    }

    

    //Tutorial 실행 코루틴이다.
    private IEnumerator TutorialEvent()
    {
        //DB에 있는 Quest리스트에서 자기 자신에 대한 퀘스트가 있는지 확인한다. 없으면 null, 있으면 아래 시행한다.
        //혹시 모를 버그를 위해 데이터를 한번 체크해준다.
        if(DBloader.GetMyQuest(Interaction.GetHashCode())==null) yield return null; //quest가 null이 아니면? 아래 시행.
        Quest quest = DBloader.GetMyQuest(Interaction.GetHashCode()); //부모 퀘스트가 불러져온다.
        int goal = 10; //RGB 픽셀 기준은 10개이다.
        int descount=0;
        

        //플레이어가 퀘스트를 받으면 해당 퀘스트의 버튼UI가 isActive(true)가 되기 때문에, 이것으로 상태 확인이 가능하다.
        while(this.gameObject.activeSelf == true)
        {
           
           //GameManager에 있는 player RGB정보와 UI에 게시되어있는 RGB text 정보를 받아온다.
           List<int> RGB = new List<int>() {GetComponent<GameManager>().Rcount,GetComponent<GameManager>().Gcount,GetComponent<GameManager>().Bcount};
           List<string> RGBtxt = new List<string>() {quest.DesList[0].GetComponent<Text>().text,quest.DesList[1].GetComponent<Text>().text,quest.DesList[2].GetComponent<Text>().text};
           
          
           for(int i=0;i<RGB.Count;i++)  //RGB 순회
           {
              //부모 퀘스트 클리어 조건을 달성한 경우에는 퀘스트 완료시의 UI변환을 한다.
              if(descount==quest.Count) 
              {
                   //UI변환관련 함수 로딩 후 아래 코드는 실행 X
                   continue;
              }

              for(int j=0;j<RGBtxt.Count;j++) //RGBtxt 순회
              {
                 if(i!=j) continue; //인덱스가 서로 같은 경우에만 작업을 한다.
                 //만약 현재 RGB개수와 UI상의 개수가 일치하지 않으면 업데이트 해준다.
                 if(RGB[i]!=int.Parse(RGBtxt[j])) RGBtxt[j]=RGB[i].ToString();
                 //플레이어가 가지고 있는 RGB가 goal과 모두 같을 때, 해당 퀘스트의 조건 카운트가 증가한다.
                 if(RGB[i]==goal) descount+=1;


                 

              }
           }
        }
        yield return null; //yield return이 null이 될 때 까지 돌아간다.
    }
}

