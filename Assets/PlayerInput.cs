using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    int inputX;
    int inputY;
    List<GameObject> Player = new List<GameObject>() { };
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            inputX = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            inputX = 1;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            inputY = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            inputY = 1;
        }
    }
}
