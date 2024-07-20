using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private ParticleSystem ps; // Particle System của hiệu ứng hạt

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>(); // Lấy Component Particle System từ đối tượng này
    }

    private void Update()
    {
        if (ps && !ps.IsAlive()) // Nếu Particle System tồn tại và không còn hoạt động
        {
            DestroySelf(); // Hủy đối tượng này
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject); // Phương thức để hủy đối tượng chứa script này
    }
}
