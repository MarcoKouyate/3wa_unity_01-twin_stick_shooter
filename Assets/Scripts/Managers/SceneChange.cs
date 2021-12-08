using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void nextLevel() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Scene Count " + SceneManager.sceneCount + "Scene Index " + nextSceneIndex);

        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
