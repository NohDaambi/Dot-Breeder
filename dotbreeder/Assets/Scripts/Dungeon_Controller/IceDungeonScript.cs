using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDungeonScript : MonoBehaviour
{
    public GameObject DungeonClose;
    public GameObject DungeonOpen;
    public static bool isIceDungeon1Clear = false;
    public static bool isIceDungeon2Clear = false;

    private void Start()
    {
        DungeonClose.SetActive(true);
        DungeonOpen.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.DotLevel == 3 && isIceDungeon1Clear == false && isIceDungeon2Clear == false)
        {
            DungeonClose.SetActive(false);
            DungeonOpen.SetActive(true);
        }
        else if (GameManager.instance.DotLevel == 4 && isIceDungeon1Clear == true && isIceDungeon2Clear == false)
        {
            DungeonClose.SetActive(false);
            DungeonOpen.SetActive(true);
        }
        else if (GameManager.instance.DotLevel == 4 && isIceDungeon1Clear == true && isIceDungeon2Clear == true)
        {
            DungeonClose.SetActive(true);
            DungeonOpen.SetActive(false);
        }
    }
}
