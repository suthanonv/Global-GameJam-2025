using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Control : MonoBehaviour
{

    bool IsWall;

    List<KeyCode> requiredKeyCode = new List<KeyCode>();

    [SerializeField] UnityEvent PlayerTouchingEvent = new UnityEvent();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.enabled != false)
        {
            this.transform.parent = collision.transform;
            this.enabled = false;
            PlayerTouchingEvent.Invoke();
        }
    }



}
