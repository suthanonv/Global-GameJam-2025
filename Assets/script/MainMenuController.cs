using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            LoadStageSelection();
        }
    }

    void LoadStageSelection()
    {
        SceneManager.LoadScene("StageSelectionScene");
    }
}




