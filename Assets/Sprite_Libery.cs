using System.Collections.Generic;
using UnityEngine;

public class Sprite_Libery : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites = new List<Sprite>();

    public static Dictionary<Box_Stage, Sprite> Sprite_Stage = new Dictionary<Box_Stage, Sprite>();

    private void Start()
    {
        for(int i = 0; i < sprites.Count; i++)
        {
            Sprite_Stage[(Box_Stage)i] = sprites[i];
        }
    }

}
