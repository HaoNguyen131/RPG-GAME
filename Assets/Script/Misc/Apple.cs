using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tìm đối tượng AppleCollector trong scene và gọi phương thức CollectApple
            AppleCollector appleCollector = FindObjectOfType<AppleCollector>();
            if (appleCollector != null)
            {
                appleCollector.CollectApple();
            }

            // Hủy đối tượng táo sau khi thu thập
            Destroy(gameObject);
        }
    }
}
