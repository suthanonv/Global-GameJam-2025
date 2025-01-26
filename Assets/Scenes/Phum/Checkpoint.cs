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
            if (this.GetComponent<Tile>().CharOnTile != null)
            {
                if (Sprite_Libery.Instance != null)
                {
                    Sprite sprite = Sprite_Libery.Instance.Have_Block_in_Win_tile;
                    if (sprite != null)
                    {


                        render.sprite = sprite;
                    }
                }
            }
            else
            {
                Sprite sprite = Sprite_Libery.Instance.No_Block_in_Win_tile;
                if (sprite != null)
                    render.sprite = sprite;
                

            }

            return (this.GetComponent<Tile>().CharOnTile != null);
        }
        else
        {
            return (this.GetComponent<Tile>().CharOnTile == false);
        }

    }






}

