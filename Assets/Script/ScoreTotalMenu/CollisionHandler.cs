using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public UIManager uiManager;
    public Timer timer; // Thêm tham chiếu tới Timer

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timer.StopTimer(); // Dừng timer khi va chạm
            float elapsedTime = timer.GetElapsedTime();
            Debug.Log("Total time played: " + elapsedTime + " seconds");

            uiManager.ShowEndLevelCanvas();
        }
    }
}
