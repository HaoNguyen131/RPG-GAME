using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Tốc độ di chuyển của đối tượng địch

    private Rigidbody2D rb; // Rigidbody của đối tượng địch
    private Vector2 moveDir; // Hướng di chuyển của đối tượng địch
    private Knockback knockback; // Đối tượng quản lý lực đẩy khi bị đánh

    private void Awake()
    {
        knockback = GetComponent<Knockback>(); // Lấy component Knockback từ đối tượng này
        rb = GetComponent<Rigidbody2D>(); // Lấy component Rigidbody2D từ đối tượng này       
    }

    private void FixedUpdate()
    {
        if (knockback.GettingKnockedBack) { return; } // Nếu đối tượng đang bị đẩy, không thực hiện di chuyển

        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime)); // Di chuyển đối tượng theo hướng và tốc độ đã tính toán
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition; // Thiết lập hướng di chuyển của đối tượng đến vị trí targetPosition
    }
}
