using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDungeonLevelController : MonoBehaviour
{
    public GameObject iceLevel1;
    public GameObject iceLevel2;
    private void Start()
    {
        iceLevel1.SetActive(true);
        iceLevel2.SetActive(false);
        if (IceDungeonScript.isIceDungeon1Clear == true && IceDungeonScript.isIceDungeon2Clear == false)
        {
            iceLevel1.SetActive(false);
            iceLevel2.SetActive(true);
        }
    }
}
