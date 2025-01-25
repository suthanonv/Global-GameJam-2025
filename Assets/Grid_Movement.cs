using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Grid_Movement : MonoBehaviour
{
    [SerializeField] Tile _currentPlayerTile;
    Grid_Check Grid_Check;
    Sticky_line_Maker lineMaker;
    public Tile CurrentPlayerTile => _currentPlayerTile;

    private void Start()
    {
        Grid_Check = GetComponent<Grid_Check>();
        lineMaker = GetComponent<Sticky_line_Maker>();
    }

    private void OnEnable()
    {
        if (Player_Moving_Calling.instance == null) return;
        Player_Moving_Calling.instance.AllPlayers.Add(this);
    }


    public void Sticky(KeyCode Moving_Key)
    {
        Tile NewCurrent_Tile = null;

        try
        {
            Debug.Log("Calling Move");

            if (Moving_Key == KeyCode.W)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(0, 1)];

            }
            else if (Moving_Key == KeyCode.S)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(0, -1)];

            }
            else if (Moving_Key == KeyCode.A)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(-1, 0)];
            }
            else if (Moving_Key == KeyCode.D)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(1, 0)];
            }



            // Update the current player's tile information


            // Call the checking method
            Grid_Check.CheckingTile_AroundPlayer();

        }
        catch (KeyNotFoundException e)
        {
            CurrentPlayerTile.CanMoveTo = false;
            this.GetComponent<Player_stage>().Stage = Box_Stage.Sticky;
            this.enabled = false;

            Sticking_Line(Moving_Key);


            return;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"An error occurred during movement: {e.Message}");
        }



    }

    public void Sticking_Line(KeyCode InputKey)
    {
        KeyCode RevertKey = GettingRevertKey.RevertingKey[InputKey];

        List<Tile> Valid_Tile_Around_Player = Grid_Check.GetTileARoundPlayer();

        List<MoveDirection> MovingDirection = new List<MoveDirection>()
        {
           new MoveDirection( new Vector2(0, 1) ,KeyCode.W),
           new MoveDirection( new Vector2(1, 0), KeyCode.D),
           new MoveDirection(   new Vector2(0, -1), KeyCode.S),
            new MoveDirection(new Vector2(-1, 0), KeyCode.A)
        };


        foreach (MoveDirection direction in MovingDirection)
        {

            if (RevertKey == direction.Moving_Key)
            {
                Tile SerchingTIle = Valid_Tile_Around_Player.FirstOrDefault(i => i.Tile_Index == CurrentPlayerTile.Tile_Index + direction.Direction);

                if (SerchingTIle != null)
                {
                    if (SerchingTIle.CharOnTile != null)
                    {
                        SerchingTIle.CharOnTile.GetComponent<Sticky_line_Maker>().StartMakeLine(this.CurrentPlayerTile, SerchingTIle);
                    }
                }
                break;
            }
        }




    }


    public void Moving(KeyCode lasstedKey)
    {
        Tile NewCurrent_Tile = null;

        Avalible_MovingDirection direction = CanBemovedAround();


        if (direction.Can_Moving_Key[lasstedKey])
        {
            if (lasstedKey == KeyCode.W)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(0, 1)];
                this.transform.position = NewCurrent_Tile.transform.position;

            }
            else if (lasstedKey == KeyCode.S)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(0, -1)];

                this.transform.position = NewCurrent_Tile.transform.position;

            }
            else if (lasstedKey == KeyCode.A)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(-1, 0)];
                this.transform.position = NewCurrent_Tile.transform.position;

            }
            else if (lasstedKey == KeyCode.D)
            {
                NewCurrent_Tile = Tile_Manager.instance.ALl_Tile[_currentPlayerTile.Tile_Index + new Vector2(1, 0)];
                this.transform.position = NewCurrent_Tile.transform.position;
            }

            _currentPlayerTile.CharOnTile = null;
            _currentPlayerTile = null;
            NewCurrent_Tile.CharOnTile = this.gameObject;
            _currentPlayerTile = NewCurrent_Tile;

        }

        lineMaker.AddingLine(CurrentPlayerTile);
        Grid_Check.CheckingTile_AroundPlayer();

    }


    public List<KeyCode> Serching_Move_StickWall()
    {

        List<KeyCode> invalidKey = new List<KeyCode>();

        List<MoveDirection> MovingDirection = new List<MoveDirection>()
        {
           new MoveDirection( new Vector2(0, 1) ,KeyCode.W),
           new MoveDirection( new Vector2(1, 0), KeyCode.D),
           new MoveDirection(   new Vector2(0, -1), KeyCode.S),
            new MoveDirection(new Vector2(-1, 0), KeyCode.A)
        };


        foreach (var direction in MovingDirection)
        {
            Vector2 Move_Position = _currentPlayerTile.Tile_Index + direction.Direction;

            if (Move_Position.x > Tile_Manager.instance.Tile_Max_Index.x && direction.Direction.x > 0)
            {
                Debug.Log($"Move position d {Move_Position} out of tile");
                invalidKey.Add(direction.Moving_Key);

            }
            else if (Move_Position.x < Tile_Manager.instance.Tile_Min_Index.x && direction.Direction.x < 0)
            {
                Debug.Log($"Move position a {Move_Position} out of tile");
                invalidKey.Add(direction.Moving_Key);

                ;
            }

            if (Move_Position.y > Tile_Manager.instance.Tile_Max_Index.y && direction.Direction.y > 0)
            {
                Debug.Log($"Move position w {Move_Position} out of tile");
                invalidKey.Add(direction.Moving_Key);

            }

            else if (Move_Position.y < Tile_Manager.instance.Tile_Min_Index.y && direction.Direction.y < 0)
            {
                Debug.Log($"Move position s {Move_Position} out of tile");
                invalidKey.Add(direction.Moving_Key);


            }

            try
            {
               Tile ez =  Tile_Manager.instance.ALl_Tile[Move_Position];
            }
            catch
            {
                invalidKey.Add(direction.Moving_Key);
            }

        }

        return invalidKey;

    }


    public Avalible_MovingDirection CanBemovedAround()
    {

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
            Vector2 Move_Position = _currentPlayerTile.Tile_Index + direction.Direction;

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

            try
            {
                if (Tile_Manager.instance.ALl_Tile[Move_Position].CanMoveTo == false)
                {
                    Debug.Log($"Move position {Move_Position} tile stuck");

                    Valid_Move.Can_Moving_Key[direction.Moving_Key] = false;
                    continue;
                }
            }
            catch (KeyNotFoundException e)
            {
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


