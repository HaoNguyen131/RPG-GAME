using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3; // Sức khỏe ban đầu của đối tượng địch
    [SerializeField] private GameObject deathVFXPrefab; // Prefab hiệu ứng khi đối tượng chết
    [SerializeField] private float knockBackThrust = 15f; // Lực đẩy khi đối tượng bị đánh

    private int curentHealth; // Sức khỏe hiện tại của đối tượng địch
    private Knockback knockback; // Đối tượng quản lý lực đẩy khi bị đánh
    private Flash flash; // Đối tượng quản lý hiệu ứng chớp chớp khi bị đánh

    private void Awake()
    {
        flash = GetComponent<Flash>(); // Lấy component Flash từ đối tượng này
        knockback = GetComponent<Knockback>(); // Lấy component Knockback từ đối tượng này
    }

    private void Start()
    {
        curentHealth = startingHealth; // Khởi tạo sức khỏe hiện tại bằng sức khỏe ban đầu
    }

    public void TakeDamage(int damage)
    {
        curentHealth -= damage; // Giảm sức khỏe hiện tại khi bị đánh
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust); // Gọi hàm Knockback để đẩy đối tượng khi bị đánh
        StartCoroutine(flash.FlashRoutine()); // Bắt đầu Coroutine để thực hiện hiệu ứng chớp chớp khi bị đánh
        StartCoroutine(CheckDetectDeathRoutine()); // Bắt đầu Coroutine để kiểm tra và xử lý khi đối tượng chết
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime()); // Chờ đợi cho đến khi kết thúc hiệu ứng chớp chớp
        DetectDeath(); // Gọi hàm DetectDeath để kiểm tra xem đối tượng đã chết chưa
    }

    public void DetectDeath()
    {
        if (curentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity); // Tạo hiệu ứng khi đối tượng chết tại vị trí hiện tại
            Destroy(gameObject); // Hủy đối tượng địch sau khi chết
        }
    }
}
