using System.Collections.Generic;
using UnityEngine;

public enum Box_Stage { Sleep, Wake, Sticky }

public class Player_stage : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite_render;
    [SerializeField] SoundSmack playsmacksound;

    [SerializeField] Box_Stage box_Stage;

    private void Start()
    {
        Stage = box_Stage;
    }
    public Box_Stage Stage
    {
        get { return box_Stage; }
        set
        {
            playsmacksound.PlaySound();
            box_Stage = value;
            
            // Replacing switch-case with if-else
            if (box_Stage == Box_Stage.Sleep)
            {
               
                this.GetComponent<Grid_Movement>().CurrentPlayerTile.CanMoveTo = true;
                this.GetComponent<Grid_Movement>().enabled = false;
            }
            else if (box_Stage == Box_Stage.Wake)
            {
                this.GetComponent<Grid_Movement>().CurrentPlayerTile.CanMoveTo = true;
                this.GetComponent<Grid_Movement>().enabled = true;

            }
            else if (box_Stage == Box_Stage.Sticky)
            {
                this.GetComponent<Grid_Movement>().CurrentPlayerTile.CanMoveTo = false;
                this.GetComponent<Grid_Movement>().enabled = false;
                
            }
           
                    
          
                sprite_render.sprite = Sprite_Libery.Instance.sprites[(int)box_Stage];
            
           
        }
    }
}
