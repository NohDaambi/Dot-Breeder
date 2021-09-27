using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Combination combine;

    //�ǹ�
    public void ImageControl(int num)
    {
        combine.image.sprite = combine.CombineBuildingArr[num].sprite;
        combine.imageIng.sprite = combine.CombineBuildingArr[num].sprite;
        combine.imageEnd.sprite = combine.CombineBuildingArr[num].sprite;
    }

    //������
    public void ImageControlItem(int num)
    {
        combine.image.sprite = combine.CombineItemArr[num].sprite;
        combine.imageIng.sprite = combine.CombineItemArr[num].sprite;
        combine.imageEnd.sprite = combine.CombineItemArr[num].sprite;
    }

    //�� �� �ǹ�
    public void TreeHouse()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�볪����";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(0);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�볪����";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 1;
        combine.ProduceCount();
    }
    public void Bed()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetBedTime = 15;
        combine.timer.combineTIme = combine.GetBedTime;
        combine.Title.text = "��ź ���ħ��";
        combine.time.text = "���� �ð� : " + combine.GetBedTime.ToString();
        ImageControl(1);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "��ź ���ħ��";
        combine.timeIng.text = "���� �ð� : " + combine.GetBedTime.ToString();        
        combine.houseManager.CurrentCombinging = 2;
        combine.ProduceCount();
    }
    public void Stove()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 2;
        combine.RequiredB = 2;
        combine.GetStoveTime = 20;
        combine.timer.combineTIme = combine.GetStoveTime;
        combine.Title.text = "������";
        combine.time.text = "���� �ð� : " + combine.GetStoveTime.ToString();
        ImageControl(2);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "������";
        combine.timeIng.text = "���� �ð� : " + combine.GetStoveTime.ToString();
        combine.houseManager.CurrentCombinging = 3;
        combine.ProduceCount();
    }
    public void Table()
    {
        combine.RequiredR = 3;
        combine.RequiredG = 2;
        combine.RequiredB = 3;
        combine.GetTableTime = 25;
        combine.timer.combineTIme = combine.GetTableTime;
        combine.Title.text = "���̺� ��";
        combine.time.text = "���� �ð� : " + combine.GetTableTime.ToString();
        ImageControl(3);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "���̺� ��";
        combine.timeIng.text = "���� �ð� : " + combine.GetTableTime.ToString();       
        combine.houseManager.CurrentCombinging = 4;
        combine.ProduceCount();
    }

    //���� �� �ǹ�
    public void Igloo()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�̱۷�";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(4);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�̱۷�";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 5;
        combine.ProduceCount();
    }
    public void IceBed()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 9;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "��� ħ��";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(5);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "��� ħ��";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 6;
        combine.ProduceCount();
    }
    public void FishingTool()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "���ÿ�ǰ ������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(6);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "���ÿ�ǰ ������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 7;
        combine.ProduceCount();
    }
    public void Aquarium()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 12;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 8;
        combine.ProduceCount();
    }

    //�縷 �� �ǹ�
    public void Tent()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 12;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "õ��";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "õ��";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 9;
        combine.ProduceCount();
    }
    public void H_Bed()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 2;
        combine.GetHouseTime = 12;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�ظ� ħ��";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�ظ� ħ��";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 10;
        combine.ProduceCount();
    }
    public void Plate()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 12;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "����, �׸�";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "����, �׸�";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 11;
        combine.ProduceCount();
    }
    public void MudStove()
    {
        combine.RequiredR = 3;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 12;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "���� ȭ��";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "���� ȭ��";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 12;
        combine.ProduceCount();
    }


    //1~2 ���� ���� ������
    public void Milk()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "����";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(0);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "����";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void jjokjjok2()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(1);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void DDalang2()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 2;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(2);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void SoccerBall()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�౸��";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(3);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�౸��";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void WoodenDoll()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(4);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Candy()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "����";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(5);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "����";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }

    //�� �� ������
    public void Beanie()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "���";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(6);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "���";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();       
        combine.ProduceCount();
    }
    public void Driver()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "����̹�";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(7);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "����̹�";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Axe()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "����";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(8);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "����";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Hammer()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 3;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "��ġ";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(9);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "��ġ";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void ForestGlove()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�尩";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(10);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�尩";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void GreatAxe()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "����";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(11);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "����";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }

    //���� �� ������
    public void FishingRod()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 3;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "���˴�";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(12);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "���˴�";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Worm()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(13);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Bandana()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�ΰ�";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(14);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�ΰ�";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void GreatFishingRod()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 2;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "���˴�";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(15);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "���˴�";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void IceGlove()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 3;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�尩";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(16);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�尩";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void LandingNet()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "��ä";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(17);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "��ä";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }

    //�縷 �� ������
    public void Chur()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 3;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "��";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(18);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "��";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void NailClipper()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "�������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(19);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "�������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Hat()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "����";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(20);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "����";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Apron()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "��ġ��";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(21);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "��ġ��";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Cosmetic()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "ȭ��ǰ";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(22);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "ȭ��ǰ";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Dust()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //���ձ� �ؽ�Ʈ        
        combine.Title.text = "��������";
        combine.time.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        ImageControlItem(23);
        //������ �ؽ�Ʈ
        combine.TitleIng.text = "��������";
        combine.timeIng.text = "���� �ð� : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
}
