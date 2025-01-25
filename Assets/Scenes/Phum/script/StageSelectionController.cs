using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectionController : MonoBehaviour
{
    public void LoadStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }
}

