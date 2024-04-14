using Architectures.GameObjectComponent;
using DesignPatterns.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private List<AudioSource> audioSources = new List<AudioSource>();

    [SerializeField]
    private List<string> soundNames;
    [SerializeField]
    private List<AudioClip> audioClips;

    private AudioSource GetFreeAudioSource()
    {
        foreach(AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return null;
    }

    public void PlaySound(string soundName)
    {
        AudioSource source = GetFreeAudioSource();

        int index = soundNames.IndexOf(soundName);

        source.clip = audioClips[index];
        source.Play();
    }
}
