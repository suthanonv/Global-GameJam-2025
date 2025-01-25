using System.Collections.Generic;
using UnityEngine;

public class Grid_Check : MonoBehaviour
{
    Grid_Movement moving;

    private void Start()
    {
        moving = GetComponent<Grid_Movement>();
    }

    public List<Tile> GetTileARoundPlayer()
    {
        List<Tile> AvalibleTile = new List<Tile>();

        List<MoveDirection> MovingDirection = new List<MoveDirection>()
        {
            new MoveDirection(new Vector2(0, 1), KeyCode.W),
            new MoveDirection(new Vector2(1, 0), KeyCode.D),
            new MoveDirection(new Vector2(0, -1), KeyCode.S),
            new MoveDirection(new Vector2(-1, 0), KeyCode.A)
        };

        foreach (var direction in MovingDirection)
        {
            // Calculate the target position
            Vector2 Move_Position = moving.CurrentPlayerTile.Tile_Index + direction.Direction;

            // Check if the position is within bounds
            if (Move_Position.x >= Tile_Manager.instance.Tile_Min_Index.x &&
                Move_Position.x <= Tile_Manager.instance.Tile_Max_Index.x &&
                Move_Position.y >= Tile_Manager.instance.Tile_Min_Index.y &&
                Move_Position.y <= Tile_Manager.instance.Tile_Max_Index.y)
            {
                // Add the valid tile to the list
                if (Tile_Manager.instance.ALl_Tile.TryGetValue(Move_Position, out Tile tile))
                {
                    AvalibleTile.Add(tile);
                }
            }
        }

        return AvalibleTile;
    }
    public void CheckingTile_AroundPlayer()
    {
        // Define movement directions and associated keys
        List<MoveDirection> MovingDirection = new List<MoveDirection>()
        {
            new MoveDirection(new Vector2(0, 1), KeyCode.W),
            new MoveDirection(new Vector2(1, 0), KeyCode.D),
            new MoveDirection(new Vector2(0, -1), KeyCode.S),
            new MoveDirection(new Vector2(-1, 0), KeyCode.A)
        };

        List<Tile> CheckingTile = new List<Tile>();

        foreach (var direction in MovingDirection)
        {
            // Calculate the target position
            Vector2 Move_Position = moving.CurrentPlayerTile.Tile_Index + direction.Direction;

            // Check if the position is within bounds
            if (Move_Position.x >= Tile_Manager.instance.Tile_Min_Index.x &&
                Move_Position.x <= Tile_Manager.instance.Tile_Max_Index.x &&
                Move_Position.y >= Tile_Manager.instance.Tile_Min_Index.y &&
                Move_Position.y <= Tile_Manager.instance.Tile_Max_Index.y)
            {
                // Add the valid tile to the list
                if (Tile_Manager.instance.ALl_Tile.TryGetValue(Move_Position, out Tile tile))
                {
                    CheckingTile.Add(tile);
                }
            }
        }

        foreach (Tile i in CheckingTile)
        {
            if (i.CharOnTile != null)
            {
                Grid_Movement characterMovement = i.CharOnTile.GetComponent<Grid_Movement>();
                if (characterMovement != null)
                {
                    if (characterMovement.TryGetComponent<Player_stage>(out Player_stage Stage))
                    {
                        if (Stage.Stage == Box_Stage.Sleep)
                        {
                            Stage.Stage = Box_Stage.Wake;
                            characterMovement.enabled = true;
                        }
                    }
                }
            }
        }


    }
}
