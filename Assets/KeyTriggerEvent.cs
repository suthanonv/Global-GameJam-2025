using UnityEngine;
using UnityEngine.Events;

public class KeyTriggerEvent : MonoBehaviour
{

    [SerializeField] KeyCode _key;

    public KeyCode Key => _key;
    [SerializeField] UnityEvent KeyEvennt = new UnityEvent();
    GameObject Wall;
    public bool OnWall;
    void OnTriggerStay2D(Collider2D collision)
    {
        Wall = collision.gameObject;
        if(collision.gameObject.CompareTag("Player"))
        {
            Targe = collision.gameObject.GetComponent<Gird_Movement>();

            Invoke("Deley", 0.005f);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
        }
    }

    Gird_Movement Targe;
    void Deley()
    {
        Targe.enabled = true;
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
