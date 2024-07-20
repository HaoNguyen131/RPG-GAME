using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxOffset = -0.15f;   // Độ lệch parallax, quyết định tốc độ di chuyển parallax

    private Camera cam;                                      // Tham chiếu đến Camera chính trong Scene
    private Vector2 startPos;                                // Vị trí ban đầu của đối tượng Parallax
    private Vector2 travel => (Vector2)cam.transform.position - startPos;  // Khoảng cách di chuyển của Camera so với vị trí ban đầu của Parallax

    private void Awake()
    {
        cam = Camera.main;                                  // Lấy tham chiếu của Camera chính trong Scene
    }

    private void Start()
    {
        startPos = transform.position;                      // Lưu vị trí ban đầu của đối tượng Parallax
    }

    private void FixedUpdate()
    {
        // Cập nhật vị trí của đối tượng Parallax theo hiệu ứng parallax
        transform.position = startPos + travel * parallaxOffset;
    }
}
//parallax là một kỹ thuật thiết kế môi trường trong game giúp tăng tính tương tác và '
//hấp dẫn của trò chơi bằng cách làm phong phú hóa không gian và sự chuyển động của các đối tượng nền.