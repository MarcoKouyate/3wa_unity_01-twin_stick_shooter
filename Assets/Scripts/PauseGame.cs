using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            Pause();
        }
    }

    private void Pause()
    {
        if(pauseMenu.activeSelf)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        } else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
