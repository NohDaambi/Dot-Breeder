using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource bgSound;
    public AudioClip[] bgList;

    public static SoundManager instance;

    void Awake()
    {
        //이동간 중복파괴
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoad;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //사운드 가져오기
    public void SFXPlay(string sfxName, AudioClip clip)
    {        
        GameObject Go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = Go.AddComponent<AudioSource>();

        //output으로 볼륨조절
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];

        //재생
        audiosource.clip = clip;
        audiosource.Play();

        //클립의 길이가 끝나면 소리 파괴
        Destroy(Go, clip.length);
    }

    //씬 별로 다른 배경음악
    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        //씬 이름별로 배열 찾아 출력
        for (int i = 0; i < bgList.Length; i++)
        {
            if(arg0.name == bgList[i].name)
                BgSoundPlay(bgList[i]);
        }

    }

    //배경음악 반복재생
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGSound")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.1f;
        bgSound.Play();
    }

    //BGM Sound 조절
    public void BGSoundVolume(float val)
    {
        mixer.SetFloat("BGSound", Mathf.Log10(val) * 20);
    }
    //SFX Sound 조절
    public void SFXSoundVolume(float val)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }
    //음소거 버튼
    public void MuteAllSound()
    {
        AudioListener.volume = 0;
    }
    public void UnMuteAllSound()
    {
        AudioListener.volume = 1;
    }
}
