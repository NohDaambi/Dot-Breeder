using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDungeonScript : MonoBehaviour
{
    public GameObject ForestDungeonClose;
    public GameObject ForestDungeonOpen;
    public static bool isForestDungeon1Clear = false;
    public static bool isForestDungeon2Clear = false;

    private void Start()
    {
        ForestDungeonClose.SetActive(true);
        ForestDungeonOpen.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.DotLevel == 3 && isForestDungeon1Clear == false && isForestDungeon2Clear == false)
        {
            ForestDungeonClose.SetActive(false);
            ForestDungeonOpen.SetActive(true);
        }
        else if (GameManager.instance.DotLevel == 4 && isForestDungeon1Clear == true && isForestDungeon2Clear == false)
        {
            ForestDungeonClose.SetActive(false);
            ForestDungeonOpen.SetActive(true);
        }
        else if(GameManager.instance.DotLevel == 4 && isForestDungeon1Clear == true && isForestDungeon2Clear == true)
        {
            ForestDungeonClose.SetActive(true);
            ForestDungeonOpen.SetActive(false);
        }
    }
}
