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
                //if (LevelLoader._instance != null)
                //{
                //    LevelLoader._instance.RestartLevel();
                //}
                //else
                //{
                //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //}
            }

        }
    }
}
