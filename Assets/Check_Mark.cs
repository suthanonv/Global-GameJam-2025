using UnityEngine;

public enum Block_Behaviour { NeedBlocck, NoBLock }

public class Check_Mark : MonoBehaviour
{
    public bool IsObjectOnTile = false;
    [SerializeField] Block_Behaviour PassIng_Behaviour;


    public bool IsPass()
    {
        if (PassIng_Behaviour == Block_Behaviour.NeedBlocck)
        {
            return IsObjectOnTile == true;
        }
        else
        {
            return IsObjectOnTile == false;
        }
    }

}
