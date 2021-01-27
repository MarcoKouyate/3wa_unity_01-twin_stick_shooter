using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private HealthManager playerHealth;
    [SerializeField] private LevelData _level;

    private SceneChange _sceneChange;
    private float _startTime;
    private int _gameDuration;


    private void Awake()
    {
        _sceneChange = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneChange>();
        _startTime = Time.time;
        _gameDuration = _level.duration;
    }

    private void Update()
    {
        if (playerHealth.isDead() || GetElapsedTime() > _gameDuration)
        {
            Lose();
        }
    }

    public void Win()
    {
        _sceneChange.loadScene("NierWin");
    }

    public void Lose()
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
