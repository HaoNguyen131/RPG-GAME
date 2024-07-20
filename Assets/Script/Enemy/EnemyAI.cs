using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f; // Thời gian giữa các lần thay đổi hướng di chuyển

    private enum State
    {
        Roaming // Trạng thái: đang lang thang
    }
    private State state; // Trạng thái hiện tại của AI
    private EnemyPathfinding enemyPathfinding; // Đối tượng xử lý di chuyển của đối tượng địch

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>(); // Lấy component EnemyPathfinding từ đối tượng này
        state = State.Roaming; // Ban đầu đặt trạng thái là Roaming (lang thang)
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine()); // Bắt đầu Coroutine để thực hiện hành vi lang thang
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming) // Vòng lặp trong khi đối tượng đang trong trạng thái Roaming
        {
            Vector2 roamPosition = GetRoamingPosition(); // Lấy vị trí mới để lang thang
            enemyPathfinding.MoveTo(roamPosition); // Gọi phương thức MoveTo của EnemyPathfinding để di chuyển đến vị trí đó
            yield return new WaitForSeconds(roamChangeDirFloat); // Chờ đợi để thay đổi hướng di chuyển
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; // Trả về một hướng ngẫu nhiên được chuẩn hóa
    }
}
