using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool GettingKnockedBack { get; private set; } // Thuộc tính chỉ trạng thái hiện tại của Knockback

    [SerializeField] private float knockBackTime = 2f; // Thời gian Knockback

    private Rigidbody2D rb; // Rigidbody2D của đối tượng để áp dụng lực Knockback

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Lấy Rigidbody2D của đối tượng
    }

    public void GetKnockedBack(Transform damageSource, float knockBackThrust)
    {
        GettingKnockedBack = true; // Đặt trạng thái Knockback là true
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass; // Tính toán hướng và lực Knockback
        rb.AddForce(difference, ForceMode2D.Impulse); // Áp dụng lực Knockback lên Rigidbody2D
        StartCoroutine(KnockRoutine()); // Bắt đầu Coroutine để quản lý thời gian Knockback
    }

    private IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(knockBackTime); // Chờ đợi trong thời gian Knockback
        rb.velocity = Vector2.zero; // Đặt vận tốc của đối tượng về zero để ngừng di chuyển
        GettingKnockedBack = false; // Đặt lại trạng thái Knockback về false sau khi kết thúc Knockback
    }
}
//StartCoroutine là một phương thức trong Unity được sử dụng để bắt đầu thực thi một Coroutine.
//Coroutine là một cơ chế trong Unity cho phép thực hiện các tác vụ chờ đợi (delay)
//và thực hiện tuần tự (sequence) mà không cần phải chặn (block) luồng chính của game.