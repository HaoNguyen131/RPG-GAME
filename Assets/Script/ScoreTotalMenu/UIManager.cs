using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // Import for UI elements
using TMPro; // Import for TextMeshPro

public class UIManager : MonoBehaviour
{
    public GameObject endLevelCanvas;
    public TextMeshProUGUI notificationText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        endLevelCanvas.SetActive(false);
        if (notificationText != null)
        {
            notificationText.gameObject.SetActive(false); // Ẩn thông báo lúc đầu
        }
    }

    public void ShowEndLevelCanvas()
    {
        endLevelCanvas.SetActive(true);
        Time.timeScale = 0f; // Dừng thời gian
    }

    public void ShowNotification(string message)
    {
        if (notificationText != null)
        {
            notificationText.text = message;
            notificationText.gameObject.SetActive(true);
            Invoke("HideNotification", 2f); // Ẩn thông báo sau 2 giây
        }
    }

    private void HideNotification()
    {
        if (notificationText != null)
        {
            notificationText.gameObject.SetActive(false);
        }
    }

    public void OnNextLevelButtonClicked()
    {
        Time.timeScale = 1f; // Khôi phục thời gian trước khi chuyển cảnh
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Scene1")
        {
            SceneManager.LoadScene("LoadingScene2");
        }
        else if (currentSceneName == "Scene2")
        {
            SceneManager.LoadScene("LoadingScene3");
        }
        else if (currentSceneName == "Scene3")
        {
            SceneManager.LoadScene("LoadingScene4");
        }
        else if (currentSceneName == "Scene4")
        {
            SceneManager.LoadScene("CreditScene");
        }
    }

    public void OnPlayAgainButtonClicked()
    {
        Time.timeScale = 1f; // Khôi phục thời gian trước khi khởi động lại cảnh
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void OnMenuButtonClicked()
    {
        Time.timeScale = 1f; // Khôi phục thời gian trước khi chuyển về Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
