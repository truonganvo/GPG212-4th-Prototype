using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public List<AudioClip> audioClips;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomClip()
    {
        int clipIndex = Random.Range(0, audioClips.Count);
        audioSource.clip = audioClips[clipIndex];
        audioSource.Play();
    }
}
