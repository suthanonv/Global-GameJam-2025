using UnityEngine;
using UnityEngine.Events;

public class KeyTriggerEvent : MonoBehaviour
{

    [SerializeField] KeyCode Key;
    [SerializeField] UnityEvent KeyEvennt = new UnityEvent();
    GameObject Wall;
    bool OnWall;
    void OnTriggerStay2D(Collider2D collision)
    {
        Wall = collision.gameObject;
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
            transform.parent.gameObject.GetComponent<Sticky>().Wall = Wall;
            KeyEvennt.Invoke();
        }
    }
}
