using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int _gameDuration;

    [SerializeField]
    private HealthManager playerHealth;

    [SerializeField]
    private IntVariable _enemyCount;

    [SerializeField]
    private GameObject sceneManager;

    private SceneChange _sceneChange;
    private float _startTime;

    private void Awake()
    {
        _sceneChange = sceneManager.GetComponent<SceneChange>();
        _startTime = Time.time;
    }

    private void Update()
    {
        
        if (playerHealth.isDead() || GetElapsedTime() > _gameDuration)
        {
            Lose();
        }

        if (_enemyCount.value <= 0)
        {
            Win();
        }
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
