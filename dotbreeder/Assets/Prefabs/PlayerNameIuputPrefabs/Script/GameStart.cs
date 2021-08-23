using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject _inputPlayerName;

    public void InputPlayerName()
    {
        _inputPlayerName.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
