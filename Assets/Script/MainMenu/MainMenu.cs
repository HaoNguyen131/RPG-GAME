using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void ExitGame()
    {
        // Kết thúc ứng dụng
        Application.Quit();
    } 

   }