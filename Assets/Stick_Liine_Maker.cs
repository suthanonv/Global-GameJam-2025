using System.Collections.Generic;
using UnityEngine;
public class Stick_Liine_Maker : MonoBehaviour
{
    LineRenderer lineRenderer;

    List<Tile> StickyTIle = new List<Tile>();
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void LinkingLine(Tile StartTile, Tile EndTile)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, StartTile.transform.position);
        lineRenderer.SetPosition(1, EndTile.transform.position);
        StickyTIle.Add(StartTile);
        StickyTIle.Add(EndTile);

        foreach (Tile Tile in StickyTIle)
        {
            Tile.CanMoveTo = false;

            if (Tile.TryGetComponent<Check_Mark>(out Check_Mark condition_tile))
            {
                condition_tile.IsObjectOnTile = true;
            }
        }
    }


    public void AddingTile(Tile NewTile)
    {
        StickyTIle.Add(NewTile);

        lineRenderer.positionCount += 1;

        lineRenderer.SetPosition(lineRenderer.positionCount, NewTile.transform.position);

        if (NewTile.TryGetComponent<Check_Mark>(out Check_Mark condition_tile))
        {
            condition_tile.IsObjectOnTile = true;
        }
    }

    public void ClearingBubble()
    {
        lineRenderer.positionCount = 0;
        foreach
            (Tile Tile in StickyTIle)
        {
            Tile.CanMoveTo = true;

            if (Tile.TryGetComponent<Check_Mark>(out Check_Mark condition_tile))
            {
                condition_tile.IsObjectOnTile = false;
            }
        }
        StickyTIle.Clear();
    }
}
