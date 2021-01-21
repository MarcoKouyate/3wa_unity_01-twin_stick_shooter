using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioData music;

    private void Start()
    {
        GameObject speaker = GameObject.Find("AudioSpeaker");

        if (speaker != null)
        {
            AudioManager audioManager = speaker.GetComponent<AudioManager>();

            if (audioManager != null)
            {
                audioManager.Play(music);

            } else {
                Debug.LogError("Music Manager can't send audio to Audio Manager because no AudioManager component is attached to AudioSpeaker gameObject");
            }

        } else {
            Debug.LogError("Music Manager can't send audio to Audio Manager because AudioSpeaker gameObject is missing");
        }
       
    }
}
