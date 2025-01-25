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


        if (Input.GetKeyDown(KeyCode.W))
        {
            Moving(KeyCode.W);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Moving(KeyCode.A);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Moving(KeyCode.S);

        }

        if (Input.GetKeyDown(KeyCode.D))
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



        SecondMove(Key, AllPlayersCopy);
    }

    public void SecondMove(KeyCode Key, List<Grid_Movement> AllPlayersCopy)
    {
        Avalible_MovingDirection valid_Move = AvalibMovingDirection();

        bool canW = valid_Move.Can_Moving_Key[KeyCode.W];
        bool CanS = valid_Move.Can_Moving_Key[KeyCode.S];
        bool CanA = valid_Move.Can_Moving_Key[KeyCode.A];
        bool CanD = valid_Move.Can_Moving_Key[KeyCode.D];


        if (Key == KeyCode.W)
        {
            AllPlayersCopy.OrderByDescending(i => i.CurrentPlayerTile.Tile_Index.y);
        }

        if (Key == KeyCode.S)
        {
            AllPlayersCopy.OrderBy(i => i.CurrentPlayerTile.Tile_Index.y);
        }

        if (Key == KeyCode.A)
        {
            AllPlayersCopy.OrderBy(i => i.CurrentPlayerTile.Tile_Index.x);
        }

        if (Key == KeyCode.D)
        {
            AllPlayersCopy.OrderByDescending(i => i.CurrentPlayerTile.Tile_Index.x);
        }

        if (canW && Key == KeyCode.W && CurrentCD <= 0)
        {
            CurrentCD = CD;
            foreach (Grid_Movement move in AllPlayersCopy)
            {
                move.Moving(Key);
            }
            return;
        }

        if (Key == (KeyCode.S) && CanS && CurrentCD <= 0)
        {
            CurrentCD = CD;
            foreach (Grid_Movement move in AllPlayersCopy)
            {
                move.Moving(Key);
            }
            return;

        }
        if (Key == (KeyCode.A) && CanA && CurrentCD <= 0)
        {
            CurrentCD = CD;
            foreach (Grid_Movement move in AllPlayersCopy)
            {
                move.Moving(Key);
            }
            return;
        }

        if (Key == (KeyCode.D) && CanD && CurrentCD <= 0)
        {
            CurrentCD = CD;
            foreach (Grid_Movement move in AllPlayersCopy)
            {
                move.Moving(Key);
            }
            return;
        }

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
