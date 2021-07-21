using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelBuilder m_LevelBuilder;
    private bool m_ReadyForInput;
    public Player m_Player;

    private void Start() {
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<Player>();
    }
    void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        if (input.sqrMagnitude > 0.5)
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(input);
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
        //if Clear, you go to other scenes
        return true;
    }
}