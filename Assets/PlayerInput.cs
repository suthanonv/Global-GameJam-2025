using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    public static PlayerInput instance;


    public List<KeyTriggerEvent> keyTriggerEvents = new List<KeyTriggerEvent>();
    public Dictionary<KeyCode , bool> Can_Key =  new Dictionary<KeyCode, bool>
{
    { KeyCode.A, true },
    { KeyCode.D, true },
    { KeyCode.W, true },
    { KeyCode.S, true }
};


    private void Awake()
    {
        instance = this;
    }

    int inputX;
    int inputY;
    List<GameObject> Player = new List<GameObject>() { };

    void CheckCanInput()
    {
        Dictionary<KeyCode, bool> keyValuePairs = new Dictionary<KeyCode, bool>
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
                keyValuePairs[e.Key] = false;
            }
        }
        foreach(KeyValuePair<KeyCode , bool> pair in keyValuePairs)
        {
            Can_Key[pair.Key] = pair.Value;
        }

    }
    [SerializeField] float Delay;
    float CurrentDelay;

    private void Update()
    {
        CurrentDelay -= Time.deltaTime;
    }
    public Vector2 Input_Direction()
    {

        Vector2 p_Input = new Vector2();


        if (Input.GetAxis("Horizontal") < 0 && Can_Key[KeyCode.A])
        {
            p_Input.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0 && Can_Key[KeyCode.D])
        {
            p_Input.x = 1;
        }
        if (Input.GetAxis("Vertical") < 0 && Can_Key[KeyCode.S])
        {
            p_Input.y = -1;
        }
        if (Input.GetAxis("Vertical") > 0 && Can_Key[KeyCode.W])
        {
            p_Input.y = 1;
        }
        if(CurrentDelay > 0)
        {
            return Vector2.zero;
        }
        
        if (p_Input != Vector2.zero)
        {
            CurrentDelay = Delay;
        }

       

        return p_Input;
    }
}
