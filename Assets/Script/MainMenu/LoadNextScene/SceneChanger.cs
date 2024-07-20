using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Tên của Scene muốn chuyển đến
    public string sceneName;

    // Hàm này sẽ được gọi khi đối tượng va chạm với một Trigger Collider 2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng va chạm có tag là "Player"
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
