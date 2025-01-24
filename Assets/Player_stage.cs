using UnityEngine;

public enum Box_Stage { Sleep, Wake, Sticky }
public class Player_stage : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite_render;

    [SerializeField] Box_Stage box_Stage;
    public Box_Stage Stage
    {
        get { return box_Stage; }
        set
        {
            box_Stage = value;

            // Replacing switch-case with if-else
            if (box_Stage == Box_Stage.Sleep)
            {
                sprite_render.color = Color.gray;
                this.GetComponent<Grid_Movement>().CurrentPlayerTile.CanMoveTo = true;
            }
            else if (box_Stage == Box_Stage.Wake)
            {
                sprite_render.color = Color.red;
                this.GetComponent<Grid_Movement>().CurrentPlayerTile.CanMoveTo = true;
            }
            else if (box_Stage == Box_Stage.Sticky)
            {
                sprite_render.color = Color.yellow;
                this.GetComponent<Grid_Movement>().CurrentPlayerTile.CanMoveTo = false;

            }
        }
    }
}
