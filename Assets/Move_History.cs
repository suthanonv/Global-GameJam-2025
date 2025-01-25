using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move_History : MonoBehaviour
{
    public static Move_History Instance;

    private void Awake()
    {
        Instance = this;
    }

    List<History> Action_History = new List<History>();

    [SerializeField] List<Grid_Movement> AllPlayer = new List<Grid_Movement>();

    private void Start()
    {
        Save();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            LoadHistory();
        }
    }

    public void LoadHistory()
    {
        if(Action_History.Count > 1)
        {
            History currentHistory = Action_History[Action_History.Count -2];
           foreach(var i in currentHistory.Tile_History)
            {
                Tile_Manager.instance.ALl_Tile[i.Key].CharOnTile = i.Value.Player;
            }


            foreach (Grid_Movement player in AllPlayer)
            {
                Player_stage p_Stage = player.GetComponent<Player_stage>();

                p_Stage.Stage = currentHistory.Player_Stage_history[player].Stage;
                player.CurrentPlayerTile = currentHistory.Player_Stage_history[player].P_Tile;

                player.TeleportTile();


            }

            Action_History.Remove(Action_History[Action_History.Count - 1]);
        }


    }

    public void Save()
    {
        Action_History.Add(Saving_Action());
    }
    History Saving_Action()
    {
        History history = new History();
       
        foreach(var tile in Tile_Manager.instance.ALl_Tile)
        {
            history.Tile_History[tile.Key] = new Tile_Component(tile.Value.CharOnTile);
        }

        foreach(Grid_Movement Player in AllPlayer)
        {
            history.Player_Stage_history[Player] = new PlayerState_Property(Player.gameObject.GetComponent<Player_stage>().Stage , Player.CurrentPlayerTile);
        }


        return history;
    }

}

[System.Serializable] 
public class History
{
    public Dictionary<Grid_Movement, PlayerState_Property> Player_Stage_history  = new Dictionary<Grid_Movement, PlayerState_Property>();
    public Dictionary<Vector2 , Tile_Component> Tile_History = new Dictionary<Vector2, Tile_Component>();
}

[System.Serializable]
public struct PlayerState_Property
{
    public Box_Stage Stage;
    public Tile P_Tile;

    public PlayerState_Property(Box_Stage SavingStage , Tile CurrentTile)
    {
        P_Tile = CurrentTile;   
        Stage = SavingStage;
    }

}

public struct Tile_Component
{
    public GameObject Player;

    public Tile_Component(GameObject newP)
    {
        Player = newP;
        }
}


