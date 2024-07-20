using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverMenu; // Tham chiếu tới UI Canvas chứa các nút Menu và Play Again
    public PlayerHealth playerHealth; // Tham chiếu tới script quản lý sức khỏe của người chơi

    private void Start()
    {
        // Đảm bảo gameOverMenu bị tắt khi bắt đầu game
        gameOverMenu.SetActive(false);
    }

    private void Update()
    {
        // Kiểm tra nếu người chơi đã chết
        if (playerHealth.health <= 0)
        {
            // Gọi hàm GameOver
            GameOver();
        }
    }

    void GameOver()
    {
        // Tạm dừng game
        Time.timeScale = 0;
        // Hiển thị menu game over
        gameOverMenu.SetActive(true);
    }

    // Hàm để quay về menu chính
    public void GoToMenu()
    {
        // Bỏ tạm dừng game
        Time.timeScale = 1;
        // Tải lại scene menu
        SceneManager.LoadScene("MainMenu");
    }

    // Hàm để chơi lại từ đầu
    public void PlayAgain()
    {
        // Bỏ tạm dừng game
        Time.timeScale = 1;
        // Tải lại scene hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
