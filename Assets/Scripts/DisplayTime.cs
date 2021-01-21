using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private Text text;

    public void Awake()
    {
        text = GetComponent<Text>();
    }

    public void Update()
    {
        int remaining = (int) levelManager.GetRemainingTime();
        

        if ( remaining >= 0)
        {
            string minutes = Mathf.Floor(remaining / 60).ToString("00");
            string seconds = (remaining % 60).ToString("00");
            text.text = $"{minutes}:{seconds}";
        }
            
    }
}
