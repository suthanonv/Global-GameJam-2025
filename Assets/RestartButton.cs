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
                Skiping.Instance.Loading(SceneManager.GetActiveScene().name);
            }

        }
    }
}
