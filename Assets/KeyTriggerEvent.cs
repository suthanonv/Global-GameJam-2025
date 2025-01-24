using UnityEngine;
using UnityEngine.Events;

public class KeyTriggerEvent : MonoBehaviour
{

    [SerializeField] KeyCode Key;
    [SerializeField] UnityEvent KeyEvennt = new UnityEvent();
    bool OnWall;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            OnWall = false;
        }


    }


    private void Update()
    {
        if (Input.GetKeyDown(Key) && OnWall)
        {
            KeyEvennt.Invoke();
        }
    }
}
