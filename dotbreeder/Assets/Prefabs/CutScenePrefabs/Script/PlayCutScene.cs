using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayCutScene : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject button;
    public void PlayCutScene1()
    {
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
        button.gameObject.SetActive(false);
    }
}
