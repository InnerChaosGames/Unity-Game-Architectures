using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Architectures.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Managers/Audio Manager", fileName = "Audio Manager")]
    public class AudioManagerSO : ScriptableObject
    {
        [SerializeField]
        private float soundVolume;
        [SerializeField]
        private List<AudioClip> audioClips = new List<AudioClip>();
        [SerializeField]
        private List<string> clipNames = new List<string>();


        public AudioSource SoundObject;

        public void PlaySFXClip(string clipName, Vector3 soundPos)
        {
            var audio = Instantiate(SoundObject, soundPos, Quaternion.identity);

            var clip = audioClips[clipNames.IndexOf(clipName)];
            audio.clip = clip;
            audio.volume = soundVolume;
            audio.Play();
        }
    }
}