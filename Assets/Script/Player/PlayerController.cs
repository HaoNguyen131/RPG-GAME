using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } } // Thuộc tính chỉ định hướng của người chơi (hướng trái/phải)
    public static PlayerController Instance; // Biến tĩnh để truy cập đối tượng người chơi từ bất kỳ đâu trong game

    [SerializeField] private float moveSpeed = 1f; // Tốc độ di chuyển của người chơi
    [SerializeField] private float dashSpeed = 4f; // Tốc độ khi thực hiện động tác Dash
    [SerializeField] private TrailRenderer myTrailRenderer; // Đối tượng Trail Renderer để tạo hiệu ứng vệt sau khi Dash

    private PlayerControls playerControls; // Đối tượng để điều khiển hành động của người chơi
    private Vector2 movement; // Vector di chuyển của người chơi
    private Rigidbody2D rb; // Rigidbody của người chơi
    private Animator myAnimator; // Animator để điều khiển hoạt hình
    private SpriteRenderer mySpriteRender; // Sprite Renderer để điều khiển hình ảnh
    private Knockback knockback; // Component để xử lý Knockback của người chơi
    private float startingMoveSpeed; // Tốc độ di chuyển ban đầu của người chơi

    private bool facingLeft = false; // Biến xác định hướng nhìn của người chơi (trái/phải)
    private bool isDashing = false; // Biến xác định người chơi có đang Dash không

    private void Awake()
    {
        Instance = this; // Gán Instance của PlayerController bằng đối tượng hiện tại
        playerControls = new PlayerControls(); // Khởi tạo PlayerControls để điều khiển hành động
        rb = GetComponent<Rigidbody2D>(); // Lấy Rigidbody2D của đối tượng người chơi
        myAnimator = GetComponent<Animator>(); // Lấy Animator của đối tượng người chơi
        mySpriteRender = GetComponent<SpriteRenderer>(); // Lấy SpriteRenderer của đối tượng người chơi
        knockback = GetComponent<Knockback>(); // Lấy Knockback component của đối tượng người chơi
    }

    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash(); // Gán hàm Dash cho sự kiện Dash từ PlayerControls
        startingMoveSpeed = moveSpeed; // Lưu tốc độ di chuyển ban đầu
    }

    private void OnEnable()
    {
        playerControls.Enable(); // Kích hoạt PlayerControls để bắt đầu nhận input
    }

    private void Update()
    {
        PlayerInput(); // Xử lý input từ người chơi
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection(); // Điều chỉnh hướng nhìn của người chơi
        Move(); // Di chuyển người chơi
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>(); // Đọc giá trị di chuyển từ input của người chơi

        // Cập nhật các thông số cho Animator để điều khiển hoạt hình
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        if (knockback.GettingKnockedBack) { return; } // Nếu đang bị Knockback thì không thực hiện di chuyển

        // Di chuyển người chơi theo hướng và tốc độ di chuyển hiện tại
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition; // Lấy vị trí chuột trên màn hình
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position); // Chuyển đổi vị trí của người chơi sang tọa độ màn hình

        // Điều chỉnh hướng nhìn của người chơi dựa trên vị trí của chuột so với người chơi
        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true; // Đảo hình ảnh ngược lại để nhìn về bên trái
            facingLeft = true; // Đặt biến facingLeft là true
        }
        else
        {
            mySpriteRender.flipX = false; // Giữ nguyên hình ảnh để nhìn về bên phải
            facingLeft = false; // Đặt biến facingLeft là false
        }
    }

    private void Dash()
    {
        if (!isDashing) // Nếu không đang Dash
        {
            isDashing = true; // Đặt biến Dash là true
            moveSpeed *= dashSpeed; // Tăng tốc độ di chuyển lên tốc độ Dash
            myTrailRenderer.emitting = true; // Bật hiệu ứng vệt sau khi Dash
            StartCoroutine(EndDashRoutine()); // Bắt đầu Coroutine để kết thúc Dash
        }
    }

    private IEnumerator EndDashRoutine()
    {
        float dashTime = .2f; // Thời gian Dash
        float dashCD = .25f; // Thời gian cooldown sau Dash

        yield return new WaitForSeconds(dashTime); // Chờ trong thời gian Dash
        moveSpeed = startingMoveSpeed; // Khôi phục tốc độ di chuyển ban đầu
        myTrailRenderer.emitting = false; // Tắt hiệu ứng vệt sau khi Dash
        yield return new WaitForSeconds(dashCD); // Chờ trong thời gian cooldown
        isDashing = false; // Đặt biến Dash là false
    }
}
