using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1; // Số lượng sát thương được gây ra

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Lấy component EnemyHealth từ đối tượng va vào
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

        // Gọi phương thức TakeDamage của enemyHealth nếu tồn tại
        enemyHealth?.TakeDamage(damageAmount);
    }
}
