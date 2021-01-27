using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] LevelManager _levelManager;
    [SerializeField] private IntVariable _enemyCount;
    [SerializeField] private LevelData _level;

    private void Awake()
    {
        loadingWave = false;
        _waveNumber = 1;
        NextWave();
    }

    private void Update()
    {
        if (loadingWave)
        {
            LoadingNextWave();
        }
        else
        {
            if (_enemyCount.value <= 0)
            {
                CheckNextStep();
            }
        }
    }

    private void LoadingNextWave()
    {
        if (Time.time > _breakTime + _level.timeBetweenWaves)
        {
            NextWave();
        }
    }


    private void CheckNextStep()
    {
        _waveNumber++;

        if (_waveNumber <= _level.waves.Length)
        {
            loadingWave = true;
            _breakTime = Time.time;
        }
        else
        {
            _levelManager.Win();
        }
    }


    private void NextWave()
    {
        loadingWave = false;
        GameObject.Instantiate(_level.waves[_waveNumber - 1]);
        _enemyCount.value = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private bool loadingWave;
    private float _breakTime;
    private int _waveNumber;
}
