using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

	void Awake()
	{
	       DontDestroyOnLoad(gameObject);
	}

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("DisableMusic", 0) == 0) {
            audioSource.Play();
        }
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying) {
            audioSource.Stop();
            PlayerPrefs.SetInt("DisableMusic", 1);
        } else {
            audioSource.Play();
            PlayerPrefs.SetInt("DisableMusic", 0);
        }
    }
}
