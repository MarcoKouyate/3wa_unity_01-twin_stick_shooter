using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioData[] audioClips;
    [SerializeField] private bool removeDouble = false;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        CheckRedondance();
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

    public void Load(string name)
    {
        bool found = false;
        foreach (AudioData audio in audioClips)
        {
            if (string.Equals(audio.title, name))
            {
                found = true;
                Load(audio);
            }
        }

        if (!found)
        {
            Debug.LogError($"AudioData {name} is not loaded in Audio Manager");
        }
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

    public void Play(string name)
    {
        Load(name);
        Play();
    }


    // CHECK

    private void CheckRedondance()
    {
        List<string> audioNames = new List<string>();
        List<AudioData> newAudioClips = new List<AudioData>();

        foreach (AudioData audio in audioClips)
        {
            if (audioNames.Contains(audio.title))
            {
                Debug.LogWarning($"{audio.title} is loaded several times in AudioManager");

                if (removeDouble)
                {
                    continue;
                }
            }

            audioNames.Add(audio.title);
            newAudioClips.Add(audio);
        }

        if (removeDouble && audioNames.Count < audioClips.Length)
        {
            Debug.LogWarning("Redundant files in AudioManager have been deleted.");
        }

        audioClips = newAudioClips.ToArray();
    }

}