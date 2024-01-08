using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource _audioSource;

    public AudioClip LevelEnd => Resources.Load<AudioClip>(SoundPath.LevelEnd);
    public AudioClip Pop => Resources.Load<AudioClip>(SoundPath.Pop);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    public void StopPlaying()
    {
        _audioSource.Stop();
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        _audioSource.volume = volume;
        _audioSource.PlayOneShot(clip);
    }
}
