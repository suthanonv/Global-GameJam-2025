using UnityEngine;

public class SoundSmack : MonoBehaviour
{
    public AudioSource audioSource; // Assign your AudioSource in the Inspector
    public float minPitch = 0.8f;   // Minimum pitch value
    public float maxPitch = 1.2f;   // Maximum pitch value

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch); // Set a random pitch
            audioSource.Play(); // Play the sound
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned!");
        }
    }
}
