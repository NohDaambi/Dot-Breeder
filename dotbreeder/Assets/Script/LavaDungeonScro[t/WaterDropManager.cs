using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropManager : MonoBehaviour
{
    public GameObject waterDropBlue_gameObjcet;
    public GameObject waterDropBrown_gameObjcet;
    public GameObject waterDropGreen_gameObjcet;
    public GameObject waterDropOrange_gameObjcet;
    public GameObject waterDropWhite_gameObjcet;
    private void FixedUpdate() {
        StartCoroutine("WaterDropBrownTimeController");
        StartCoroutine("WaterDropBlueTimeController");
        StartCoroutine("WaterDropGreenTimeController");
        StartCoroutine("WaterDropOrangeTimeController");
        StartCoroutine("WaterDropWhiteTimeController");
    }
    IEnumerator WaterDropBlueTimeController()
    {
        if (WaterDropBlue.waterDropBlue_unVisibleTime > 0)
        {
            waterDropBlue_gameObjcet.gameObject.SetActive(false);
            WaterDropBlue.waterDropBlue_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropBlue_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropBrownTimeController()
    {
        if (WaterDropBrown.waterDropBrown_unVisibleTime > 0)
        {
            waterDropBrown_gameObjcet.gameObject.SetActive(false);
            WaterDropBrown.waterDropBrown_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropBrown_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropGreenTimeController()
    {
        if (WaterDropGreen.waterDropGreen_unVisibleTime > 0)
        {
            waterDropGreen_gameObjcet.gameObject.SetActive(false);
            WaterDropGreen.waterDropGreen_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropGreen_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropOrangeTimeController()
    {
        if (WaterDropOrange.waterDropOrange_unVisibleTime > 0)
        {
            waterDropOrange_gameObjcet.gameObject.SetActive(false);
            WaterDropOrange.waterDropOrange_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropOrange_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropWhiteTimeController()
    {
        if (WaterDropWhite.waterDropWhite_unVisibleTime > 0)
        {
            waterDropWhite_gameObjcet.gameObject.SetActive(false);
            WaterDropWhite.waterDropWhite_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropWhite_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
}
