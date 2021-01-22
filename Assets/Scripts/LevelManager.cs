using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private HealthManager playerHealth;
    [SerializeField] private GameObject sceneManager;
    [SerializeField] private LevelData _level;
    [SerializeField] private IntVariable _enemyCount;

    private SceneChange _sceneChange;
    private float _startTime;
    private float _breakTime;
    private int _waveNumber;
    private int _gameDuration;
    private bool loadingWave;


    private void Awake()
    {
        _sceneChange = sceneManager.GetComponent<SceneChange>();
        _startTime = Time.time;
        _waveNumber = 1;
        _gameDuration = _level.duration;
        loadingWave = false;
        NextWave();
    }

    private void Update()
    {
        if (playerHealth.isDead() || GetElapsedTime() > _gameDuration)
        {
            Lose();
        }

        if(loadingWave)
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
        } else
        {
            Win();
        }
    }


    private void NextWave()
    {
        loadingWave = false;
        Debug.Log($"loading wave {_waveNumber} over {_level.waves.Length}");
        GameObject.Instantiate(_level.waves[_waveNumber - 1]);
        _enemyCount.value = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Win()
    {
        _sceneChange.loadScene("NierWin");
    }

    private void Lose()
    {
        _sceneChange.loadScene("NierGameOver");
    }

    public float GetRemainingTime()
    {
        return _gameDuration - GetElapsedTime();
    }

    public float GetElapsedTime()
    {
        return Time.time - _startTime;
    }
}
