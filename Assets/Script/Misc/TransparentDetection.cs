using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetection : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float transparencyAmount = 0.8f; // Độ mờ mong muốn (0 là hoàn toàn trong suốt, 1 là không mờ)
    [SerializeField] private float fadeTime = .4f; // Thời gian làm mờ hoặc làm trong suốt

    private SpriteRenderer spriteRenderer; // Reference đến SpriteRenderer của đối tượng này
    private Tilemap tilemap; // Reference đến Tilemap của đối tượng này

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Lấy SpriteRenderer của đối tượng này (nếu có)
        tilemap = GetComponent<Tilemap>(); // Lấy Tilemap của đối tượng này (nếu có)
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()) // Nếu đối tượng đi vào là PlayerController
        {
            if (spriteRenderer) // Nếu có SpriteRenderer
            {
                StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, transparencyAmount));
            }
            else if (tilemap) // Nếu có Tilemap
            {
                StartCoroutine(FadeRoutine(tilemap, fadeTime, tilemap.color.a, transparencyAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()) // Nếu đối tượng đi ra là PlayerController
        {
            if (spriteRenderer) // Nếu có SpriteRenderer
            {
                StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, 1f)); // Đổi về độ mờ mặc định (1 là không mờ)
            }
            else if (tilemap) // Nếu có Tilemap
            {
                StartCoroutine(FadeRoutine(tilemap, fadeTime, tilemap.color.a, 1f)); // Đổi về độ mờ mặc định (1 là không mờ)
            }
        }
    }

    private IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime, float startValue, float targetTransparency)
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapsedTime / fadeTime); // Lerp từ giá trị alpha hiện tại đến giá trị alpha mới
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha); // Cập nhật màu với alpha mới
            yield return null;
        }
    }

    private IEnumerator FadeRoutine(Tilemap tilemap, float fadeTime, float startValue, float targetTransparency)
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapsedTime / fadeTime); // Lerp từ giá trị alpha hiện tại đến giá trị alpha mới
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, newAlpha); // Cập nhật màu với alpha mới
            yield return null;
        }
    }
}
//StartCoroutine là một phương thức cho phép bạn bắt đầu thực thi một coroutine, một loại hàm đặc biệt trong C#
//được sử dụng để xử lý các tác vụ chạy song song mà không cần phải chờ đợi chúng hoàn thành như các hàm thông thường.