using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tăng số lượng đồng xu đã thu thập
            CoinManager.instance.IncreaseCoinCount();
            // Hủy đối tượng đồng xu
            Destroy(gameObject);
        }
    }
}
