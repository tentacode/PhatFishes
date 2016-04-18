using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameManager gameManager;

	void Start()
	{
        gameManager = GameObject.Find("Game").GetComponent<GameManager>();
        Resume();
	}

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleMusic()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        if (soundManager != null) {
            soundManager.GetComponent<SoundManager>().ToggleGameMusic();
        }
    }

	void Update()
	{
        if (gameManager.IsGameEnded()) {
            if (pauseMenu.activeSelf) {
                Resume();
            }

            return;
        }

        if (Input.GetButtonDown("MenuCancel") || Input.GetKeyDown("tab")) {
            if (pauseMenu.activeSelf) {
                Resume();
            } else {
                Pause();
            }
        }
	}
}
