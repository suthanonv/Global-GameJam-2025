using UnityEngine;

public class Gird_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInput input;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Moveing()
    {
        Vector3 targetPosition = new Vector3();


        Vector2 Direct = PlayerInput.instance.Input_Direction();
        if (Direct.y != 0 || Direct.x != 0)
        {

            targetPosition = this.transform.position + new Vector3(Direct.x * TileSize._tileSize.x, Direct.y * TileSize._tileSize.y, 0);

        }


        this.transform.position = targetPosition;

    }


    private void OnEnable()
    {
        Move_DelayCheck.instance.MovingCall.AddListener(Moveing);

        foreach (Transform i in this.transform)
        {
            PlayerInput.instance.keyTriggerEvents.Add(i.gameObject.GetComponent<KeyTriggerEvent>());
        }
    }

    private void OnDisable()
    {
        Move_DelayCheck.instance.MovingCall.RemoveListener(Moveing);


        foreach (Transform i in this.transform)
        {
            PlayerInput.instance.keyTriggerEvents.Remove(i.gameObject.GetComponent<KeyTriggerEvent>());
        }
    }






}
