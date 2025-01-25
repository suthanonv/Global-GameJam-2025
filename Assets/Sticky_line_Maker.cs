using System.Collections.Generic;
using UnityEngine;
public class Sticky_line_Maker : MonoBehaviour
{


    LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    List<Tile> AddingTileList = new List<Tile>();

    public void StartMakeLine(Tile StartTile, Tile PlayerTile)
    {
        line.positionCount = 2;

        line.SetPosition(0, StartTile.transform.position);
        line.SetPosition(1, PlayerTile.transform.position);

        AddingTileList.Add(StartTile);
        AddingTileList.Add(PlayerTile);

        StartTile.CanMoveTo = false;
        PlayerTile.CanMoveTo = false;

    }



    public void AddingLine(Tile NewLine)
    {
        if (line.positionCount == 0) return;

        line.positionCount++;

        line.SetPosition(line.positionCount - 1, NewLine.transform.position);

        AddingTileList.Add(NewLine);
        NewLine.CanMoveTo = false;
    }

    public void ClearLine()
    {
        line.positionCount = 0;

        foreach (Tile Tile in AddingTileList)
        {

            Tile.CanMoveTo = true;

        }
    }
}
