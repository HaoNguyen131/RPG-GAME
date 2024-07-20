using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Đảm bảo sử dụng namespace này để có IEnumerator và WaitForSeconds

public class LoadingScene2 : MonoBehaviour
{
    IEnumerator Start()
    {
        // Thực hiện tải dữ liệu, xử lý dữ liệu, etc. ở đây

        // Chờ một vài giây (hoặc thực hiện các công việc tải dữ liệu)
        yield return new WaitForSeconds(2); // Ví dụ chờ 2 giây

        // Sau khi hoàn thành việc tải, chuyển sang Scene2
        SceneManager.LoadScene("Scene2");
    }
}
