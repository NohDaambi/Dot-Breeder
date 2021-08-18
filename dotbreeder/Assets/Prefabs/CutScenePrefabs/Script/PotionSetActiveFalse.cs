using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSetActiveFalse : MonoBehaviour
{
    public GameObject potion;

    public void DeletePotion()
    {
        potion.SetActive(false);
    }
}
