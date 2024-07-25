using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int scoreCount;
    public Text scoreText; // Đối tượng UI Text để hiển thị điểm

    private void Awake()
    {
        // Đảm bảo CoinManager là duy nhất
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scoreCount = 0;
        UpdateScoreText();
    }

    // Phương thức tăng điểm
    public void IncreaseCoinCount()
    {
        scoreCount++;
        UpdateScoreText();
    }

    // Cập nhật số lượng điểm
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }
}
