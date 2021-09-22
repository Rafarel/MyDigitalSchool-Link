using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip mainTheme;

    public void Play(AudioClip clip, bool loop = true)
    {
        source.clip = clip;
        source.loop = loop;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void PlayMainTheme()
    {
        Play(mainTheme);
    }
}
