using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Combination combine;

    //건물
    public void ImageControl(int num)
    {
        combine.image.sprite = combine.CombineBuildingArr[num].sprite;
        combine.imageIng.sprite = combine.CombineBuildingArr[num].sprite;
        combine.imageEnd.sprite = combine.CombineBuildingArr[num].sprite;
    }

    //아이템
    public void ImageControlItem(int num)
    {
        combine.image.sprite = combine.CombineItemArr[num].sprite;
        combine.imageIng.sprite = combine.CombineItemArr[num].sprite;
        combine.imageEnd.sprite = combine.CombineItemArr[num].sprite;
    }

    //숲 섬 건물
    public void TreeHouse()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "통나무집";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(0);
        //조합중 텍스트
        combine.TitleIng.text = "통나무집";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
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
        combine.Title.text = "라탄 요람침대";
        combine.time.text = "제작 시간 : " + combine.GetBedTime.ToString();
        ImageControl(1);
        //조합중 텍스트
        combine.TitleIng.text = "라탄 요람침대";
        combine.timeIng.text = "제작 시간 : " + combine.GetBedTime.ToString();        
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
        combine.Title.text = "벽난로";
        combine.time.text = "제작 시간 : " + combine.GetStoveTime.ToString();
        ImageControl(2);
        //조합중 텍스트
        combine.TitleIng.text = "벽난로";
        combine.timeIng.text = "제작 시간 : " + combine.GetStoveTime.ToString();
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
        combine.Title.text = "테이블 톱";
        combine.time.text = "제작 시간 : " + combine.GetTableTime.ToString();
        ImageControl(3);
        //조합중 텍스트
        combine.TitleIng.text = "테이블 톱";
        combine.timeIng.text = "제작 시간 : " + combine.GetTableTime.ToString();       
        combine.houseManager.CurrentCombinging = 4;
        combine.ProduceCount();
    }

    //얼음 섬 건물
    public void Igloo()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "이글루";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(4);
        //조합중 텍스트
        combine.TitleIng.text = "이글루";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
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
        //조합기 텍스트        
        combine.Title.text = "썰매 침대";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(5);
        //조합중 텍스트
        combine.TitleIng.text = "썰매 침대";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
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
        //조합기 텍스트        
        combine.Title.text = "낚시용품 진열대";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(6);
        //조합중 텍스트
        combine.TitleIng.text = "낚시용품 진열대";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
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
        //조합기 텍스트        
        combine.Title.text = "수족관";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //조합중 텍스트
        combine.TitleIng.text = "수족관";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 8;
        combine.ProduceCount();
    }

    //사막 섬 건물
    public void Tent()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 12;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "천막";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //조합중 텍스트
        combine.TitleIng.text = "천막";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
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
        //조합기 텍스트        
        combine.Title.text = "해먹 침대";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //조합중 텍스트
        combine.TitleIng.text = "해먹 침대";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
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
        //조합기 텍스트        
        combine.Title.text = "접시, 그릇";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //조합중 텍스트
        combine.TitleIng.text = "접시, 그릇";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
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
        //조합기 텍스트        
        combine.Title.text = "진흙 화로";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControl(7);
        //조합중 텍스트
        combine.TitleIng.text = "진흙 화로";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.houseManager.CurrentCombinging = 12;
        combine.ProduceCount();
    }


    //1~2 레벨 공통 아이템
    public void Milk()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "분유";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(0);
        //조합중 텍스트
        combine.TitleIng.text = "분유";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void jjokjjok2()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "쪽쪽이";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(1);
        //조합중 텍스트
        combine.TitleIng.text = "쪽쪽이";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void DDalang2()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 2;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "딸랑이";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(2);
        //조합중 텍스트
        combine.TitleIng.text = "딸랑이";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void SoccerBall()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "축구공";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(3);
        //조합중 텍스트
        combine.TitleIng.text = "축구공";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void WoodenDoll()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "목각인형";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(4);
        //조합중 텍스트
        combine.TitleIng.text = "목각인형";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Candy()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 10;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "사탕";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(5);
        //조합중 텍스트
        combine.TitleIng.text = "사탕";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }

    //숲 섬 아이템
    public void Beanie()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "비니";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(6);
        //조합중 텍스트
        combine.TitleIng.text = "비니";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();       
        combine.ProduceCount();
    }
    public void Driver()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "드라이버";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(7);
        //조합중 텍스트
        combine.TitleIng.text = "드라이버";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Axe()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "도끼";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(8);
        //조합중 텍스트
        combine.TitleIng.text = "도끼";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Hammer()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 3;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "망치";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(9);
        //조합중 텍스트
        combine.TitleIng.text = "망치";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void ForestGlove()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "장갑";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(10);
        //조합중 텍스트
        combine.TitleIng.text = "장갑";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void GreatAxe()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 2;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "도끼";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(11);
        //조합중 텍스트
        combine.TitleIng.text = "도끼";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }

    //얼음 섬 아이템
    public void FishingRod()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 3;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "낚싯대";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(12);
        //조합중 텍스트
        combine.TitleIng.text = "낚싯대";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Worm()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "지렁이";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(13);
        //조합중 텍스트
        combine.TitleIng.text = "지렁이";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Bandana()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "두건";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(14);
        //조합중 텍스트
        combine.TitleIng.text = "두건";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void GreatFishingRod()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 2;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "낚싯대";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(15);
        //조합중 텍스트
        combine.TitleIng.text = "낚싯대";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void IceGlove()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 3;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "장갑";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(16);
        //조합중 텍스트
        combine.TitleIng.text = "장갑";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void LandingNet()
    {
        combine.RequiredR = 2;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "뜰채";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(17);
        //조합중 텍스트
        combine.TitleIng.text = "뜰채";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }

    //사막 섬 아이템
    public void Chur()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 3;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "츄르";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(18);
        //조합중 텍스트
        combine.TitleIng.text = "츄르";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void NailClipper()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "손톱깎이";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(19);
        //조합중 텍스트
        combine.TitleIng.text = "손톱깎이";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Hat()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "모자";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(20);
        //조합중 텍스트
        combine.TitleIng.text = "모자";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Apron()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "앞치마";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(21);
        //조합중 텍스트
        combine.TitleIng.text = "앞치마";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Cosmetic()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "화장품";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(22);
        //조합중 텍스트
        combine.TitleIng.text = "화장품";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
    public void Dust()
    {
        combine.RequiredR = 1;
        combine.RequiredG = 1;
        combine.RequiredB = 1;
        combine.GetHouseTime = 7;
        combine.timer.combineTIme = combine.GetHouseTime;
        //조합기 텍스트        
        combine.Title.text = "먼지털이";
        combine.time.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        ImageControlItem(23);
        //조합중 텍스트
        combine.TitleIng.text = "먼지털이";
        combine.timeIng.text = "제작 시간 : " + combine.GetHouseTime.ToString();
        combine.ProduceCount();
    }
}
