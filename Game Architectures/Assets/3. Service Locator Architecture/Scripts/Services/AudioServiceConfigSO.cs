using System;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    [CreateAssetMenu(fileName = "AudioServiceConfig", menuName = "Architectures/Service Locator/Audio Service Config")]
    public class AudioServiceConfigSO : ScriptableObject
    {
        [SerializeField] [Min(1)] private int poolSize = 8;
        [SerializeField] private List<SoundDefinition> sounds = new();

        public int PoolSize => poolSize;
        public IReadOnlyList<SoundDefinition> Sounds => sounds;
    }

    [Serializable]
    public class SoundDefinition
    {
        [SerializeField] private string id;
        [SerializeField] private AudioClip clip;
        [SerializeField] [Range(0f, 1f)] private float volume = 1f;

        public string Id => id;
        public AudioClip Clip => clip;
        public float Volume => volume;
    }
}
