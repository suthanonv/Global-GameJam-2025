using UnityEngine;

public class Animation_playing : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void Start()
    {
        Playing_Open();
    }

    public void Playing_CLose()
    {
        anim.Play("Close");


    }

    public void Playing_Open()
    {
        anim.Play("Open");
    }

}
