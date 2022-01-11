using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private Text textComponent;

    public void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    public void Start()
    {
        gameObject.SetActive(levelManager.IsTimed);
    }

    public void Update()
    {
        int remaining = (int) levelManager.GetRemainingTime();

        

        if ( remaining >= 0)
        {
            string minutes = Mathf.Floor(remaining / 60).ToString("00");
            string seconds = (remaining % 60).ToString("00");
            textComponent.text = $"{minutes}:{seconds}";
        }
            
    }
}
