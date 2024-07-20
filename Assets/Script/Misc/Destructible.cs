using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;   // Prefab hiệu ứng phá hủy

    // Hàm được gọi khi có Collider2D va chạm với Collider2D của đối tượng này
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có thành phần DamageSource hay không
        if (other.gameObject.GetComponent<DamageSource>())
        {
            // Tạo ra một bản sao của prefab hiệu ứng phá hủy tại vị trí của đối tượng này
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            // Phá hủy đối tượng này
            Destroy(gameObject);
        }
    }
}
