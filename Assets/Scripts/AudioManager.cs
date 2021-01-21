using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();

        if (_source == null)
        {
            _source = gameObject.AddComponent<AudioSource>();
        }
    }

    // LOAD

    public void Load(AudioClip clip)
    {
        _source.clip = clip;
    }

    public void Load(AudioData audio)
    {
        Load(audio.clip);
    }


    // PLAY
    public void Play()
    {
        _source.Play();
    }

    public void Play(AudioClip clip)
    {
        Load(clip);
        Play();
    }

    public void Play(AudioData audio)
    {
        Load(audio.clip);
        Play();
    }

    static public AudioManager getFrom(GameObject caller)
    {
        AudioManager audioManager = caller.GetComponent<AudioManager>();

        if(audioManager == null)
        {
            audioManager = caller.AddComponent<AudioManager>();
        }

        return audioManager;
    }

}