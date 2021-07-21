using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropCollision : MonoBehaviour
{
    Animator waterDropCollision;

    private void Awake() {
        waterDropCollision = gameObject.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Plate")
        {
            //waterDropCollision.SetTrigger("water_drop_collision");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Plate")
        {
            ///waterDropCollision.ResetTrigger("water_drop_collision");
        }
    }
}
