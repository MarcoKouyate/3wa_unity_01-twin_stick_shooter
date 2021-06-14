using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string startScene;
    [SerializeField] private SceneChange sceneManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(sceneManager);
        sceneManager.loadScene(startScene);
    }
}
