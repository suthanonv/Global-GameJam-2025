using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader _instance;

    private AnimatorController _transition;
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
        _transition = GetComponent<AnimatorController>();
        _transition.SetTrigger("New Scene Initiated");
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

    public int _sceneIndex;

    public void LoadNextScene()
    {
        _sceneIndex = _currentSceneIndex + 1;
        PauseGame._instance.Unpause();
        _transition.SetBool("tfTrigger", true);
        Invoke("LoadSceneByIndex", _transitionTime);
    }
    
    public void LoadPreviousLevel()
    {
        _sceneIndex = _currentSceneIndex - 1;
        PauseGame._instance.Unpause();
        _transition.SetBool("tfTrigger", true);
        Invoke("LoadSceneByIndex", _transitionTime);
    }
    public void RestartLevel()
    {
        _sceneIndex = _currentSceneIndex;
        PauseGame._instance.Unpause();
        _transition.SetBool("tfTrigger", true);
        Invoke("LoadSceneByIndex", _transitionTime);
    }

    void LoadSceneByIndex()
    {
        SceneManager.LoadScene(_sceneIndex);
        _transition.SetBool("tfTrigger", false);
    }

    public string SceneName;
    public void LoadSpecificLevel(string LevelName)
    {
        _transition.SetBool("tfTrigger", true);
        SceneName =  LevelName;
        PauseGame._instance.Unpause();
        Invoke("LoadSceneByName", _transitionTime);
    }
    void LoadSceneByName()
    {
        SceneManager.LoadScene(SceneName);
        if (_transition.GetBool("tfTrigger"))
        {
            _transition.SetBool("tfTrigger", false);
        }
        else
        {
            _transition.SetBool("tfTrigger", true);
        }
        
    }

}
