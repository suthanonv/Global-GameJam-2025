using UnityEngine;

public class Sticky : MonoBehaviour
{

    public void Stcky()
    {
        this.transform.parent = null;
    }

    public void Set_Stick()
    {
        this.GetComponent<Gird_Movement>().enabled = false;

    }

}
