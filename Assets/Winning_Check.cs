using System.Collections.Generic;
using UnityEngine;
public class Winning_Check : MonoBehaviour
{
    [SerializeField] List<Checkpoint> All_Winning_Tile = new List<Checkpoint>();



    private void Update()
    {
        if (isWininng())
        {
            Debug.Log("You Win!");
        }
    }
    bool isWininng()
    {
        foreach (Checkpoint i in All_Winning_Tile)
        {
            if (i.IsWin() == false)
            {
                return false;
            }
        }

        return true;
    }
}
