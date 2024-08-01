using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private AppleCollector appleCollector;
    private UIManager uiManager;

    private void Start()
    {
        appleCollector = FindObjectOfType<AppleCollector>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (appleCollector != null && appleCollector.CanAdvanceToNextScene())
            {
                if (uiManager != null)
                {
                    uiManager.ShowEndLevelCanvas();
                }
            }
            else
            {
                Debug.Log("Bạn cần thu thập đủ số táo yêu cầu để tiếp tục!");
                if (uiManager != null)
                {
                    uiManager.ShowNotification("Bạn cần thu thập đủ số táo yêu cầu để tiếp tục!");
                }
            }
        }
    }
}
