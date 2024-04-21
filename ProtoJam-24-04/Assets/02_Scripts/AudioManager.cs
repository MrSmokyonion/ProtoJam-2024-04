using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static AudioManager;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioClip bgmClip;
    [SerializeField]
    private AudioClip[] sfxClips = new AudioClip[9];

    public float bgmVolume = 5;
    public float sfxVolume = 10;

    private AudioSource bgmPlayer;
    private AudioSource[] sfxPlayers;

    private int channels = 9;
    private int channalIndex;
    //private bool[] IsPlaying = { false, false, false, false, false, false, false, false };
    
    public enum Sfx { //ȿ����
        Footsteps, //
        Pickup,//
        Throw,//
        Putin, //
        Working, //
        Complete, //
        Shipment, //
        Crashing, 
        Button
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
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
            sfxPlayers[i].clip = sfxClips[i];
        }
    }
    
    public void PlaySfx(Sfx sfx)
    {
        if (!sfxPlayers[(int)sfx].isPlaying)
        {
            sfxPlayers[(int)sfx].Play();
        }
        //for (int i = 0; i < sfxPlayers.Length; i++)
        //{
        //    int loopindex = (i + channalIndex) % sfxPlayers.Length;

        //    if (sfxPlayers[loopindex].isPlaying)
        //        continue;

        //    channalIndex = loopindex;
        //    sfxPlayers[loopindex].clip = sfxClips[(int)sfx];
        //    sfxPlayers[loopindex].Play();
        //    break;
        //}

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
