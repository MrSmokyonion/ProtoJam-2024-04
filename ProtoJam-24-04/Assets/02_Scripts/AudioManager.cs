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


    public enum Sfx { //ȿ����
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
    0 �߼Ҹ�
    1 ���� ���, ���� ȿ����
    2 ��Ḧ ��迡 �ִ� ȿ����
    3 ���ڱ�� �۵� ȿ����
    4 ���� �ϼ� ȿ����
    5 ��� ���� �Ϸ� ȿ����
    6 ���� �浹 ȿ����
    7 ��ư Ŭ�� ȿ����
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
