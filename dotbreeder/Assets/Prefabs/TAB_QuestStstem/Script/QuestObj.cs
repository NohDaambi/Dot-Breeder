using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//기능
//퀘스트를 실행하는 오브젝트에만 부착되는 스크립트이다.
//1. 퀘스트trigger가 실행되면 다른 기능 무력화
//2. 말풍선 떠있는 상태에서는 E키 누르면 퀘스트 코루틴이 진행됨.
//3. 퀘스트코루틴-> 다이어로그 나오고, 퀘스트 받음. 해

public class QuestObj : MonoBehaviour
{
    //일단 combination.cs에 넣을 함수는 여기에다가 작성 할 예정
    //상호작용 E키 BOOL
    private GameManager Manager;
    private DoteStateManager DoteStateManager;
    private GameObject questobj;
    private int descount=0;
    public QuestDataLoader DBloader;
    public INTERACTION_STRUCTURE Interaction;//외부에서 지정. 조합기일 경우 Broken_combiner
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
        //yield return StartCoroutine(DBloader.MatchHash(hash)); //아이템 정보 파싱코루틴이 null값이 되면 아래로 진행.
           //yield return StartCoroutine(UploadQuest()); //UI에 퀘스트를 업로드 한다.
            yield return null;
    }


    //퀘스트 대기 상태
    public IEnumerator BeOnCall(int hash)
    {
        IsbeonCall=true;
        Debug.Log("[!]Tutorial_System : ACCESS BEONCALL");
        GameObject combination = Resources.Load<GameObject>("ingame/QuestMark");
        GameObject QuestFlag = Instantiate(combination,combination.transform.position,combination.transform.rotation);
        QuestFlag.transform.SetParent(questobj.transform,false);

        while(true)
        {
            //대기상태가 종료될때,
            if(IsbeonCall==false) 
            {
                //느낌표 말풍선이 사라지고,
                QuestFlag.SetActive(false);
                Debug.Log("test"+(int)Interaction);
                //combination 퀘스트 코루틴 시작.
                IsAvtive=true; //나중에 코루틴 내부로 옮길예정!!
                //해당 퀘스트를 불러온다.
               // StartCoroutine(DBloader.MatchHash((int)Interaction));
               
               // DBloader.MatchHash((int)Interaction);

                //null값을 return하여 대기 코루틴에서 벗어난다.
                yield return new WaitForSeconds(0.2f);
            }
            yield return null;
        }
        
    }
    
    //메세지를 보여준다.
    public void ShowMessage()
    {
      Debug.Log("[!]Tutorial_System : 픽셀조각을 모아 조합기를 고쳐주세요.");
    }
    

    //진행중인 퀘스트 진행상태를 체크한다.
    public IEnumerator CheckingQuestState()
    {
        StopCoroutine(BeOnCall((int)Interaction));
        //DB에 있는 Quest리스트에서 자기 자신에 대한 퀘스트가 있는지 확인한다. 없으면 null, 있으면 아래 시행한다.
        //혹시 모를 버그를 위해 데이터를 한번 체크해준다.
        if(DBloader.GetMyQuest(Interaction.GetHashCode())==null) yield return null; //quest가 null이 아니면? 아래 시행.

        Quest quest = DBloader.GetMyQuest(Interaction.GetHashCode()); //부모 퀘스트가 불러져온다.

        //해당 퀘스트의 clear int 변수가 true가 되면 반복문을 벗어난다.
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
        yield return null; //yield return이 null이 될 때 까지 돌아간다.
    }



    //Quest Action : Quest항목별 실행 함수
    //[!] While문 안에서 실행되므로 지역변수 선언시,루틴이 끝날때마다 값이 초기화 된다.


    //Hash: 989052692 : 주위를 둘러보자 : 느낌표 말풍선 모두 확인하기 : 근처를 돌아다니며 도움이 될만한....: 10개 말풍선 확인하기
    //첫번째 퀘스트! : 우선은 조합기를 확인하면 꺼지는 걸로 하기.
    private void Tutorial()
    {
    
    }
    
    //Hash: 452260499 : 조합기를 고치자 : 망가진 조합기 고치기 : R10,G10,B10 픽셀 모으기
    //코루틴에 의해 연속적으로 함수가 실행된다. 
    private void Combination(Quest quest)
    {
        //GameManager에 있는 player RGB정보와 UI에 게시되어있는 RGB text 정보를 받아온다.
        List<int> RGB = new List<int>() {GetComponent<GameManager>().Rcount,GetComponent<GameManager>().Gcount,GetComponent<GameManager>().Bcount};
        List<string> RGBtxt = new List<string>() {quest.DesList[0].GetComponent<Text>().text,quest.DesList[1].GetComponent<Text>().text,quest.DesList[2].GetComponent<Text>().text};
        const int goal=15; //변하지 않는 목표 값이다.
          
        for(int i=0;i<RGB.Count;i++)  //RGB 순회
        {
              //부모 퀘스트 클리어 조건을 달성한 경우에는 퀘스트 완료시의 UI변환을 한다.
            if(descount==quest.Count) 
            {
                //UI변환관련 함수 로딩 후 아래 코드는 실행 X
                DBloader.ChageClearQuest((int)Interaction);
                IsAvtive=false;
                DBloader.GetMyQuest((int)Interaction).Clear=1;
                //보상제공가능?
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

    //Hash: 1804506409 : 데이터 조각을 모으자 : 맴에 숨겨진 데이터 조각 10개를 찾자 : 10개 모두 모으기.
    //느낌표 말풍선 확인하면 획득 가능.
    private void DataPiece()
    {
        
    }
    
}

