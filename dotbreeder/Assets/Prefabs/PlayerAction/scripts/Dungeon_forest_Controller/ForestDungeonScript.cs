using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDungeonScript : MonoBehaviour
{
    public GameObject ForestDungeonClose;
    public GameObject ForestDungeonOpen;

    private void Start()
    {
        ForestDungeonClose.SetActive(true);
        ForestDungeonOpen.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("문식이 레벨 : " + GameManager.instance.DotLevel);
        if (GameManager.instance.DotLevel == 3)
        {
            ForestDungeonClose.SetActive(false);
            ForestDungeonOpen.SetActive(true);
        }
        if (GameManager.instance.DotLevel == 4)
        {
            ForestDungeonClose.SetActive(false);
            ForestDungeonOpen.SetActive(true);
        }
    }
}
