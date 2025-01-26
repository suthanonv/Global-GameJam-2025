using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    [SerializeField] string Level;

    bool oneTime = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (oneTime == false)
            {
                if (LevelLoader._instance != null)
                {
                    StartCoroutine(LevelLoader._instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

        }
    }
}
