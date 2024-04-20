using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioClip bgmClip;
    [SerializeField]
    private AudioClip[] sfxClips = new AudioClip[8];

    public float bgmVolume = 5;
    public float sfxVolume = 10;

    private AudioSource bgmPlayer;
    private AudioSource[] sfxPlayers;

    private int channels = 8;
    private int channalIndex;


    public enum Sfx { //효과음
        Footsteps, 
        Pickupdown, 
        PutMaterial, 
        FinalmachineWork, 
        CompleteChair, 
        CompleteMaterial, 
        CrashChair, 
        ButtonClick
    }
    /*
    0 발소리
    1 물건 들기, 놓기 효과음
    2 재료를 기계에 넣는 효과음
    3 의자기계 작동 효과음
    4 의자 완성 효과음
    5 재료 가공 완료 효과음
    6 의자 충돌 효과음
    7 버튼 클릭 효과음
    */

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayBgm();
        Init();
    }

    void Init()
    {
        sfxPlayers = new AudioSource[channels]; 

        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = gameObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].loop = false;
            sfxPlayers[i].volume = sfxVolume;
        }
    }
    
    public void PlaySfx(Sfx sfx)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopindex = (i + channalIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopindex].isPlaying)
                continue;

            channalIndex = loopindex;
            sfxPlayers[loopindex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopindex].Play();

            break;
        }
        
    }

    public void PlayBgm()
    {
        bgmPlayer = gameObject.AddComponent<AudioSource>();
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        bgmPlayer.Play();
    }
}
