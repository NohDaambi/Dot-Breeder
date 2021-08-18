using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class NameInputField : MonoBehaviour
{
    private GameManager thePlayer;
    public TextMeshProUGUI _playerName;
    public TMP_InputField inputField;

    void Start()
    {
        thePlayer = FindObjectOfType<GameManager>();
        inputField.characterLimit = 12;
        inputField.onValueChanged.AddListener(
            (word) => inputField.text = Regex.Replace(word, @"[^0-9a-zA-Z가-힣]", "")
        );
    }
    public void InputPlayerName()
    {
        //확인버튼 눌렀을때
        thePlayer.characterName = _playerName.text;
        Debug.Log(thePlayer.characterName);
    }
}
