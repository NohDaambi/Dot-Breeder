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
    public GameObject House;
    public GameObject Player;
    public GameObject Combination;
    public GameObject Shack;
    public GameObject[] ShackGrid = new GameObject[4];

    //�̱۷�
    public GameObject IglooOutside;
    public GameObject IglooInside;
    public GameObject[] IglooGrid = new GameObject[4];

    public SpriteRenderer CombineRenderer;
    public SpriteRenderer HouseRenderer;
    public SpriteRenderer IglooRenderer;

    public Sprite[] ShackArr = new Sprite[3];
    public Sprite[] IglooArr = new Sprite[3];
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
    }

    void Update()
    {
        if(Manager.stageNum == 1)
            Shackfunc();
        else if(Manager.stageNum == 2)
            Igloofunc();
    }

    public void Shackfunc()
    {
        //�� ���� UI�Ⱥ��̰��ϰ� or ��-1������ ������
        if (SceneManager.GetActiveScene().name == "House" || SceneManager.GetActiveScene().name != "Forest1")
            House.SetActive(false);
        //�� ���ͼ� ���� �� �����ִ��Ŷ�� ����
        else if (timer.ShackOn && SceneManager.GetActiveScene().name == "Forest1")
            House.SetActive(true);

        //�볪�� ��
        if (CurrentCombinging == 1 && timer.isGive)
        {
            timer.ShackOn = true;
            House.SetActive(true);
            Player.transform.position = new Vector3(5.8f, -4f, -1);
            timer.isGive = false;
        }
        if (SceneManager.GetActiveScene().name == "House" && timer.ShackOn)
        {
            Shack.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = null;
            Combination.transform.position = new Vector3(-0.4f, 0.8f, -1);

        }
        if (SceneManager.GetActiveScene().name == "Forest1" && !timer.ShackOn)
        {
            Combination.SetActive(true);
            CombineRenderer.sprite = CombinObj;
            Combination.transform.position = new Vector3(5.8f, -0.45f, -1);
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
            IglooOutside.SetActive(false);
        //�� ���ͼ� ���� �� �����ִ��Ŷ�� ����
        else if (timer.IglooOn && SceneManager.GetActiveScene().name == "Ocene1")
            IglooOutside.SetActive(true);

        //�̱۷�
        if (CurrentCombinging == 5 && timer.isGive)
        {
            timer.IglooOn = true;
            IglooOutside.SetActive(true);
            Player.transform.position = new Vector3(0.1f, -3.7f, -1);
            timer.isGive = false;
        }
        if (SceneManager.GetActiveScene().name == "House" && timer.IglooOn)
        {
            IglooInside.SetActive(true);
            Combination.SetActive(true);
            CombineRenderer.sprite = null;
            Combination.transform.position = new Vector3(0.35f, 0.6f, -1);

        }
        if (SceneManager.GetActiveScene().name == "Ocene1" && !timer.IglooOn)
        {
            Combination.SetActive(true);
            CombineRenderer.sprite = CombinObj;
            Combination.transform.position = new Vector3(0, 0, -1);
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
}
