using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestDungeonManager : MonoBehaviour
{
    public LevelBuilder m_LevelBuilder;
    private bool m_ReadyForInput;
    public Player m_Player;
    float waitingTime;
    public static bool ForestisDelay;

    private void Start()
    {
        waitingTime = 0.5f;
        ForestisDelay = true;
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        waitingTime -= Time.deltaTime;

        if (waitingTime <= 0)
        {
            ForestisDelay = false;
        }
    }

    
    void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        if (input.sqrMagnitude > 0.5)
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                if (ForestisDelay == false)
                {
                    m_Player.Move(input);
                }
                IsLevelComplete();
                
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

    bool IsLevelComplete() {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach (var box in boxes) {
            if (!box.m_OnCross) return false;
        }
        Debug.Log("clear");
        if(ForestDungeonScript.isForestDungeon1Clear == true && ForestDungeonScript.isForestDungeon2Clear == false)
        {
            ForestDungeonScript.isForestDungeon2Clear = true;
        }
        if (ForestDungeonScript.isForestDungeon1Clear == false)
        {
            ForestDungeonScript.isForestDungeon1Clear = true;
            LevelBuilder.m_CurrentLevel = 1;
        }
        //if Clear, you go to other scenes
        SceneManager.LoadScene("ForestDungeonClearRoom");
        return true;
    }
}