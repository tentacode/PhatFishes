using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameManager gameManager;

	void Start()
	{
        #if UNITY_EDITOR
        if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.WebGL) {
            TweakWebGL();
        }
        #else
        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            TweakWebGL();
        }
        #endif

        gameManager = GameObject.Find("Game").GetComponent<GameManager>();
        Resume();
	}

    void TweakWebGL()
    {
        GameObject.Find("QuitGameButton").SetActive(false);
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
        Time.timeScale = 1;
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
