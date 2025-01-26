using System.Collections.Generic;
using UnityEngine;

public class Sprite_Libery : MonoBehaviour
{
    public static Sprite_Libery Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Sprite> sprites = new List<Sprite>();


 

    public Sprite Have_Block_in_Win_tile, No_Block_in_Win_tile;

}
