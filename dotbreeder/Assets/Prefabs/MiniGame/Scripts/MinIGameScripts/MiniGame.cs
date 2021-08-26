using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class MiniGame : MonoBehaviour
{
    public GameManager Manager;

    string[] InputKeyArr = new string[7]; //�Է� ��
    string[] AnswerKeyArr = new string[7]; //����
    public bool[] Result = new bool[7];
    public Image[] InputImageArr = new Image[4]; // Donw 0 Left 1 Right 2 Up 3
    public Image[] AnswerImageArr = new Image[4];
    public Image[] AnswerImg = new Image[7];
    public Image[] InputImg = new Image[7];

    public GameObject DotLevel2;
    public GameObject DotLevel3;
    public GameObject DotLevel4;

    public Text ScoreText;
    public Text ScoreText2;

    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;

    public Animator FoDot2Anim;
    public Animator FoDot3Anim;
    public Animator FoDot4Anim;
    public Animator Wood;
    public Animator[] FailAnim = new Animator[7];

    public bool isAlive = true;
    public int Score = 0;
    int random = 0;
    public int InputIndex = 0;
    public int AnswerIndex = 0;
    public int InputNum = 0;

    void Awake()
    {
        InitKey();
        InputTextInit();

        for (int i = 0; i < 7; i++)
        {
            Result[i] = false;            
        }        
    }

    void Update()
    {
        if (Manager.DotLevel == 2)
            DotLevel2.SetActive(true);
        else if (Manager.DotLevel == 3)
        {
            DotLevel2.SetActive(false);
            DotLevel3.SetActive(true);
        }
        else if (Manager.DotLevel == 4)
        {
            DotLevel2.SetActive(false);
            DotLevel3.SetActive(false);
            DotLevel4.SetActive(true);
        }
        

        //�ð� ���� Ű �Է� ����
        if (isAlive)
        {            
            //����Ű �Է°�
            if (Input.GetKeyDown(KeyCode.W))
            {
                InputImg[InputIndex].color = new Color(1, 1, 1, 1);
                InputKeyArr[InputIndex] = "Up";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                InputImg[InputIndex].color = new Color(1, 1, 1, 1);
                InputKeyArr[InputIndex] = "Down";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                InputImg[InputIndex].color = new Color(1, 1, 1, 1);
                InputKeyArr[InputIndex] = "Left";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip); 
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                InputImg[InputIndex].color = new Color(1, 1, 1, 1);
                InputKeyArr[InputIndex] = "Right";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip);
            }

            //�� ����� ��쿡 ������� �����ϱ�
            if (InputIndex == 7)
            {
                InputIndex = 0;
                InitKey(); //�ʱ�ȭ 
            }
            
            ScoreText.text = Score.ToString();
            ScoreText2.text = Score.ToString();
        }
    }

    public void InitKey()
    {
        //���� �� �Ҵ�
        for (int i = 0; i < AnswerKeyArr.Length; i++)
        {
            random = Random.Range(0, 4);
            AnswerKey();
        }
       
    }

    //�������� ���� �����
    public void AnswerKey()
    {
        if (random == 0) //0 == up
        {
            AnswerKeyArr[AnswerIndex] = "Up";
            AnswerIndex++;            
        }
        else if (random == 1) // 1 == Down
        {
            AnswerKeyArr[AnswerIndex] = "Down";
            AnswerIndex++;
        }
        else if (random == 2) // 2 == Left
        {
            AnswerKeyArr[AnswerIndex] = "Left";
            AnswerIndex++;
        }
        else if (random == 3) // 3 == Right
        {
            AnswerKeyArr[AnswerIndex] = "Right";
            AnswerIndex++;
        }

        if (AnswerIndex == 7) //7�� ����� ��쿡 ������� ������!!
        {
            AnswerText();
            AnswerIndex = 0;
        }
    }


    //�迭�� ������� Ű �Է°� �ֱ�
    public void InputKey()
    {
        Result[InputNum] = InputKeyArr[InputNum].Equals(AnswerKeyArr[InputNum]);

        //����
        if (Result[InputNum])
        {
            InputText();

            //�ʱ�ȭ
            if (InputIndex == 7)
            {
                Score += 100;
                InputInit();
                AnswerInit();
                ResultInit();
                InputTextInit();
                InputNum = 0;
                SoundManager.instance.SFXPlay("Cler", clip1);
                if (DotLevel2.activeSelf)
                    FoDot2Anim.SetTrigger("Clear");
                else if (DotLevel3.activeSelf)
                    FoDot3Anim.SetTrigger("Clear");
                else if (DotLevel4.activeSelf)
                {
                    FoDot4Anim.SetTrigger("Clear");
                    Wood.SetTrigger("Clear");
                }
            }

        }
        //����
        else if (!Result[InputNum])
        {

            Debug.Log("����!");
            SoundManager.instance.SFXPlay("Falied", clip2);

            for (int i = 0; i < FailAnim.Length; i++)
            {
                FailAnim[i].SetTrigger("Fail");
            }

            InputInit();
            AnswerInit();
            ResultInit();
            InputTextInit();

            InputIndex = 0;
            AnswerIndex = 0;
            InputNum = 0;

            //���ο� �迭 ����
            InitKey();            
        }

        // �����̸鼭 ��� �� ������ ���� ��쿡�� �������� �Ѿ��
        if (InputIndex < 7 && Result[InputNum])
            InputNum++;

    }

    //�Է� �ʱ�ȭ
    public void InputInit()
    {
        for (int i = 0; i < InputKeyArr.Length; i++)
        {
            InputKeyArr[i] = null;
        }
    }

    //���� �ʱ�ȭ
    public void AnswerInit()
    {
        for (int i = 0; i < AnswerKeyArr.Length; i++)
        {
            AnswerKeyArr[i] = null;
        }
    }

    //��� �ʱ�ȭ
    public void ResultInit()
    {
        for (int i = 0; i < Result.Length; i++)
        {
            Result[i] = false;
        }
    }

    //�Է� �ؽ�Ʈ �ʱ�ȭ
    public void InputTextInit()
    {
        for (int i = 0; i < InputImg.Length; i++)
        {
            InputImg[i].color = new Color(1, 1, 1, 0);
        }
    }

    //�Է� �ؽ�Ʈ
    public void InputText()
    {
        InputImgFunc(0);
        InputImgFunc(1);
        InputImgFunc(2);
        InputImgFunc(3);
        InputImgFunc(4);
        InputImgFunc(5);
        InputImgFunc(6);
    }

    //���� �ؽ�Ʈ
    public void AnswerText()
    {
        AnswerImgFunc(0);
        AnswerImgFunc(1);
        AnswerImgFunc(2);
        AnswerImgFunc(3);
        AnswerImgFunc(4);
        AnswerImgFunc(5);
        AnswerImgFunc(6);
    }

    public void InputImgFunc(int num)
    {
        if (InputKeyArr[num] == "Down")
            InputImg[num].sprite = InputImageArr[0].sprite;
        else if (InputKeyArr[num] == "Left")
            InputImg[num].sprite = InputImageArr[1].sprite;
        else if (InputKeyArr[num] == "Right")
            InputImg[num].sprite = InputImageArr[2].sprite;
        else if (InputKeyArr[num] == "Up")
            InputImg[num].sprite = InputImageArr[3].sprite;
    }
    public void AnswerImgFunc(int num)
    {
        if (AnswerKeyArr[num] == "Down")
            AnswerImg[num].sprite = AnswerImageArr[0].sprite;
        else if (AnswerKeyArr[num] == "Left")
            AnswerImg[num].sprite = AnswerImageArr[1].sprite;
        else if (AnswerKeyArr[num] == "Right")
            AnswerImg[num].sprite = AnswerImageArr[2].sprite;
        else if (AnswerKeyArr[num] == "Up")
            AnswerImg[num].sprite = AnswerImageArr[3].sprite;
    }
}

