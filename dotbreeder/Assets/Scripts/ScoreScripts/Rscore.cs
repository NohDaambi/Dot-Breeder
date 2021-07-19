using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rscore : MonoBehaviour
{
    Text score;
    public int count;
    public GameManager manager;
    

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "R: " + manager.Rcount.ToString();
    }
}
