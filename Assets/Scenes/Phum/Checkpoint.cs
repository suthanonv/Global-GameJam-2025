using UnityEngine;

public enum Win_Check_Behaviour { Need_Block, No_Block }
public class Checkpoint : MonoBehaviour
{
    [SerializeField] Win_Check_Behaviour Tile_Check_Behaviour;
    SpriteRenderer render;

    private void Start()
    {
        render = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    public bool IsWin()
    {
        if (Tile_Check_Behaviour == Win_Check_Behaviour.Need_Block)
        {
            if (this.GetComponent<Tile>().CharOnTile)
            {
                render.sprite = Sprite_Libery.Instance.Have_Block_in_Win_tile;
            }
            else
            {
                render.sprite = Sprite_Libery.Instance.No_Block_in_Win_tile;

            }

            return (this.GetComponent<Tile>().CharOnTile);
        }
        else
        {
            return (this.GetComponent<Tile>().CharOnTile == false);
        }

    }






}

