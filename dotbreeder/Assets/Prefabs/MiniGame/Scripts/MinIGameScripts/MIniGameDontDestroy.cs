using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIniGameDontDestroy : MonoBehaviour
{

    private static bool MiniGameExist;

    void Awake()
    {
        //�ߺ�����
        if (!MiniGameExist)
        {
            MiniGameExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

}
