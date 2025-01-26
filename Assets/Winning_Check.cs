using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Winning_Check : MonoBehaviour
{
    [SerializeField] List<Checkpoint> All_Winning_Tile = new List<Checkpoint>();
    [SerializeField] string NextStageName;
    [SerializeField] AudioSource audioSource;



    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Finish()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the sound
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned!");
        }
    }


    private void Update()
    {
        if (isWininng())
        {
            Finish();
            StartCoroutine(GoNextStage());
        }
    }
    bool isWininng()
    {
        bool toReturn = true;
        foreach (Checkpoint i in All_Winning_Tile)
        {
            if (i.IsWin() == false)
            {
                toReturn =  false;
            }
        }

        return toReturn;
    }

    IEnumerator GoNextStage()
    {

        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(NextStageName);
    }
}
