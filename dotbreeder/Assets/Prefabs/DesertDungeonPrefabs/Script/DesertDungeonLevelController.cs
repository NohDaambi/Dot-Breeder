using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertDungeonLevelController : MonoBehaviour
{
    public GameObject DesertLevel1;
    public GameObject DesertLevel2;
    private void Start()
    {
        DesertLevel1.SetActive(true);
        DesertLevel2.SetActive(false);
        if (DesertDungeonScript.isDesertDungeon1Clear == true && DesertDungeonScript.isDesertDungeon2Clear == false)
        {
            DesertLevel1.SetActive(false);
            DesertLevel2.SetActive(true);
        }
    }
}
