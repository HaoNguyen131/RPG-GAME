using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat; // Material để nhấp nháy màu trắng
    [SerializeField] private float resoureDefaultMatTime = .2f; // Thời gian mặc định của vật liệu trước khi phục hồi

    private Material defaultMat; // Vật liệu mặc định của đối tượng
    private SpriteRenderer spriteRenderer; // Component Renderer của Sprite

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Lấy component SpriteRenderer từ đối tượng này
        defaultMat = spriteRenderer.material; // Lưu trữ vật liệu mặc định ban đầu của SpriteRenderer
    }

    public float GetRestoreMatTime()
    {
        return resoureDefaultMatTime; // Phương thức trả về thời gian phục hồi vật liệu mặc định
    }

    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = whiteFlashMat; // Thiết lập vật liệu để nhấp nháy thành vật liệu màu trắng
        yield return new WaitForSeconds(resoureDefaultMatTime); // Chờ đợi trong một khoảng thời gian
        spriteRenderer.material = defaultMat; // Sau khi chờ đợi xong, phục hồi vật liệu mặc định của SpriteRenderer
    }
}
