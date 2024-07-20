using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coinCount;
    public Text coinText; // Đối tượng UI Text để hiển thị số lượng đồng xu

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
        coinCount = 0;
        UpdateCoinText();
    }

    // Phương thức tăng số lượng đồng xu
    public void IncreaseCoinCount()
    {
        coinCount++;
        UpdateCoinText();
    }

    // Cập nhật số lượng đồng xu lên UI Text
    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
