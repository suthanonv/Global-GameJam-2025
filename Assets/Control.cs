using UnityEngine;


public class Control : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.transform.parent = collision.transform;
        }
    }
}
