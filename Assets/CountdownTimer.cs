using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeLimitScene1 = 60f; // Thời gian cho màn 1
    public float timeLimitScene2 = 45f; // Thời gian cho màn 2
    public float timeLimitScene3 = 30f; // Thời gian cho màn 3
    private float timeRemaining;
    public Text timerText;
    public GameObject gameOverMenu;

    void Start()
    {
        SetTimeLimit(); // Thiết lập thời gian giới hạn cho màn chơi hiện tại
        gameOverMenu.SetActive(false);
    }

    void SetTimeLimit()
    {
        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            case "Scene1":
                timeRemaining = timeLimitScene1;
                break;
            case "Scene2":
                timeRemaining = timeLimitScene2;
                break;
            case "Scene3":
                timeRemaining = timeLimitScene3;
                break;
            // Thêm case cho các màn chơi khác
            default:
                timeRemaining = timeLimitScene1; // Mặc định là thời gian cho màn 1
                break;
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            GameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
    }

    void GameOver()
    {
        gameOverMenu.SetActive(true);
    }
}
