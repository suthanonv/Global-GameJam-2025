using UnityEngine;

public class UnstickButton : MonoBehaviour
{
    Player_stage playerStage;
    Grid_Movement Grid_Movement;

    private void Start()
    {
        playerStage = GetComponent<Player_stage>();
        Grid_Movement = GetComponent<Grid_Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerStage.Stage == Box_Stage.Sticky)
            {
                playerStage.Stage = Box_Stage.Wake;
                Grid_Movement.enabled = true;
            }
        }
    }
}
