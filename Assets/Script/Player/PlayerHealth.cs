using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{   
    public float health;
    public float maxHealth1;
    public Image healthBar;
    public Text damageText;
    [SerializeField] private int maxHealth = 3;// Số lượng máu tối đa của người chơi
    [SerializeField] private float knockBackThrustAmount = 10f;// Lực đẩy khi bị đẩy lùi sau khi bị tấn công
    [SerializeField] private float dameRecoveryTime = 1f;// Thời gian hồi phục sau khi bị tấn công

    private int currentHealth;// Số lượng máu hiện tại của người chơi
    private bool canTakeDamage = true;// Biểu thị liệu người chơi có thể nhận sát thương hay không
    private Knockback knockBack;// Thành phần để xử lý lực đẩy
    private Flash flash;// Thành phần để xử lý hiệu ứng Flash

    private void Awake()
    {
        flash = GetComponent<Flash>();// Lấy tham chiếu đến thành phần Flash gắn trên cùng GameObject
        knockBack = GetComponent<Knockback>();// Lấy tham chiếu đến thành phần Knockback gắn trên cùng GameObject
    }

    private void Start()
    {
        maxHealth1 = health;
        currentHealth = maxHealth;// Khởi tạo giá trị ban đầu cho currentHealth bằng maxHealth
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();// Lấy tham chiếu đến thành phần EnemyAI của đối tượng va chạm

        if (enemy && canTakeDamage)
        {
            TakeDamage(1);// Gọi hàm TakeDamage để giảm máu người chơi
            knockBack.GetKnockedBack(other.gameObject.transform, knockBackThrustAmount); // Gọi hàm GetKnockedBack từ thành phần Knockback để đẩy lùi người chơi
            StartCoroutine(flash.FlashRoutine());// Bắt đầu coroutine FlashRoutine để hiển thị hiệu ứng Flash khi người chơi bị tấn công
        }


        healthBar.fillAmount = Mathf.Clamp(health / maxHealth1, 0, 1);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        canTakeDamage = false;// Ngừng cho phép người chơi nhận sát thương
        //currentHealth -= damageAmount;// Giảm máu của người chơi theo damageAmount
        health -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());// Bắt đầu coroutine DamageRecoveryRoutine để tính toán thời gian hồi phục
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(dameRecoveryTime);// Chờ đợi trong dameRecoveryTime giây
        canTakeDamage = true;// Cho phép người chơi nhận sát thương lại
    }
}

// thuật toán được sử dụng SerializeField: Đây là một thuộc tính được sử dụng để hiển thị các trường private trong Inspector của Unity để có thể chỉnh sửa giá trị từ giao diện người dùng mà không cần phải là public.

//Awake(): Phương thức này được gọi khi một đối tượng được khởi tạo trong Scene. Nó thường được sử dụng để thiết lập các tham chiếu giữa các thành phần của đối tượng.

//Start(): Phương thức này được gọi vào thời điểm bắt đầu của một đối tượng trong Scene, sau khi Awake() đã được gọi. Nó thường được sử dụng để thiết lập trạng thái ban đầu của đối tượng.

//OnCollisionEnter2D(Collision2D other): Phương thức này được gọi khi đối tượng này va chạm với một đối tượng khác có Collider2D và RigidBody2D. Collision2D là thông tin về va chạm giữa hai Collider2D.

//GetComponent<T>(): Phương thức này được sử dụng để lấy thành phần của loại T từ đối tượng hiện tại hoặc từ một đối tượng khác.

//StartCoroutine(): Phương thức này được sử dụng để bắt đầu một Coroutine trong Unity, cho phép thực thi các hàm theo thời gian mà không cản trở luồng chính của game.

//IEnumerator: Đây là một loại của C# dùng để xây dựng các phương thức cho Coroutine, cho phép các phương thức này có thể tạm dừng và tiếp tục thực thi sau một khoảng thời gian nhất định.

//yield return new WaitForSeconds(time): Đây là một câu lệnh trong IEnumerator, cho phép Coroutine tạm dừng thực thi trong một khoảng thời gian nhất định trước khi tiếp tục.