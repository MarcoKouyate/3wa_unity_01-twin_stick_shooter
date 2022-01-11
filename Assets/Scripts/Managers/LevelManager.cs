using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private HealthManager playerHealth;
    [SerializeField] private LevelData _level;
    [SerializeField] private SceneChange _sceneChange;
    [SerializeField] private string _nextScene;
    public bool IsTimed { get; private set; }

    private MemoTools.Timer _timer;

    private void Awake()
    {
        _timer = new MemoTools.Timer(_level.duration, false);

        IsTimed = (_level.duration > 0);
    }

    private void Update()
    {
        if (playerHealth.isDead() || IsTimed && _timer.IsExpired)
        {
            Lose();
        }
    }

    public void Win()
    {
        if(_nextScene == "") {
            _sceneChange.nextLevel();
        } else {
            _sceneChange.loadScene(_nextScene);
        }
        
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
