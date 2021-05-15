using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;

    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();


    public static bool Initialized { get => initialized;}


    internal static void Initialize(AudioSource Source)
    {
        initialized = true;
        audioSource = Source;
        audioClips.Add(AudioClipName.ButtonClick, 
            Resources.Load<AudioClip>(AudioClipName.ButtonClick.ToString()));
    }

    public static void Play(AudioClipName clipName)
    {
        audioSource.PlayOneShot(audioClips[clipName]);
    }
}
