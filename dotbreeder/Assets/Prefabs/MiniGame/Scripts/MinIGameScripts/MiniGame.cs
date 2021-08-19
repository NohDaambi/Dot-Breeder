using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class MiniGame : MonoBehaviour
{
    string[] InputKeyArr = new string[8]; //�Է� ��
    string[] AnswerKeyArr = new string[8]; //����
    public bool[] Result = new bool[8];

    public Text AnswerPrevText1;
    public Text AnswerPrevText2;
    public Text AnswerPrevText3;
    public Text AnswerPrevText4;
    public Text AnswerPrevText5;
    public Text AnswerPrevText6;
    public Text AnswerPrevText7;
    public Text AnswerPrevText8;

    public Text InputKeyText1;
    public Text InputKeyText2;
    public Text InputKeyText3;
    public Text InputKeyText4;
    public Text InputKeyText5;
    public Text InputKeyText6;
    public Text InputKeyText7;
    public Text InputKeyText8;

    public Text ScoreText;
    public Text ScoreText2;

    public Animator Text1;
    public Animator Text2;
    public Animator Text3;
    public Animator Text4;
    public Animator Text5;
    public Animator Text6;
    public Animator Text7;
    public Animator Text8;

    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2; 

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

        for (int i = 0; i < 8; i++)
        {
            Result[i] = false;            
        }        
    }

    void Update()
    {
        //�ð� ���� Ű �Է� ����
        if (isAlive)
        {            
            //����Ű �Է°�
            if (Input.GetKeyDown(KeyCode.W))
            {
                InputKeyArr[InputIndex] = "Up";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                InputKeyArr[InputIndex] = "Down";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                InputKeyArr[InputIndex] = "Left";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                InputKeyArr[InputIndex] = "Right";
                InputIndex++;
                InputKey();
                SoundManager.instance.SFXPlay("Button", clip);
            }

            //8�� ����� ��쿡 ������� �����ϱ�
            if (InputIndex == 8)
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

        if (AnswerIndex == 8) //8�� ����� ��쿡 ������� ������!!
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
            if (InputIndex == 8)
            {
                Score += 100;
                InputInit();
                AnswerInit();
                ResultInit();
                InputTextInit();
                InputNum = 0;
                SoundManager.instance.SFXPlay("Cler", clip1);
            }

        }
        //����
        else if (!Result[InputNum])
        {

            Debug.Log("����!");
            SoundManager.instance.SFXPlay("Falied", clip2);

            Text1.SetTrigger("Fail");
            Text2.SetTrigger("Fail");
            Text3.SetTrigger("Fail");
            Text4.SetTrigger("Fail");
            Text5.SetTrigger("Fail");
            Text6.SetTrigger("Fail");
            Text7.SetTrigger("Fail");
            Text8.SetTrigger("Fail");

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
        if (InputIndex < 8 && Result[InputNum])
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
        InputKeyText1.text = null;
        InputKeyText2.text = null;
        InputKeyText3.text = null;
        InputKeyText4.text = null;
        InputKeyText5.text = null;
        InputKeyText6.text = null;
        InputKeyText7.text = null;
        InputKeyText8.text = null;
    }

    //�Է� �ؽ�Ʈ
    public void InputText()
    {
        InputKeyText1.text = InputKeyArr[0];
        InputKeyText2.text = InputKeyArr[1];
        InputKeyText3.text = InputKeyArr[2];
        InputKeyText4.text = InputKeyArr[3];
        InputKeyText5.text = InputKeyArr[4];
        InputKeyText6.text = InputKeyArr[5];
        InputKeyText7.text = InputKeyArr[6];
        InputKeyText8.text = InputKeyArr[7];
    }

    //���� �ؽ�Ʈ
    public void AnswerText()
    {
        AnswerPrevText1.text = AnswerKeyArr[0];
        AnswerPrevText2.text = AnswerKeyArr[1];
        AnswerPrevText3.text = AnswerKeyArr[2];
        AnswerPrevText4.text = AnswerKeyArr[3];
        AnswerPrevText5.text = AnswerKeyArr[4];
        AnswerPrevText6.text = AnswerKeyArr[5];
        AnswerPrevText7.text = AnswerKeyArr[6];
        AnswerPrevText8.text = AnswerKeyArr[7];
    }
}

