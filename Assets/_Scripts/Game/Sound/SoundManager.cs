using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> victoryClips;

    private AudioSource audioSource;

	void Awake()
	{
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
	}

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("DisableMusic", 0) == 0) {
            audioSource.Play();
        }
    }

    public void PlayGameMusic()
    {
        audioSource.Stop();
    }

    public void PlayVictory()
    {
        AudioClip victoryClip = victoryClips[Random.Range(0, victoryClips.Count)];
        audioSource.Stop();
        audioSource.PlayOneShot(victoryClip);
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
