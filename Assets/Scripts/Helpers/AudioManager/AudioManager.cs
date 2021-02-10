using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audioSource;
    private AudioClip _audioClip;

    private void Awake()
    {
        MakeInstance();
        _audioSource = GetComponent<AudioSource>();
    }

    private void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySound(string audio)
    {
        _audioClip = Resources.Load(audio) as AudioClip;
        _audioSource.PlayOneShot(_audioClip);
    }
}
