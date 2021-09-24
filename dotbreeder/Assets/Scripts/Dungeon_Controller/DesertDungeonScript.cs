using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertDungeonScript : MonoBehaviour
{
    public GameObject DungeonClose;
    public GameObject DungeonOpen;
    public static bool isDesertDungeon1Clear = false;
    public static bool isDesertDungeon2Clear = false;

    private void Start()
    {
        DungeonClose.SetActive(true);
        DungeonOpen.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.DotLevel == 3 && isDesertDungeon1Clear == false && isDesertDungeon2Clear == false)
        {
            DungeonClose.SetActive(false);
            DungeonOpen.SetActive(true);
        }
        else if (GameManager.instance.DotLevel == 4 && isDesertDungeon1Clear == true && isDesertDungeon2Clear == false)
        {
            DungeonClose.SetActive(false);
            DungeonOpen.SetActive(true);
        }
        else if (GameManager.instance.DotLevel == 4 && isDesertDungeon1Clear == true && isDesertDungeon2Clear == true)
        {
            DungeonClose.SetActive(true);
            DungeonOpen.SetActive(false);
        }
    }
}
