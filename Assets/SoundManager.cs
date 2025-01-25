using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //public static SoundManager _instance; private void Awake() { if (_instance != null) Destroy(this.gameObject); DontDestroyOnLoad(this.gameObject); _instance = this; }

    [SerializeField] private AudioSource _soundFxSource;

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in GO
        AudioSource _audioSource = Instantiate(_soundFxSource, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        _audioSource.clip = audioClip;
        
        //play sound
        _audioSource.Play();

        //get length of sound fx clip
        float clipLength = _audioSource.clip.length;

        //destroy the clip after it is done playing
        Destroy(_audioSource.gameObject, clipLength);
    }

    public void PlaySoundFXClipWithPitchChange(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in GO
        AudioSource _audioSource = Instantiate(_soundFxSource, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        _audioSource.clip = audioClip;

        //randomize pitch within a range
        _audioSource.pitch = Random.Range(1f, 1.5f);

        //play sound
        _audioSource.Play();

        //get length of sound fx clip
        float clipLength = _audioSource.clip.length;

        //destroy the clip after it is done playing
        Destroy(_audioSource.gameObject, clipLength);
    }
}
