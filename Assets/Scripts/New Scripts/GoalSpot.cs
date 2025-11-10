using UnityEngine;

public class GoalSpot : MonoBehaviour
{
    [HideInInspector] public Cell targetCell;

    void Start()
    {
        var gm = FindFirstObjectByType<GridManager>();
        if (gm == null) { Debug.LogError("No GridManager found."); return; }

        float best = float.MaxValue;
        Cell bestCell = null;

        //search for nearest cell
        for (int x = 0; x < gm.gridList.Count; x++)
        {
            var col = gm.gridList[x];
            for (int y = 0; y < col.Count; y++)
            {
                var cellGO = col[y];
                float d = Vector3.SqrMagnitude(cellGO.transform.position - transform.position);
                if (d < best)
                {
                    best = d;
                    bestCell = cellGO.GetComponent<Cell>();
                }
            }
        }
        targetCell = bestCell;

        if (targetCell != null)
        {
            var p = targetCell.transform.position;
            transform.position = new Vector3(p.x, transform.position.y, p.z);
        }
    }
}