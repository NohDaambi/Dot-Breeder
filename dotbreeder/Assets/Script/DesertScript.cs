using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertScript : MonoBehaviour
{
    public static float unVisibleTime = 1.0f;
    public GameObject road;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
       
        if (unVisibleTime > 0)
        {
            unVisibleTime -= Time.deltaTime;
            road.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            road.GetComponent<Renderer>().enabled = false;
        }
    }
}
