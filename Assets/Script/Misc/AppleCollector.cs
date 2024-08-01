using UnityEngine;
using UnityEngine.UI; // Thêm dòng này nếu dùng Text UI
using TMPro; // Thêm dòng này nếu dùng TextMeshPro

public class AppleCollector : MonoBehaviour
{
    public int applesCollected = 0;
    public int requiredApples = 3;
    public TextMeshProUGUI appleCountText; // Sử dụng TextMeshProUGUI nếu dùng TextMeshPro
    // public Text appleCountText; // Sử dụng Text nếu dùng Text UI thông thường

    void Start()
    {
        UpdateAppleCountText();
    }

    // Gọi hàm này khi người chơi thu thập được một quả táo
    public void CollectApple()
    {
        applesCollected++;
        UpdateAppleCountText();
    }

    // Cập nhật text hiển thị số lượng táo đã thu thập
    private void UpdateAppleCountText()
    {
        if (appleCountText != null)
        {
            appleCountText.text = applesCollected + "/" + requiredApples;
        }
    }

    // Kiểm tra nếu người chơi đủ điều kiện để chuyển scene
    public bool CanAdvanceToNextScene()
    {
        return applesCollected >= requiredApples;
    }

}
