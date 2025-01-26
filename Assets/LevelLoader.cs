using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader _instance;

    public Animator _transition;
    public float _transitionTime = 1.5f;

    private int _currentSceneIndex;
    private string tRGWT;

    private void Awake()
    {
        if (_instance != null) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }
    private void Start()
    {
        _transition = GetComponent<Animator>();
        _transition.SetTrigger("FUCK");
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
            _transition.SetTrigger("FUCK");
        }
    } //Update Used Only For Animation

    public int _sceneIndex;

    public void LoadNextScene()
    {
        _sceneIndex = _currentSceneIndex + 1;
        PauseGame._instance.Unpause();
        _transition.SetTrigger("FUCK");
        Invoke("LoadSceneByIndex", _transitionTime);
    }
    
    public void LoadPreviousLevel()
    {
        _sceneIndex = _currentSceneIndex - 1;
        PauseGame._instance.Unpause();
        _transition.SetTrigger("FUCK");
        Invoke("LoadSceneByIndex", _transitionTime);
    }
    public void RestartLevel()
    {
        _sceneIndex = _currentSceneIndex;
        PauseGame._instance.Unpause();
        _transition.SetTrigger("FUCK");
        Invoke("LoadSceneByIndex", _transitionTime);
    }

    void LoadSceneByIndex()
    {
        SceneManager.LoadScene(_sceneIndex);
        _transition.SetTrigger("FUCK");
    }

    public string SceneName;
    public void LoadSpecificLevel(string LevelName)
    {
        _transition.SetTrigger("FUCK");
        SceneName =  LevelName;
        PauseGame._instance.Unpause();
        Invoke("LoadSceneByName", _transitionTime);
    }
    void LoadSceneByName()
    {
        SceneManager.LoadScene(SceneName);
        _transition.SetTrigger("FUCK");

    }

}
