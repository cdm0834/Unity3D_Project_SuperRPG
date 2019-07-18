using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public class Sound
    {
        public string soundName;
        public AudioClip clip;
    }




public class SoundManager : MonoBehaviour
    {
    public static SoundManager Smanager;
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    [SerializeField] AudioClip[] bgm;
    [SerializeField] AudioClip[] sfxSounds;
    public bool bgmOn;
    public int BgmNum;
    private void Awake()
    {
        bgm = new AudioClip[5];
        bgm[0] = (AudioClip)Resources.Load("SoundFolder/BGM/A Hat in Time OST - New Adventure");
        bgm[1] = (AudioClip)Resources.Load("SoundFolder/BGM/A Hat in Time OST - No More Mafia Boss");
        bgm[2] = (AudioClip)Resources.Load("SoundFolder/BGM/A Hat in Time OST - Subcon Village");
        bgm[3] = (AudioClip)Resources.Load("SoundFolder/BGM/A Hat in Time OST - Toilet Of Doom");
        bgm[4] = (AudioClip)Resources.Load("SoundFolder/BGM/A Hat in Time OST - Get Lost OST Extended");
        Smanager = this;
 
    }

 
    private void Start()
      {
        bgmOn = true;
        BgmNum = 0;
      }

    private void Update()
    {
        PlayBgm();
    }

    public void PlaySE(string _soundName)
    {
        for(int i=0; i<sfxSounds.Length; i++)
        {
            if(_soundName == sfxSounds[i].name)
            {
                for(int j = 0; j<sfxPlayer.Length; j++)
                {
                    if(!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfxSounds[i];
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 효과음 사용중");
                return;
            }
        }
        Debug.Log("효과음 없음");
    }


    public void PlayBgm()
    {
        if (bgmOn)
        {
            bgmPlayer.clip = bgm[BgmNum];
            bgmPlayer.Play();
            bgmOn = false;
        }
    }

  }

