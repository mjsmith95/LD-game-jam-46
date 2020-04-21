using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audiosource;
    public bool randomPlay = false;
    private int currentClipIndex = 0;

    void Start()
    {
        //audiosource = FindObjectOfType<AudioSource>();
        audiosource.loop = false;
    }

    void Update()
    {
        if (!audiosource.isPlaying)
        {
            AudioClip nextClip;
            if (randomPlay)
            {
                nextClip = GetRandomClip();
            }
            else
            {
                nextClip = GetNextClip();
            }
            currentClipIndex++;
            if (currentClipIndex == clips.Length) currentClipIndex = 0;
            audiosource.clip = nextClip;
            audiosource.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    private AudioClip GetNextClip()
    {
        return clips[(currentClipIndex + 1) % clips.Length];
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}

