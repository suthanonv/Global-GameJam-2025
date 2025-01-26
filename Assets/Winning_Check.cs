using System.Collections.Generic;
using UnityEngine;

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
        Player_Moving_Calling.instance.enabled = false;

        if (audioSource != null)
        {
            audioSource.Play(); // Play the sound

        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned!");
        }

        Skiping.Instance.Loading(NextStageName, false);

    }


    bool one = false;

    private void Update()
    {
        if (isWininng())
        {
            if (one) return;
            one = true;
            Finish();
        }



    }
    bool isWininng()
    {
        bool toReturn = true;
        foreach (Checkpoint i in All_Winning_Tile)
        {
            if (i.IsWin() == false)
            {
                toReturn = false;
            }
        }

        return toReturn;
    }


}
