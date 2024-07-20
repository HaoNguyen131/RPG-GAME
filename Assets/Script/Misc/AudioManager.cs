using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; // AudioSource để phát nhạc nền

    public AudioClip background; // Biến để lưu trữ AudioClip của nhạc nền
    private void Start()
    {
        musicSource.clip = background; // Thiết lập AudioClip cho musicSource
        musicSource.Play(); // Phát nhạc nền
    }
}
