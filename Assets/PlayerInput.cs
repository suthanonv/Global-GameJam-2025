using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    public List<KeyTriggerEvent> keyTriggerEvents = new List<KeyTriggerEvent>();

    public Dictionary<KeyCode, bool> Can_Key = new Dictionary<KeyCode, bool>
    {
        { KeyCode.A, true },
        { KeyCode.D, true },
        { KeyCode.W, true },
        { KeyCode.S, true }
    };



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Ensure singleton pattern
        }
    }

    private void Update()
    {

    }

    public Vector2 Input_Direction()
    {


        Vector2 p_Input = Vector2.zero;
        CheckCanInput();

        if (Input.GetAxis("Horiztaonl") != 0 && Input.GetAxis("Vertical") != 0)
        {
            return p_Input;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            if (Can_Key[KeyCode.A])
            {

                p_Input.x = -1;
            }
            else
            {

                return Vector2.zero;
            }

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (Can_Key[KeyCode.D])
            {

                p_Input.x = 1;
            }
            else
            {

                return Vector2.zero;
            }

        }

        if (Input.GetAxis("Vertical") < 0)
        {
            if (Can_Key[KeyCode.S])
            {

                p_Input.y = -1;
            }
            else
            {

                return Vector2.zero;
            }
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            if (Can_Key[KeyCode.W])
            {

                p_Input.y = 1;
            }
            else
            {
                return Vector2.zero;
            }
        }



        return p_Input;
    }

    public void CheckCanInput()
    {
        if (keyTriggerEvents == null || keyTriggerEvents.Count == 0)
        {
            return; // Exit early if no events are registered
        }

        // Reset Can_Key based on initial values
        var defaultKeyStates = new Dictionary<KeyCode, bool>
        {
            { KeyCode.A, true },
            { KeyCode.D, true },
            { KeyCode.W, true },
            { KeyCode.S, true }
        };

        foreach (KeyTriggerEvent e in keyTriggerEvents)
        {
            if (e.OnWall)
            {
                defaultKeyStates[e.Key] = false;

            }
        }

        // Update Can_Key with the calculated states
        foreach (var pair in defaultKeyStates)
        {

            Can_Key[pair.Key] = pair.Value;
        }
    }
}
