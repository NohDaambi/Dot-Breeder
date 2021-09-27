using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseManager : MonoBehaviour
{
    public Timer timer;
    public GameManager Manager;

    //�볪�� ��
    public GameObject BeforeShack;
    public GameObject House;
    public GameObject Player;
    public GameObject Combination;
    public GameObject Shack;
    public GameObject[] ShackGrid = new GameObject[4];

    //�̱۷�
    public GameObject BeforeIgloo;
    public GameObject IglooOutside;
    public GameObject IglooInside;
    public GameObject[] IglooGrid = new GameObject[4];

    //��Ʈ
    public GameObject BeforeTent;
    public GameObject TentOutside;
    public GameObject TentInside;
    public GameObject[] TentGrid = new GameObject[4];

    public SpriteRenderer CombineRenderer;
    public SpriteRenderer HouseRenderer;
    public SpriteRenderer IglooRenderer;
    public SpriteRenderer TentRenderer;

    public Sprite[] ShackArr = new Sprite[3];
    public Sprite[] IglooArr = new Sprite[3];
    
    public Sprite[] TentArr = new Sprite[3];
    public Sprite CombinObj;

    //���� �������� �� 1~10���� ���๰ 100���� ���� ���������� �з�
    //1~4 ��
    //5~8 ����
    //9~12 �縷
    public int CurrentCombinging;

    void Awake()
    {
        CombineRenderer = Combination.GetComponent<SpriteRenderer>();
        HouseRenderer = Shack.GetComponent<SpriteRenderer>();
        IglooRenderer = IglooInside.GetComponent<SpriteRenderer>();
        TentRenderer = TentInside.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Manager.stageNum == 1)
            Shackfunc();
        else if(Manager.stageNum == 2)
            Igloofunc();
        else if(Manager.stageNum == 3)
            Tentfunc();
    }

    public void Shackfunc()
    {
        //�� ���� UI�Ⱥ��̰��ϰ� or ��-1������ ������
        if (SceneManager.GetActiveScene().name == "House" || SceneManager.GetActiveScene().name != "Forest1")
        {
            BeforeShack.SetActive(false);
            House.SetActive(false);
        }
        //�� ���ͼ� ���� �� �����ִ��Ŷ�� ����
        else if (timer.ShackOn && SceneManager.GetActiveScene().name == "Forest1")
            House.SetActive(true);

        //�볪�� ��
        if (CurrentCombinging == 1 && timer.isGive)
        {
            BeforeShack.SetActive(false);
            timer.ShackOn = true;
            House.SetActive(true);
            Player.transform.position = new Vector3(-2.3f, 0.5f, -1);
            timer.isGive = false;
        }
        if (SceneManager.GetActiveScene().name == "House" && timer.ShackOn)
        {
            Shack.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = null;
            Combination.transform.position = new Vector3(-0.4f, 0.8f, -1);

        }
        if (SceneManager.GetActiveScene().name == "Forest1" && !timer.ShackOn && !BeforeShack.activeSelf)
        {
            BeforeShack.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = CombinObj;
            Combination.transform.position = new Vector3(-4.9f, 4f, -1);
        }

        if ((SceneManager.GetActiveScene().name != "House" && timer.ShackOn) || (SceneManager.GetActiveScene().name != "Forest1" && !timer.ShackOn))
        {
            Shack.SetActive(false);
            Combination.SetActive(false);
        }

        //ħ��
        if (CurrentCombinging == 2 && timer.isOnShack)
        {
            ShackGrid[0].SetActive(false);
            ShackGrid[1].SetActive(true);

            HouseRenderer.sprite = ShackArr[0];
            Debug.Log("ħ�� ��ȯ");
            timer.isOnShack = false;
        }
        //����
        if (CurrentCombinging == 3 && timer.isOnShack)
        {
            ShackGrid[1].SetActive(false);
            ShackGrid[2].SetActive(true);

            HouseRenderer.sprite = ShackArr[1];
            Debug.Log("���� ��ȯ");
            timer.isOnShack = false;
        }
        //���̺�
        if (CurrentCombinging == 4 && timer.isOnShack)
        {
            ShackGrid[2].SetActive(false);
            ShackGrid[3].SetActive(true);

            HouseRenderer.sprite = ShackArr[2];
            Debug.Log("���̺� ��ȯ");
            timer.isOnShack = false;
        }
    }

    public void Igloofunc()
    {
        //�� ���� UI�Ⱥ��̰��ϰ� or ��-1������ ������
        if (SceneManager.GetActiveScene().name == "House" || SceneManager.GetActiveScene().name != "Ocene1")
        {
            BeforeIgloo.SetActive(false);
            IglooOutside.SetActive(false);
        }
        //�� ���ͼ� ���� �� �����ִ��Ŷ�� ����
        else if (timer.IglooOn && SceneManager.GetActiveScene().name == "Ocene1")
            IglooOutside.SetActive(true);

        //�̱۷�
        if (CurrentCombinging == 5 && timer.isGive)
        {
            BeforeIgloo.SetActive(false);
            timer.IglooOn = true;
            IglooOutside.SetActive(true);
            Player.transform.position = new Vector3(6.8f, -1.5f, -1);
            timer.isGive = false;
        }
        if (SceneManager.GetActiveScene().name == "House" && timer.IglooOn)
        {
            IglooInside.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = null;
            Combination.transform.position = new Vector3(0.35f, 0.6f, -1);

        }
        if (SceneManager.GetActiveScene().name == "Ocene1" && !timer.IglooOn && !BeforeIgloo.activeSelf)
        {
            BeforeIgloo.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = CombinObj;
            Combination.transform.position = new Vector3(6.3f, 3.4f, -1);
        }

        if ((SceneManager.GetActiveScene().name != "House" && timer.IglooOn) || (SceneManager.GetActiveScene().name != "Ocene1" && !timer.IglooOn))
        {
            IglooInside.SetActive(false);
            Combination.SetActive(false);
        }

        //ħ��
        if (CurrentCombinging == 6 && timer.isOnIgloo)
        {
            IglooGrid[0].SetActive(false);
            IglooGrid[1].SetActive(true);

            IglooRenderer.sprite = IglooArr[0];
            timer.isOnIgloo = false;
        }
        //����
        if (CurrentCombinging == 7 && timer.isOnIgloo)
        {
            IglooGrid[1].SetActive(false);
            IglooGrid[2].SetActive(true);

            IglooRenderer.sprite = IglooArr[1];
            timer.isOnIgloo = false;
        }
        //���̺�
        if (CurrentCombinging == 8 && timer.isOnIgloo)
        {
            IglooGrid[2].SetActive(false);
            IglooGrid[3].SetActive(true);

            IglooRenderer.sprite = IglooArr[2];            
            timer.isOnIgloo = false;
        }
    }

    public void Tentfunc()
    {
        //�� ���� UI�Ⱥ��̰��ϰ� or ��-1������ ������
        if (SceneManager.GetActiveScene().name == "House" || SceneManager.GetActiveScene().name != "Desert1")
        {
            BeforeTent.SetActive(false);
            TentOutside.SetActive(false);
        }
        //�� ���ͼ� ���� �� �����ִ��Ŷ�� ����
        else if (timer.TentOn && SceneManager.GetActiveScene().name == "Desert1")
            TentOutside.SetActive(true);

        //��Ʈ
        if (CurrentCombinging == 9 && timer.isGive)
        {
            BeforeTent.SetActive(false);
            timer.TentOn = true;
            TentOutside.SetActive(true);
            Player.transform.position = new Vector3(-7.8f, -1.5f, -1);
            timer.isGive = false;
        }
        if (SceneManager.GetActiveScene().name == "House" && timer.TentOn)
        {
            TentInside.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = null;
            Combination.transform.position = new Vector3(0f, -2.123f, -1);

        }
        if (SceneManager.GetActiveScene().name == "Desert1" && !timer.TentOn && !BeforeTent.activeSelf)
        {
            BeforeTent.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = CombinObj;
            Combination.transform.position = new Vector3(-8.1f, 0.4f, -1);
        }

        if ((SceneManager.GetActiveScene().name != "House" && timer.TentOn) || (SceneManager.GetActiveScene().name != "Desert1" && !timer.TentOn))
        {
            TentInside.SetActive(false);
            Combination.SetActive(false);
        }

        //ħ��
        if (CurrentCombinging == 10 && timer.isOnTent)
        {
            TentGrid[0].SetActive(false);
            TentGrid[1].SetActive(true);

            TentRenderer.sprite = TentArr[0];
            timer.isOnTent = false;
        }
        //����
        if (CurrentCombinging == 11 && timer.isOnTent)
        {
            TentGrid[1].SetActive(false);
            TentGrid[2].SetActive(true);

            TentRenderer.sprite = TentArr[1];
            timer.isOnTent = false;
        }
        //���̺�
        if (CurrentCombinging == 12 && timer.isOnTent)
        {
            TentGrid[2].SetActive(false);
            TentGrid[3].SetActive(true);

            TentRenderer.sprite = TentArr[2];            
            timer.isOnTent = false;
        }
    }
}
