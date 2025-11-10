using UnityEngine;

public class LevelWinChecker : MonoBehaviour
{
    public System.Action OnWin;
    GoalSpot[] goals;

    void Start()
    {
        goals = FindObjectsByType<GoalSpot>(FindObjectsSortMode.None);
        TryCheckWin();
    }

    void GridChanged() => TryCheckWin();

    void TryCheckWin()
    {
        if (goals == null || goals.Length == 0) return;

        foreach (var g in goals)
        {
            if (g == null || g.targetCell == null) return;

            var obj = g.targetCell.ContainObj;
            if (obj == null) return;

            var block = obj.GetComponent<Block>();
            if (block == null) return;

            if (block is Player) return;

        }

        OnWin?.Invoke();
    }
}