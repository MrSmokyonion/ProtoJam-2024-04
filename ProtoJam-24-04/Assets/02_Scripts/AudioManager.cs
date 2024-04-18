using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip bgmClip;
    public float bgmVolume;
    private AudioSource bgmPlayer;

    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    private AudioSource[] sfxPlayers;
    private int channalIndex;

    public enum Sfx { hm }

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
