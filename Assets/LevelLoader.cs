using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader _instance;

    public Animator _transition;
    public float _transitionTime = 1f;

    private int _currentSceneIndex;
    private string tRGWT;

    private void Awake()
    {
        if (_instance != null) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        _instance = this;

        _transition.SetTrigger("New Scene Initiated");
    }
    private void Start()
    {
        Invoke("aaaa", 5f);

        Debug.Log("_currentSceneIndex has been set to current active scene.");
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (_currentSceneIndex != SceneManager.GetActiveScene().buildIndex) //For Activating Intro Animtion on new scene load
        {
            Debug.Log("_currentSceneIndex is no longer equal to current sceneIndex, now updating.");
            //updates _currentSceneIndex, followed by initializing the update for a new scene
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _transition.SetTrigger("New Scene Initiated");
        }
    } //Update Used Only For Animation

    public void LoadMainMenu()
    {
        PauseGame._instance.Unpause();
      //  StartCoroutine(StartTransition());
        SceneManager.LoadScene("MainMenuAndStage");
    }
    public void LoadNextLevel()
    {
        PauseGame._instance.Unpause();
      //  StartCoroutine(StartTransition());
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void LoadPreviousLevel()
    {
        PauseGame._instance.Unpause();
       // StartCoroutine(StartTransition());
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }
    public void RestartLevel()
    {
        PauseGame._instance.Unpause();
       // StartCoroutine(StartTransition());
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public string SceneName;
    public void LoadSpecificLevel(string LevelName)
    {
        SceneName =  LevelName;
        PauseGame._instance.Unpause();
        _transition.SetTrigger("Start");
        Invoke("LoadSceneByName", _transitionTime);
    }
    void LoadSceneByName()
    {
        SceneManager.LoadScene(SceneName);
    }

}
