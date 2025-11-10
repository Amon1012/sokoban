using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class HUDController : MonoBehaviour
{
    public TMP_Text timerText;
    public Button restartBtn;

    LevelTimer timer;
    LevelFlow flow;

    void Awake()
    {
        timer = FindFirstObjectByType<LevelTimer>();
        flow = FindFirstObjectByType<LevelFlow>();

        if (timer) timer.OnTimeChanged.AddListener(UpdateTime);
        if (restartBtn && flow) restartBtn.onClick.AddListener(flow.RestartLevel);
    }

    void UpdateTime(float sec)
    {
        var ts = TimeSpan.FromSeconds(Mathf.Ceil(sec));
        timerText.text = $"{ts.Minutes:00}:{ts.Seconds:00}";
    }
}