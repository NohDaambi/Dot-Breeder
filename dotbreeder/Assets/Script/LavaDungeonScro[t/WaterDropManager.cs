using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropManager : MonoBehaviour
{
    public GameObject waterDropBrown;
    void Start()
    {
        
    }

    private void FixedUpdate() {
        if (WaterDropCollision.waterDropBrown_unVisibleTime > 0)
        {
            waterDropBrown.gameObject.SetActive(false);
            WaterDropCollision.waterDropBrown_unVisibleTime -= Time.deltaTime;
            //Debug.Log(WaterDropCollision.waterDropBrown_unVisibleTime);
        }
        else
        {
            waterDropBrown.gameObject.SetActive(true);
        }
    }
}
