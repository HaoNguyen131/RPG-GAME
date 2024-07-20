using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
