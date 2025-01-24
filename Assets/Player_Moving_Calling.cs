using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Moving_Calling : MonoBehaviour
{

    public static Player_Moving_Calling instance;

    public UnityEvent<KeyCode> MovementCalling = new UnityEvent<KeyCode>();

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




        if (Key == KeyCode.W && CurrentCD <= 0)
        {
            CurrentCD = CD;
            MovementCalling.Invoke(KeyCode.W);
            return;
        }

        if (Key == (KeyCode.S) && CurrentCD <= 0)
        {
            CurrentCD = CD;
            MovementCalling.Invoke(KeyCode.S);
            return;

        }
        if (Key == (KeyCode.A) && CurrentCD <= 0)
        {
            CurrentCD = CD;
            MovementCalling.Invoke(KeyCode.A);
            return;
        }

        if (Key == (KeyCode.D) && CurrentCD <= 0)
        {
            CurrentCD = CD;
            MovementCalling.Invoke(KeyCode.D);
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

