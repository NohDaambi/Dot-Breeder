using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{

    public int Id;
    public bool isNpc;
    public bool isStudy;
    public bool isCombination;
    public bool isDataPiece;
    public bool isPlant;

    void Awake()
    {
        Time.timeScale = 1;
    }
}
