using UnityEngine;
using UnityEngine.Events;
using System;

public class LevelTimer : MonoBehaviour
{
    public float timeLimitSeconds = 90f;
    public UnityEvent<float> OnTimeChanged;
    public UnityEvent OnTimeUp;

    float t;
    bool running;

    void OnEnable()
    {
        t = timeLimitSeconds;
        running = true;
        OnTimeChanged?.Invoke(t);
    }

    void Update()
    {
        if (!running) return;
        t -= Time.deltaTime;
        if (t <= 0f)
        {
            t = 0f; running = false;
            OnTimeChanged?.Invoke(t);
            OnTimeUp?.Invoke();
        }
        else OnTimeChanged?.Invoke(t);
    }

    public void StopTimer() => running = false;
}