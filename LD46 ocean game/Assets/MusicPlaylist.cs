using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public bool shuffle;
    public List<AudioClip> MusicList;
    public AudioSource source;
    public int index;

    void start()
    {
        if (shuffle)
        {
            source.clip = MusicList[(int)Random.Range(0,MusicList.Capacity)];
        }
        else
        {
            source.clip = MusicList[0];
        }
        source.Play();

        
    }

    void update()
    {
        if (!source.isPlaying)
        {
            if (!shuffle)
            {
                index++;
                if (index == MusicList.Capacity)
                {
                    index = 0;
                }
            }
            else
            {
                index = Random.Range(0, MusicList.Capacity);
            }

            source.clip = MusicList[index];
            source.Play();
        }
    }
}

