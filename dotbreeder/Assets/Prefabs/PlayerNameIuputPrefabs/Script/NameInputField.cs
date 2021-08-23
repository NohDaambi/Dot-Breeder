using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class NameInputField : MonoBehaviour
{
    private PlayerNameManager thePlayer;
    public TextMeshProUGUI _playerName;
    public TMP_InputField inputField;
    public TextMeshProUGUI errorMasage;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerNameManager>();
        inputField.characterLimit = 20;
        inputField.onValueChanged.AddListener(
            (word) => inputField.text = Regex.Replace(word, @"[^0-9a-zA-Z가-힣]", "")
        );
    }
    public void InputPlayerName()
    {
        //확인버튼 눌렀을때
        if (inputField.text.Length == 0)
        {
            StartCoroutine(FadeOutToTextAlpha(1f, errorMasage.GetComponent<TextMeshProUGUI>()));
            errorMasage.text = "이름을 입력해주세요";
        }
        else if (inputField.text.Length >= 12)
        {
            StartCoroutine(FadeOutToTextAlpha(1f, errorMasage.GetComponent<TextMeshProUGUI>()));
            errorMasage.text = "글자가 너무 많습니다";
        }
        else
        {
            thePlayer.characterName = _playerName.text;
            Debug.Log(thePlayer.characterName);
        }
    }

    public IEnumerator FadeOutToTextAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        i.color = Color.red;
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
