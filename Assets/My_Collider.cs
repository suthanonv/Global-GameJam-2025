using UnityEngine;
using UnityEngine.Rendering;

public class My_Collider : MonoBehaviour
{

 
    void Update()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(this.transform.position,this.transform.localScale , 0 , Vector2.zero);

        foreach(RaycastHit2D i in  hit )
        {
            Debug.Log(i.collider.gameObject.name);
            if(i.collider.gameObject.CompareTag("Player") && i.collider.gameObject != this.gameObject)
            {
                i.collider.gameObject.GetComponent<Gird_Movement>().enabled = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(this.transform.position , this.transform.localScale );
    }
}
