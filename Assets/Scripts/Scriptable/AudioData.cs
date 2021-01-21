using UnityEngine;

[CreateAssetMenu]
public class AudioData : ScriptableObject
{
    public string audioName;
    public AudioClip audioClip;
    public float volume = 1f;
}
