using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int scoreCount;
    public Text scoreText; // Đối tượng UI Text để hiển thị điểm
    public Text rankText; // Đối tượng UI Text để hiển thị hạng

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
        UpdateRankText();
    }

    // Phương thức tăng điểm
    public void IncreaseCoinCount()
    {
        scoreCount++;
        UpdateScoreText();
        UpdateRankText();
    }

    // Cập nhật số lượng điểm
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    // Cập nhật hạng dựa trên số lượng đồng xu
    private void UpdateRankText()
    {
        string rank = "F"; // Xếp hạng mặc định

        if (scoreCount >= 25)
        {
            rank = "S";
        }
        else if (scoreCount >= 20)
        {
            rank = "A";
        }
        else if (scoreCount >= 15)
        {
            rank = "B";
        }
        else if (scoreCount >= 10)
        {
            rank = "C";
        }
        else if (scoreCount >= 5)
        {
            rank = "D";
        }

        rankText.text = "Rank: " + rank;
    }
}
