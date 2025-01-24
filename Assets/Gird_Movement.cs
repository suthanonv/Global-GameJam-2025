using UnityEngine;

public class Gird_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float Delay = 0.1f;
    float CurrentDealy;
    PlayerInput input;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        OffDelay();

        Vector3 targetPosition = new Vector3();


        Vector2 Direct = PlayerInput.instance.Input_Direction();
        if (Direct.y != 0 || Direct.x != 0)
        {

            targetPosition = this.transform.position + new Vector3(Direct.x * TileSize._tileSize.x, Direct.y * TileSize._tileSize.y, 0);

        }

        if (targetPosition != Vector3.zero && CurrentDealy <= 0)
        {


            this.transform.position = targetPosition;
            CurrentDealy = Delay;
        }



    }


    private void OnEnable()
    {
        foreach(Transform i in this.transform)
        {
            PlayerInput.instance.keyTriggerEvents.Add(i.gameObject.GetComponent<KeyTriggerEvent>());    
        }
    }

    private void OnDisable()
    {
        foreach (Transform i in this.transform)
        {
            PlayerInput.instance.keyTriggerEvents.Remove(i.gameObject.GetComponent<KeyTriggerEvent>());
        }
    }
    public void OffDelay()
    {
        CurrentDealy -= Time.deltaTime;
    }





}
