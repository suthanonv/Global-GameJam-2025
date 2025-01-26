using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader _instance;

    public Animator _transition;
    public float _transitionTime = 1f;

    private int _currentSceneIndex;

    private void Awake()
    {
        if(_instance != null) Destroy(this.gameObject);
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
        if(_currentSceneIndex != SceneManager.GetActiveScene().buildIndex) //For Fixing Animation
        {
            Debug.Log("_currentSceneIndex is no longer equal to current sceneIndex, now updating.");
            //updates _currentSceneIndex, followed by initializing the update for a new scene
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _transition.SetTrigger("Last Scene Finished");
            _transition.SetTrigger("Scene Initiated");
        }
    } //Only For Animation

    public void LoadPreviousLevel()
    {
        PauseGame._instance.Unpause();
        StartCoroutine(LoadLevel(_currentSceneIndex - 1));
    }

    public void LoadNextLevel()
    {
        PauseGame._instance.Unpause();
        StartCoroutine(LoadLevel(_currentSceneIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuAndStage");
    }
}
