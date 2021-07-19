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
        //�̵��� �ߺ��ı�
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

    //���� ��������
    public void SFXPlay(string sfxName, AudioClip clip)
    {        
        GameObject Go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = Go.AddComponent<AudioSource>();

        //output���� ��������
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];

        //���
        audiosource.clip = clip;
        audiosource.Play();

        //Ŭ���� ���̰� ������ �Ҹ� �ı�
        Destroy(Go, clip.length);
    }

    //�� ���� �ٸ� �������
    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        //�� �̸����� �迭 ã�� ���
        for (int i = 0; i < bgList.Length; i++)
        {
            if(arg0.name == bgList[i].name)
                BgSoundPlay(bgList[i]);
        }

    }

    //������� �ݺ����
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGSound")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.1f;
        bgSound.Play();
    }

    //BGM Sound ����
    public void BGSoundVolume(float val)
    {
        mixer.SetFloat("BGSound", Mathf.Log10(val) * 20);
    }
    //SFX Sound ����
    public void SFXSoundVolume(float val)
    {
        mixer.SetFloat("SFX", Mathf.Log10(val) * 20);
    }
    //���Ұ� ��ư
    public void MuteAllSound()
    {
        AudioListener.volume = 0;
    }
    public void UnMuteAllSound()
    {
        AudioListener.volume = 1;
    }
}
