using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    [Tooltip("Thời gian quy định cho mỗi màn chơi (giây).")]
    public float levelTime = 60f; // Thời gian mặc định cho level, có thể chỉnh sửa trong Inspector
    private float timeLeft;
    private bool isRunning = true;
    public Text timerText;
    public GameManager gameManager; // Thêm tham chiếu tới GameManager

    void Start()
    {
        timeLeft = levelTime;
        UpdateTimerText();
        StartCoroutine(Countdown());
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: " + timeLeft.ToString("F2") + "s";
        }
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0 && isRunning)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            UpdateTimerText();
        }

        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetElapsedTime()
    {
        return levelTime - timeLeft;
    }

    void GameOver()
    {
        // Hiển thị menu Game Over
        gameManager.GameOver(); // Gọi hàm GameOver từ GameManager
    }
}