using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds; //CPS
    public GameObject EndCursor;
    public bool isAnim;

    Text msgText;
    AudioSource audioSource;
    public AudioClip Clip;

    string targetMsg;
    int index;
    float interval;


    void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        //start  anim
        interval = 1.0f / CharPerSeconds;        

        isAnim = true;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        //end anim
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];

        //Sound
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            //audioSource.Play();
            SoundManager.instance.SFXPlay("TypeSound", Clip);

        index++;

        //recursive
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}

