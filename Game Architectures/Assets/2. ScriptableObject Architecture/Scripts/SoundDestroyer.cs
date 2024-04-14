using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroyer : MonoBehaviour
{
    private AudioSource audioSource;

    private float clipLength;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Start()
    {
        clipLength = audioSource.clip.length;

        yield return new WaitForSeconds(clipLength);

        Destroy(gameObject);
    }
}
