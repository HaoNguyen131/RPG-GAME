using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isRunning = true;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (isRunning)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetElapsedTime()
    {
        return Time.time - startTime;
    }
}
