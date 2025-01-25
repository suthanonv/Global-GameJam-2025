using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Player_Moving_Calling : MonoBehaviour
{

    public static Player_Moving_Calling instance;


    public List<Grid_Movement> AllPlayers = new List<Grid_Movement>();

    bool canW;
    bool CanS;
    bool CanA;
    bool CanD;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        OffCD();


        if (Input.GetKey(KeyCode.W))
        {
            Moving(KeyCode.W);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Moving(KeyCode.A);

        }

        if (Input.GetKey(KeyCode.S))
        {
            Moving(KeyCode.S);

        }

        if (Input.GetKey(KeyCode.D))
        {
            Moving(KeyCode.D);

        }
    }



    void OffCD()
    {
        if (CurrentCD > 0)
            CurrentCD -= Time.deltaTime;
    }

    [SerializeField] float CD;
    float CurrentCD;


    public void Moving(KeyCode Key)
    {
        if (CurrentCD > 0) return;


        List<Grid_Movement> AllPlayersCopy = new List<Grid_Movement>();
        List<Grid_Movement> itemsToRemove = new List<Grid_Movement>();

        foreach (Grid_Movement p in AllPlayers)
        {
            AllPlayersCopy.Add(p);
        }


        List<Grid_Movement> StickWallMove = new List<Grid_Movement>();

        foreach (Grid_Movement move in AllPlayersCopy)
        {
            foreach (KeyCode i in move.Serching_Move_StickWall())
            {
                if (i == Key)
                {
                    move.Sticky(Key);
                    itemsToRemove.Add(move);
                }
            }
        }

        foreach (Grid_Movement move in itemsToRemove)
        {
            AllPlayersCopy.Remove(move);
        }



        SecondMove(Key);
    }

    public void SecondMove(KeyCode Key )
    {
        List<Grid_Movement> AllPlayersCopy = new List<Grid_Movement>();

        List<Grid_Movement> UnMoveable_tile = new List<Grid_Movement>();

        foreach (Grid_Movement move in AllPlayers)
        {
            if (move.gameObject.GetComponent<Player_stage>().Stage == Box_Stage.Sticky)
            {
                UnMoveable_tile.Add(move);  
            }
            else if(move.gameObject.GetComponent<Player_stage>().Stage == Box_Stage.Wake)
            {
                AllPlayersCopy.Add(move);
            }
        }

        CurrentCD = CD;
        Avalible_MovingDirection valid_Move = AvalibMovingDirection();

        // Dictionary for move directions
        Dictionary<KeyCode, MoveDirection> movingDirectionDict = new Dictionary<KeyCode, MoveDirection>()
    {
        { KeyCode.W, new MoveDirection(new Vector2(0, 1), KeyCode.W) },
        { KeyCode.D, new MoveDirection(new Vector2(1, 0), KeyCode.D) },
        { KeyCode.S, new MoveDirection(new Vector2(0, -1), KeyCode.S) },
        { KeyCode.A, new MoveDirection(new Vector2(-1, 0), KeyCode.A) }
    };

        // Sorting players based on key input (if necessary)
        switch (Key)
        {
            case KeyCode.A:
                AllPlayersCopy = AllPlayersCopy.OrderBy(i => i.CurrentPlayerTile.Tile_Index.x).ToList();
                break;
            case KeyCode.D:
                AllPlayersCopy = AllPlayersCopy.OrderByDescending(i => i.CurrentPlayerTile.Tile_Index.x).ToList();
                break;
            case KeyCode.W:
                AllPlayersCopy = AllPlayersCopy.OrderByDescending(i => i.CurrentPlayerTile.Tile_Index.y).ToList();
                break;
            case KeyCode.S:
                AllPlayersCopy = AllPlayersCopy.OrderBy(i => i.CurrentPlayerTile.Tile_Index.y).ToList();
                break;
        }

        Dictionary<Vector2, Grid_Movement> Future_Move = new Dictionary<Vector2, Grid_Movement>();

        foreach (Grid_Movement player in AllPlayersCopy)
        {
            MoveDirection moveDirection = movingDirectionDict[Key];
            Vector2 futurePosition = player.CurrentPlayerTile.Tile_Index + moveDirection.Direction;

            Future_Move[futurePosition] = player;

        }

        List<Grid_Movement> Valid_Move = new List<Grid_Movement>();

        foreach (var future_move in Future_Move)
        {
            Grid_Movement newThing = null;
            foreach(var Obstacle in UnMoveable_tile)
            {
                if(future_move.Key == Obstacle.CurrentPlayerTile.Tile_Index)
                {
                    newThing = future_move.Value;
                    break;
                }
            }

            if (newThing != null)
            {
                UnMoveable_tile.Add(newThing);
            }
            else
            {
                Valid_Move.Add(future_move.Value);
            }
        }

        foreach(Grid_Movement Finaly_ican_sleep  in Valid_Move)
        {
            Finaly_ican_sleep.Moving(Key);
        }


        Move_History.Instance.Save();
        // You can now use the Future_Move dictionary for further processing
    }

    public Avalible_MovingDirection AvalibMovingDirection()
    {
        // Initialize a new instance of Avalible_MovingDirection
        Avalible_MovingDirection valid_Direction_Of_All_Player = new Avalible_MovingDirection();

        List<KeyCode> Keys = new List<KeyCode>() { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

        try
        {
            foreach (KeyCode Result in Keys)
            {
                foreach (var Player in AllPlayers)
                {
                    bool isDone = false;


                    if (Player.CanBemovedAround().Can_Moving_Key[Result] == false)
                    {
                        isDone = true;
                        valid_Direction_Of_All_Player.Can_Moving_Key[Result] = false;
                    }

                    if (isDone)
                    {
                        break;
                    }
                }
            }
        }
        catch (KeyNotFoundException e)
        {

        }

        return valid_Direction_Of_All_Player;
    }
}


public static class GettingRevertKey
{
    public static Dictionary<KeyCode, KeyCode> RevertingKey = new Dictionary<KeyCode, KeyCode>() { { KeyCode.W, KeyCode.S }, { KeyCode.S, KeyCode.W }, { KeyCode.A, KeyCode.D }, { KeyCode.D, KeyCode.A } };
}
