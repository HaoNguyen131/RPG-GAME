using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth; // Tham chiếu đến script PlayerHealth
    public int damage; // Số lượng sát thương gây ra

    void Start()
    {
       
    }

    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Kiểm tra xem đối tượng va chạm có thẻ "Player" không
        if (other.gameObject.CompareTag("Player"))
        {
            // Gây sát thương cho người chơi
            pHealth.TakeDamage(damage);
        }
    }
}