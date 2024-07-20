using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private AudioClip slashSound;// âm thanh khi chém
    [SerializeField] private GameObject slashAnimPrefab; // Prefab của animation khi đánh
    [SerializeField] private Transform slashAnimSpawnPoint; // Điểm sinh animation đánh
    [SerializeField] private Transform weaponCollider; // Collider của vũ khí
    [SerializeField] private float swordAttackCD = .5f; // Thời gian chờ giữa các lần đánh

    private PlayerControls playerControls; // Điều khiển người chơi
    private Animator myAnimator; // Animator của vũ khí
    private PlayerController playerController; // Điều khiển người chơi
    private ActiveWeapon activeWeapon; // Vũ khí đang hoạt động
    private bool attackButtomDown, isAttacking = false; // Biến xác định đang đánh và đang tấn công
    private GameObject slashAnim; // Đối tượng animation khi đánh
    private AudioSource audioSource;
    private Animator animator;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();//âm thanh 
        animator = GetComponent<Animator>(); // Sword có Animator
        playerController = GetComponentInParent<PlayerController>(); // Lấy thông tin điều khiển từ PlayerController
        activeWeapon = GetComponentInParent<ActiveWeapon>(); // Lấy thông tin vũ khí từ ActiveWeapon
        myAnimator = GetComponent<Animator>(); // Lấy Animator của vũ khí
        playerControls = new PlayerControls(); // Khởi tạo điều khiển người chơi
    }

    private void OnEnable()
    {
        playerControls.Enable(); // Kích hoạt điều khiển người chơi khi kích hoạt vũ khí
    }

    void Start()
    {
        playerControls.Combat.Attack.started += _ => StartAttacking(); // Bắt đầu tấn công khi người chơi bắt đầu tấn công
        playerControls.Combat.Attack.canceled += _ => StopAttacking(); // Ngừng tấn công khi người chơi ngừng tấn công
    }

    private void Update()
    {
        MouseFollowWithOffset(); // Theo dõi chuột với sự chênh lệch
        if (Input.GetButtonDown("Fire1"))// Kiểm tra nếu người chơi nhấn nút tấn công (ví dụ: chuột trái)
        {
            Attack();
        }
    }

    private void StartAttacking()
    {
        attackButtomDown = true; // Đánh dấu đang giữ nút tấn công
    }

    private void StopAttacking()
    {
        attackButtomDown = false; // Đánh dấu không giữ nút tấn công
    }

    private void Attack()
    {
        if (attackButtomDown && !isAttacking)
        {
            isAttacking = true; // Bắt đầu tấn công
            myAnimator.SetTrigger("Attack"); // Kích hoạt animation đánh
            weaponCollider.gameObject.SetActive(true); // Kích hoạt Collider của vũ khí
            slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity); // Tạo animation đánh từ Prefab
            slashAnim.transform.parent = this.transform.parent; // Thiết lập animation là con của người chơi
            StartCoroutine(AttackCDRoutine()); // Bắt đầu Coroutine để quản lý thời gian chờ giữa các lần tấn công
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
            audioSource.PlayOneShot(slashSound);//khi người chơi chém kiếm thì phát nhạc
        }
    }

    private IEnumerator AttackCDRoutine()
    {
        yield return new WaitForSeconds(swordAttackCD); // Chờ đợi trong thời gian chờ giữa các lần tấn công
        isAttacking = false; // Kết thúc tấn công
    }

    public void DoneAttackingAnimeEvent()
    {
        weaponCollider.gameObject.SetActive(false); // Ngừng kích hoạt Collider của vũ khí khi kết thúc animation đánh
    }

    public void SwingUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0); // Đặt góc quay của animation khi đánh lên

        if (playerController.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true; // Lật animation nếu người chơi đang hướng về bên trái
        }
    }

    public void SwingDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0); // Đặt góc quay của animation khi đánh xuống

        if (playerController.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true; // Lật animation nếu người chơi đang hướng về bên trái
        }
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition; // Vị trí chuột
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position); // Điểm màn hình của người chơi

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; // Góc giữa vị trí chuột và người chơi

        if (mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle); // Hướng vũ khí khi người chơi hướng về bên trái
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0); // Hướng Collider của vũ khí khi người chơi hướng về bên trái
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle); // Hướng vũ khí khi người chơi hướng về bên phải
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0); // Hướng Collider của vũ khí khi người chơi hướng về bên phải
        }
    }
}
