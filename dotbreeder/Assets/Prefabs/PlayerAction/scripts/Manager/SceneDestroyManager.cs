using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDestroyManager : MonoBehaviour
{
    public GameObject GameManger;
    public GameObject SoundManger;
    public GameObject MiniGameManger;

    private static bool SceneManagerExist;

    void Awake()
    {
        Time.timeScale = 1;

        //중복삭제
        if (!SceneManagerExist)
        {
            SceneManagerExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Update()
    {
        //던전에서는 끄기
        if (SceneManager.GetActiveScene().name == "Forest Dungeon" || SceneManager.GetActiveScene().name == "Ice Dungeon" || SceneManager.GetActiveScene().name == "Desert Dungeon")
        {
            GameManger.SetActive(false);
            SoundManger.SetActive(false);
            MiniGameManger.SetActive(false);

        }
        if (SceneManager.GetActiveScene().name != "Forest Dungeon" && SceneManager.GetActiveScene().name != "Ice Dungeon" && SceneManager.GetActiveScene().name != "Desert Dungeon")
        {
            GameManger.SetActive(true);
            SoundManger.SetActive(true);
            MiniGameManger.SetActive(true);
        }
    }
}
