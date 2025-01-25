using UnityEngine;

public class PauseGame : MonoBehaviour
{
    //DontDestroyOnLoad
    private static PauseGame _instance; private void Awake() { if (_instance != null) Destroy(this.gameObject); DontDestroyOnLoad(this.gameObject); _instance = this; }

    //the actual pause menu code
    [SerializeField] private GameObject TheActualMenuBeingToggled;

    public void Pause()
    {
        Debug.Log("Pause() has been called.");
        TheActualMenuBeingToggled.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game has been paused.");
    }

    public void Unpause()
    {
        Debug.Log("Unpause() has been called.");
        TheActualMenuBeingToggled.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Game has been unpaused.");
    }

    private bool IsPaused = false;
    private void Update() //I know this is terrible but we don't have a "PlayerControls" script anywhere
    {
        if(Input.GetKeyDown(KeyCode.Escape) && IsPaused == false)
        {
            Pause();
            IsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused)
        {
            Unpause();
            IsPaused = false;
        }
    }
}
