using System.Collections.Generic;
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



        SecondMove(Key, AllPlayersCopy);
    }

    public void SecondMove(KeyCode Key, List<Grid_Movement> AllPlayersCopy)
    {
        Avalible_MovingDirection valid_Move = AvalibMovingDirection();

        bool canW = valid_Move.Can_Moving_Key[KeyCode.W];
        bool CanS = valid_Move.Can_Moving_Key[KeyCode.S];
        bool CanA = valid_Move.Can_Moving_Key[KeyCode.A];
        bool CanD = valid_Move.Can_Moving_Key[KeyCode.D];




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

        // Iterate over all players to determine valid movement directions
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

        return valid_Direction_Of_All_Player;
    }
}


public static class GettingRevertKey
{
    public static Dictionary<KeyCode, KeyCode> RevertingKey = new Dictionary<KeyCode, KeyCode>() { { KeyCode.W, KeyCode.S }, { KeyCode.S, KeyCode.W }, { KeyCode.A, KeyCode.D }, { KeyCode.D, KeyCode.A } };
}
