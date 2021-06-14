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
            pauseMenu.SetActive(false);
        } else
        {
            pauseMenu.SetActive(true);
        }
    }
}
