using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIniGameDontDestroy : MonoBehaviour
{

    private static bool MiniGameExist;

    void Awake()
    {
        //중복삭제
        if (!MiniGameExist)
        {
            MiniGameExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

}
