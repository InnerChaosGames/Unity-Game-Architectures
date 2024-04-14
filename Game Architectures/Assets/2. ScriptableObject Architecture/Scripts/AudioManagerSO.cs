using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "Audio/Sound Manager", fileName ="Audio Manager")]
public class AudioManagerSO : ScriptableObject
{
    private IObjectPool<AudioSource> audioSourcePool;

    private static AudioManagerSO instance;
    public static AudioManagerSO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<AudioManagerSO>("Sound Manager");
            }
            return instance;
        }
    }

    public AudioSource SoundObject;

    public static void PlaySFXClip(AudioClip clip, Vector3 soundPos, float volume)
    {
        var audio = Instantiate(Instance.SoundObject, soundPos, Quaternion.identity);

        audio.clip = clip;
        audio.Play();
    }
}
