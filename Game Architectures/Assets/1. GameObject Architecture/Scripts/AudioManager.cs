using Architectures.GameObjectComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> audioSources = new List<AudioSource>();

    [SerializeField]
    private AudioClip deathAudioClip;

    private EnemySpawner spawner;

    private void Awake()
    {
        spawner = GetComponent<EnemySpawner>();
        spawner.OnEnemySpawned += HandleEnemySpawned;
    }

    private void HandleEnemySpawned(EnemyStats enemy)
    {
        enemy.OnDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath(Stats stats)
    {
        var source = GetFreeAudioSource();
        if (source != null)
        {
            source.clip = deathAudioClip;
            source.Play();
        }
    }

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
}
