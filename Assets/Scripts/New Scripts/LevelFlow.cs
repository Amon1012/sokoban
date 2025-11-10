using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFlow : MonoBehaviour
{
    public bool isLastLevel = false;
    LevelWinChecker win;
    LevelTimer timer;

    void Awake()
    {
        win = FindFirstObjectByType<LevelWinChecker>();
        timer = FindFirstObjectByType<LevelTimer>();

        if (win != null) win.OnWin = OnWin;
        if (timer != null) timer.OnTimeUp.AddListener(OnLose);
    }

    void OnWin()
    {
        timer?.StopTimer();
        if (isLastLevel) SceneManager.LoadScene("EndWin");
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnLose()
    {
        SceneManager.LoadScene("EndLose");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}