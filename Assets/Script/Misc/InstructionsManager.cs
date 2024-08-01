using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    public GameObject instructionsPanel; // Panel chứa hướng dẫn
    public GameObject menuPanel; // Panel chứa menu chính
    public GameObject howToPlayButton; // Nút "How to Play"

    void Start()
    {
        instructionsPanel.SetActive(false); // Ẩn hướng dẫn ban đầu
        if (menuPanel != null)
        {
            menuPanel.SetActive(true); // Hiển thị menu chính ban đầu
        }
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true); // Hiển thị hướng dẫn
        howToPlayButton.SetActive(false); // Ẩn nút "How to Play"
        if (menuPanel != null)
        {
            menuPanel.SetActive(false); // Ẩn menu chính
        }
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false); // Ẩn hướng dẫn
        howToPlayButton.SetActive(true); // Hiển thị lại nút "How to Play"
        if (menuPanel != null)
        {
            menuPanel.SetActive(true); // Hiển thị lại menu chính
        }
    }
}
