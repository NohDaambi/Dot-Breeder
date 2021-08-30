using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
