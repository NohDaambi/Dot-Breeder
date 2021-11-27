using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> PortraitData;

    public Sprite[] portraitArr;
    public ObjData objData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        PortraitData = new Dictionary<int, Sprite>();
        GenerateData();
        Time.timeScale = 1;
    }
   
    //��ȭ �Ҵ�
    void GenerateData()
    {
        //���ձ�
        talkData.Add(1500, new string[] { "[!][Quest] : �ȼ������� ��� ���ձ⸦ �����ּ���." });

        //Study
        talkData.Add(100, new string[] { "����ϱ⿣ ��Ʈ�� ���� ���.." });

        //Talk
        talkData.Add(1000, new string[] { "������ �����ٷ�?:3"});
        talkData.Add(2000, new string[] { "�� ������?:3" });

        //dataPiece
        talkData.Add(10000, new string[] { "������ ����1�� ȹ���ߴ�!" });
        talkData.Add(20000, new string[] { "������ ����2�� ȹ���ߴ�!" });
        talkData.Add(30000, new string[] { "������ ����3�� ȹ���ߴ�!" });
        talkData.Add(40000, new string[] { "������ ����4�� ȹ���ߴ�!" });
        talkData.Add(50000, new string[] { "������ ����5�� ȹ���ߴ�!" });
        talkData.Add(60000, new string[] { "������ ����6�� ȹ���ߴ�!" });
        talkData.Add(70000, new string[] { "������ ����7�� ȹ���ߴ�!" });
        talkData.Add(80000, new string[] { "������ ����8�� ȹ���ߴ�!" });
        talkData.Add(90000, new string[] { "������ ����9�� ȹ���ߴ�!" });
        talkData.Add(100000, new string[] { "������ ����10�� ȹ���ߴ�!" });


        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "��!:0", "�򴽴�:1"});
        talkData.Add(11 + 2000, new string[] { "�ȳ�:0", "Ǯ 3���� �����ٷ�?:1" });

        talkData.Add(20 + 1000, new string[] { "���� ��������!:3" });
        talkData.Add(20 + 2000, new string[] { "���� ��������!:3" });

        talkData.Add(30 + 2000, new string[] { "���� �峭�� �ٰ�:2" });

        //�ʻ�ȭ (0 : ���, 1 : ���ϱ�, 2 : ����, 3 : ȭ��)
        PortraitData.Add(1000 + 0, portraitArr[0]);
        PortraitData.Add(1000 + 1, portraitArr[1]);
        PortraitData.Add(1000 + 2, portraitArr[2]);
        PortraitData.Add(1000 + 3, portraitArr[3]);

        PortraitData.Add(2000 + 0, portraitArr[4]);
        PortraitData.Add(2000 + 1, portraitArr[5]);
        PortraitData.Add(2000 + 2, portraitArr[6]);
        PortraitData.Add(2000 + 3, portraitArr[7]);
    }


    //��ȭ ��������
    public string GetTalk(int id, int talkIndex)
    {
    
        if (!talkData.ContainsKey(id))
        {
                if (!talkData.ContainsKey(id - id % 10))
                {   //�⺻ ��縦 ������ ��               
                    if (talkIndex == talkData[id - id % 100].Length)
                        return null;
                    else
                        return talkData[id - id % 100][talkIndex];
                }
                else //�ش� ����Ʈ ���� �� ��簡 ���� �� �� ó�� ��� ������ ��
                {
                    if (talkIndex == talkData[id - id % 10].Length)
                        return null;
                    else
                        return talkData[id - id % 10][talkIndex];
                }
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    //�ʻ�ȭ ����
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return PortraitData[id + portraitIndex];
    }
}
