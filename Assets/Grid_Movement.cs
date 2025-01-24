using System.Collections.Generic;
using UnityEngine;
public class Grid_Movement : MonoBehaviour
{
    [SerializeField] Tile CurrentPlayerTile;

    private void OnEnable()
    {
        if (Player_Moving_Calling.instance == null) return;

        Player_Moving_Calling.instance.MovementCalling.AddListener(Moving);
        Player_Moving_Calling.instance.AllPlayers.Add(this);
    }


    private void OnDisable()
    {
        Player_Moving_Calling.instance.MovementCalling.RemoveListener(Moving);

        Player_Moving_Calling.instance.AllPlayers.Remove(this);

    }


    public void Moving(KeyCode Moving_Key)
    {
        Debug.Log("Calling Move");

        Tile NewCurrent_Tile = new Tile();
        if (Moving_Key == KeyCode.W)
        {
            NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[CurrentPlayerTile.Tile_Index + new Vector2(0, 1)];

            this.transform.position = NewCurrent_Tile.transform.position;
        }

        if (Moving_Key == KeyCode.S)
        {
            NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[CurrentPlayerTile.Tile_Index + new Vector2(0, -1)];
            this.transform.position = NewCurrent_Tile.transform.position;
        }

        if (Moving_Key == KeyCode.A)
        {
            NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[CurrentPlayerTile.Tile_Index + new Vector2(-1, 0)];

            this.transform.position = NewCurrent_Tile.transform.position;

        }

        if (Moving_Key == KeyCode.D)
        {
            Debug.Log($"{CurrentPlayerTile.Tile_Index + new Vector2(1, 0)}");

            NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[CurrentPlayerTile.Tile_Index + new Vector2(1, 0)];

            this.transform.position = NewCurrent_Tile.transform.position;


        }

        CurrentPlayerTile = NewCurrent_Tile;


    }


    public Avalible_MovingDirection CanBemovedAround()
    {
        Vector2 TileIndex = CurrentPlayerTile.Tile_Index;

        Avalible_MovingDirection Valid_Move = new Avalible_MovingDirection();

        List<MoveDirection> MovingDirection = new List<MoveDirection>()
        {
           new MoveDirection( new Vector2(0, 1) ,KeyCode.W),
           new MoveDirection( new Vector2(1, 0), KeyCode.D),
           new MoveDirection(   new Vector2(0, -1), KeyCode.S),
            new MoveDirection(new Vector2(-1, 0), KeyCode.A)
        };


        foreach (var direction in MovingDirection)
        {
            Vector2 Move_Position = CurrentPlayerTile.Tile_Index + direction.Direction;

            if (Move_Position.x > Tile_Manager.instance.Tile_Max_Index.x && direction.Direction.x > 0)
            {
                Debug.Log($"Move position d {Move_Position} out of tile");
                Valid_Move.Can_Moving_Key[direction.Moving_Key] = false;
                continue;
            }
            else if (Move_Position.x < Tile_Manager.instance.Tile_Min_Index.x && direction.Direction.x < 0)
            {
                Debug.Log($"Move position a {Move_Position} out of tile");
                Valid_Move.Can_Moving_Key[direction.Moving_Key] = false;
                continue;
            }

            if (Move_Position.y > Tile_Manager.instance.Tile_Max_Index.y && direction.Direction.y > 0)
            {
                Debug.Log($"Move position w {Move_Position} out of tile");
                Valid_Move.Can_Moving_Key[direction.Moving_Key] = false;
                continue;
            }

            else if (Move_Position.y < Tile_Manager.instance.Tile_Min_Index.y && direction.Direction.y < 0)
            {
                Debug.Log($"Move position s {Move_Position} out of tile");
                Valid_Move.Can_Moving_Key[direction.Moving_Key] = false;
                continue;

            }

            if (Tile_Manager.instance.ALl_Tile[Move_Position].CanMoveTo == false)
            {
                Debug.Log($"Move position {Move_Position} tile stuck");

                Valid_Move.Can_Moving_Key[direction.Moving_Key] = false;
                continue;
            }
        }


        return Valid_Move;
    }
}


public class Avalible_MovingDirection
{
    public Dictionary<KeyCode, bool> Can_Moving_Key = new Dictionary<KeyCode, bool>() { { KeyCode.W, true }, { KeyCode.S, true }, { KeyCode.A, true }, { KeyCode.D, true } };
}

public class MoveDirection
{
    public Vector2 Direction;
    public KeyCode Moving_Key;

    public MoveDirection(Vector2 NewDirect, KeyCode MovingKey)
    {
        Direction = NewDirect;
        Moving_Key = MovingKey;
    }

}


