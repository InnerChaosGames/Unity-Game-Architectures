using System;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public sealed class AudioService : IAudioService, IDisposable
    {
        private readonly Dictionary<string, SoundDefinition> _sounds = new();
        private readonly List<AudioSource> _audioSources = new();
        private readonly GameObject _root;

        public AudioService(AudioServiceConfigSO config)
        {
            _root = new GameObject("AudioService");

            int poolSize = 8;

            if (config != null)
            {
                poolSize = Mathf.Max(1, config.PoolSize);

                foreach (SoundDefinition sound in config.Sounds)
                {
                    if (sound == null || string.IsNullOrWhiteSpace(sound.Id) || sound.Clip == null)
                    {
                        continue;
                    }

                    _sounds[sound.Id] = sound;
                }
            }

            for (int index = 0; index < poolSize; index++)
            {
                AudioSource audioSource = _root.AddComponent<AudioSource>();
                _audioSources.Add(audioSource);
            }
        }

        public void Dispose()
        {
            if (_root != null)
            {
                UnityEngine.Object.Destroy(_root);
            }
        }

        public void PlaySound(string soundId)
        {
            if (_sounds.TryGetValue(soundId, out SoundDefinition sound) == false)
            {
                return;
            }

            AudioSource freeSource = GetFreeAudioSource();

            if (freeSource == null)
            {
                return;
            }

            freeSource.clip = sound.Clip;
            freeSource.volume = sound.Volume;
            freeSource.Play();
        }

        private AudioSource GetFreeAudioSource()
        {
            for (int index = 0; index < _audioSources.Count; index++)
            {
                if (_audioSources[index].isPlaying == false)
                {
                    return _audioSources[index];
                }
            }

            return null;
        }
    }
}
