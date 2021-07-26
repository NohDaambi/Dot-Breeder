using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combination : MonoBehaviour
{
    public PlayerAction player;
    public GameManager Manager;
    public Timer timer;

    public GameObject CombineUI;
    public GameObject CombineChild;
    public GameObject Combining;
    public GameObject CombineEnd;

    public Animator CombineAnim;
    public Animator ChildAnim;
    public Animator CombiningAnim;

    //���ձ� UI
    public Text Title;
    public Text time;
    public Image image;
    public Text Content;
    public Text R;
    public Text G;
    public Text B;
    public Text ProduceNum;

    //������ UI
    public Text TitleIng;
    public Text timeIng;
    public Image imageIng;

    //���� �ð�
    public float GetHouseTime;
    public float GetBedTime;
    public float GetStoveTime;
    public float GetTableTime;

    //�ʿ��� ���
    public int RequiredR;
    public int RequiredG;
    public int RequiredB;

    //���� ������ ��
    public int produceNum;

    //�ִ� ���� ���� �� (�⺻�� : 1)
    public int maxR = 1;
    public int maxG = 1;
    public int maxB = 1;


    //�������ΰ�?, ������ �����ų� ����� �� false, ���չ�ư ������ true
    public bool isCombining;

    public int DotItem;

    private static bool combineExist;

    public void Awake()
    {

        // �� �̵� �� �ߺ� ����        
        if (!combineExist)
        {
            combineExist = true;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            CombineChild.SetActive(false);
            Combining.SetActive(false);
            Manager.isAction = false;
        }
    }

    public void Button1()
    {
        CombineAnim.SetTrigger("isButton");
        if(!isCombining)
            CombineChild.SetActive(true);
        else if(isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        TreeHouse();
    }
    public void Button2()
    {
        CombineAnim.SetTrigger("isButton");
        if (!isCombining)
            CombineChild.SetActive(true);
        else if (isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        Bed();
    }
    public void Button3()
    {
        CombineAnim.SetTrigger("isButton");
        if (!isCombining)
            CombineChild.SetActive(true);
        else if (isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        Stove();
    }
    public void Button4()
    {
        CombineAnim.SetTrigger("isButton");
        if (!isCombining)
            CombineChild.SetActive(true);
        else if (isCombining)
            Combining.SetActive(true);
        ChildAnim.SetTrigger("isShow");
        Table();
    }
    public void ProduceButton()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            Manager.Rcount -= RequiredR * produceNum;
            Manager.Gcount -= RequiredG * produceNum;
            Manager.Bcount -= RequiredB * produceNum;

            //�ٲ�� �Ҵ������ �ؽ�ƮUI �ߺ� ��� ����
            Manager.PrevGcount = Manager.Gcount;
            Manager.PrevRcount = Manager.Rcount;
            Manager.PrevBcount = Manager.Bcount;

            CombineChild.SetActive(false);
            Combining.SetActive(true);
            CombiningAnim.SetTrigger("isShow");
            isCombining = true;
        }
        else if(Manager.Rcount <= RequiredR || Manager.Gcount <= RequiredG || Manager.Bcount <= RequiredB)
        {
            ChildAnim.SetTrigger("isNotFull");
            Debug.Log("��ᰡ �����մϴ�!");
        }

        //�����ϴ� �Լ�(�ð�,����)

    }
    public void TimeReduce()
    {
        //1��ư 1�� ����
        if (timer.combineTIme > 0)
        { 
            timer.combineTIme--;
            timer.transTime++;
        }
    }
    public void CombineCancel()
    {
        Combining.SetActive(false);
        CombineChild.SetActive(true);
        Manager.Rcount += RequiredR * produceNum;
        Manager.Gcount += RequiredG * produceNum;
        Manager.Bcount += RequiredB * produceNum;

        //�ٲ�� �Ҵ������ �ؽ�ƮUI �ߺ� ��� ����
        Manager.PrevGcount = Manager.Gcount;
        Manager.PrevRcount = Manager.Rcount;
        Manager.PrevBcount = Manager.Bcount;

        isCombining = false;

        //�ʱ�ȭ
        timer.combineTIme += timer.transTime;
        isCombining = false;
        timer.currentTime = 0;
        timer.transTime = 0;
        timer.isPlus = false;
        

    }
    public void GiveItem()
    {
        Combining.SetActive(false);
        CombineEnd.SetActive(false);
        CombineUI.SetActive(false);

        Manager.isAction = false;

        //��Ʈ���� �ش� ������ �Ҵ��ϱ�, �̸��ҷ��ͼ� �� �� �Ҵ�
        DotItem += produceNum;
    }
    public void Max()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            maxR = Manager.Rcount / RequiredR;
            maxG = Manager.Gcount / RequiredG;
            maxB = Manager.Bcount / RequiredB;

            if (maxR == maxG && maxR == maxB && maxG == maxB)
            {
                produceNum = maxR;
                ProduceNum.text = produceNum.ToString();
            }
     
        }
    }
    public void Half()
    {
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            maxR = Manager.Rcount / RequiredR;
            maxG = Manager.Gcount / RequiredG;
            maxB = Manager.Bcount / RequiredB;

            if (maxR == maxG && maxR == maxB && maxG == maxB)
            {
                produceNum = maxR / 2;
                ProduceNum.text = produceNum.ToString();
            }

        }
    }


    //�� �Ʒ����ʹ� ���߿� ������ ����, ���÷� ��Ƶ�
    public void TreeHouse()
    {
        RequiredR = 1;
        RequiredG = 2;
        RequiredB = 1;
        GetHouseTime = 20;
        timer.combineTIme = GetHouseTime;

        //���ձ� �ؽ�Ʈ
        Title.text = "�볪����";
        time.text = "���� �ð� : " + GetHouseTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "�볪�����̶��ϴ�! ������ ��������,,";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;

        //������ �ؽ�Ʈ
        TitleIng.text = "�볪����";
        timeIng.text = "���� �ð� : " + GetHouseTime.ToString();
        //imageIng.sprtie = ~~
       

        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            produceNum = 1;
        }
        else
        {
            produceNum = 0;
        }

        ProduceNum.text = produceNum.ToString();
    }
    public void Bed()
    {
        RequiredR = 2;
        RequiredG = 2;
        RequiredB = 1;
        GetBedTime = 40;
        timer.combineTIme = GetBedTime;

        Title.text = "��ź ���ħ��";
        time.text = "���� �ð� : " + GetBedTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "��ź ���ħ���Դϴ�! ���� ����������";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;

        //������ �ؽ�Ʈ
        TitleIng.text = "��ź ���ħ��";
        timeIng.text = "���� �ð� : " + GetBedTime.ToString();
        //imageIng.sprtie = ~~
        

        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            produceNum = 1;
        }
        else
        {
            produceNum = 0;
        }

        ProduceNum.text = produceNum.ToString();
    }
    public void Stove()
    {
        RequiredR = 2;
        RequiredG = 2;
        RequiredB = 2;
        GetStoveTime = 50;
        timer.combineTIme = GetStoveTime;

        Title.text = "������";
        time.text = "���� �ð� : " + GetStoveTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "�������Դϴ�! �����ؿ�";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;
               
        //������ �ؽ�Ʈ
        TitleIng.text = "������";
        timeIng.text = "���� �ð� : " + GetStoveTime.ToString();
        //imageIng.sprtie = ~~
      

        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            produceNum = 1;
        }
        else
        {
            produceNum = 0;
        }

        ProduceNum.text = produceNum.ToString();
    }
    public void Table()
    {
        RequiredR = 3;
        RequiredG = 2;
        RequiredB = 3;
        GetTableTime = 70;
        timer.combineTIme = GetTableTime;

        Title.text = "���̺� ��";
        time.text = "���� �ð� : " + GetTableTime.ToString();
        //image.sprite = ��������Ʈ �����ͼ� �� �Ҵ�
        Content.text = "���̺� ���Դϴ�! � ���ϼ���.";
        R.text = Manager.Rcount + " / " + RequiredR;
        G.text = Manager.Gcount + " / " + RequiredG;
        B.text = Manager.Bcount + " / " + RequiredB;
        
        //������ �ؽ�Ʈ
        TitleIng.text = "���̺� ��";
        timeIng.text = "���� �ð� : " + GetTableTime.ToString();
        //imageIng.sprtie = ~~
      
        if (Manager.Rcount >= RequiredR && Manager.Gcount >= RequiredG && Manager.Bcount >= RequiredB)
        {
            produceNum = 1;
        }
        else
        {
            produceNum = 0;
        }

        ProduceNum.text = produceNum.ToString();
    }
}