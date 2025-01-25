using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectionController : MonoBehaviour
{
    public string[] stageNames;
    private int currentStageIndex = 0;

    public void LoadStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }

    public void LoadNextStage()
    {
        if (currentStageIndex < stageNames.Length - 1)
        {
            currentStageIndex++;
            SceneManager.LoadScene(stageNames[currentStageIndex]);
        }
        else
        {
            Debug.Log("No more stages. Returning to menu.");
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuAndStage");
    }

    public void CompleteStage()
    {
        Debug.Log($"Stage {currentStageIndex + 1} completed!");
    }
}
