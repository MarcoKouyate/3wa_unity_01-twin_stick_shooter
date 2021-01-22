using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public int level;
    public int duration;
    public float timeBetweenWaves;
    public GameObject[] waves;
}
