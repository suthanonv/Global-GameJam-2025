using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader2 : MonoBehaviour
{
    public static LevelLoader2 _instance;

    public Animator _transition;
    public float _transitionTime = 1f;

    private int _currentSceneIndex;

    private void Awake()
    {
        if (_instance != null) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        _instance = this;

        _transition.SetTrigger("Scene Initiated");
    }
    private void Start()
    {
        Debug.Log("_currentSceneIndex has been set to current active scene.");
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (_currentSceneIndex != SceneManager.GetActiveScene().buildIndex) //For Fixing Animation
        {
            Debug.Log("_currentSceneIndex is no longer equal to current sceneIndex, now updating.");
            //updates _currentSceneIndex, followed by initializing the update for a new scene
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _transition.SetTrigger("Last Scene Finished");
            _transition.SetTrigger("Scene Initiated");
        }
    } //Only For Animation
    public void LoadSpecificLevel(string levelName)
    {
        PauseGame._instance.Unpause();
        StartCoroutine(LoadLevel(levelName, 999));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel("Mono", 999));
    }

    public void LoadPreviousLevel()
    {
        PauseGame._instance.Unpause();
        StartCoroutine(LoadLevel("NULL", _currentSceneIndex - 1));
    }

    public void LoadNextLevel()
    {
        PauseGame._instance.Unpause();
        StartCoroutine(LoadLevel("NULL", _currentSceneIndex + 1));
    }

    public void RestartLevel()
    {
        PauseGame._instance.Unpause();
        StartCoroutine(LoadLevel("NULL", _currentSceneIndex));
    }

    IEnumerator LoadLevel(string levelName, int levelIndex)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        if (levelName != "NULL")
        {
            SceneManager.LoadScene(levelName);
        }
        else if (levelIndex != 999)
        {
            SceneManager.LoadScene(levelIndex);
        }

    }
}
