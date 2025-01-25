using UnityEngine;

public enum Win_Check_Behaviour { Need_Block, No_Block }
public class Checkpoint : MonoBehaviour
{
    [SerializeField] Win_Check_Behaviour Tile_Check_Behaviour;

    public bool IsWin()
    {
        if (Tile_Check_Behaviour == Win_Check_Behaviour.Need_Block)
        {

            return (this.GetComponent<Tile>().CharOnTile);
        }
        else
        {
            return (this.GetComponent<Tile>().CharOnTile == false);
        }

    }






}

