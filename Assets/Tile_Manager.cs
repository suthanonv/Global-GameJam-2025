using System.Collections.Generic;
using UnityEngine;
public class Tile_Manager : MonoBehaviour
{


    public static Tile_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    public Dictionary<Vector2, Tile> ALl_Tile = new Dictionary<Vector2, Tile>();

    public Vector2 Tile_Max_Index = new Vector2();

    public Vector2 Tile_Min_Index = new Vector2();

    private void Start()
    {
        foreach (Transform i in this.transform)
        {
            ALl_Tile.Add(i.gameObject.GetComponent<Tile>().Tile_Index, i.gameObject.GetComponent<Tile>());

            Debug.Log($"{i.gameObject.GetComponent<Tile>().Tile_Index} , {i.gameObject.GetComponent<Tile>()}");
        }


    }



}

