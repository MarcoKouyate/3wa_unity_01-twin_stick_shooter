using UnityEngine;

[CreateAssetMenu]
public class AudioData : ScriptableObject
{
    public string title;
    public AudioClip clip;
    public float volume = 1f;
}
