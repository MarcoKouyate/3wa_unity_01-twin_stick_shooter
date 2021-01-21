using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private HealthManager playerHealth;

    [SerializeField]
    private IntVariable _enemyCount;

    [SerializeField]
    private GameObject sceneManager;

    private SceneChange _sceneChange;

    private void Awake()
    {
        _sceneChange = sceneManager.GetComponent<SceneChange>();
    }

    private void Update()
    {
        if (_enemyCount.value <= 0)
        {
            Win();
        }

        if (playerHealth.isDead())
        {
            Lose();
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
}
