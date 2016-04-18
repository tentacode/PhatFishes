using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> victoryClips;
    public AudioClip introMusicClip;
    public AudioClip gameMusicClip;

    private AudioSource audioSource;

	void Awake()
	{
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
	}

    public void PlayIntroMusic()
    {
        audioSource.Stop();
        audioSource.clip = introMusicClip;
        audioSource.loop = true;

        if (PlayerPrefs.GetInt("DisableMusic", 0) == 0) {
            audioSource.Play();
        }
    }

    public void PlayGameMusic()
    {
        audioSource.Stop();
        audioSource.clip = gameMusicClip;
        audioSource.loop = true;

        if (PlayerPrefs.GetInt("DisableMusic", 0) == 0) {
            audioSource.Play();
        }
    }

    public void PlayVictory()
    {
        AudioClip victoryClip = victoryClips[Random.Range(0, victoryClips.Count)];
        audioSource.Stop();
        audioSource.clip = victoryClip;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void ToggleIntroMusic()
    {
        if (audioSource.isPlaying) {
            audioSource.Stop();
            PlayerPrefs.SetInt("DisableMusic", 1);
        } else {
            PlayerPrefs.SetInt("DisableMusic", 0);
            PlayIntroMusic();
        }
    }

    public void ToggleGameMusic()
    {
        if (audioSource.isPlaying) {
            audioSource.Stop();
            PlayerPrefs.SetInt("DisableMusic", 1);
        } else {
            PlayerPrefs.SetInt("DisableMusic", 0);
            PlayGameMusic();
        }
    }
}
