using UnityEngine;

public class Gird_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float smoothingSpeed;
    [SerializeField] float Delay = 0.1f;
    float CurrentDealy;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        OffDelay();

        Vector3 targetPosition = new Vector3();


        Vector2 Direct = new Vector2();
        if (Direct.y != 0 || Direct.x != 0)
        {

            targetPosition = this.transform.position + new Vector3(Direct.x * TileSize._tileSize.x, Direct.y * TileSize._tileSize.y, 0);

        }

        if (targetPosition != Vector3.zero && CurrentDealy <= 0)
        {


            rb.MovePosition(targetPosition);
            CurrentDealy = Delay;
        }



    }

    public void OffDelay()
    {
        CurrentDealy -= Time.deltaTime;
    }





}
