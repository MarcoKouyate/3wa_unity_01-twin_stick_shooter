using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private HealthManager playerHealth;
    [SerializeField] private LevelData _level;
    [SerializeField] private SceneChange _sceneChange;

    private int _gameDuration;
    private MemoTools.Timer _timer;

    private void Awake()
    {

        _timer = new MemoTools.Timer(_level.duration, false);
    }

    private void Update()
    {
        if (playerHealth.isDead() || _timer.IsExpired)
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
        return _timer.Remaining;
    }

    public float GetElapsedTime()
    {
        return _timer.Elapsed;
    }
}
