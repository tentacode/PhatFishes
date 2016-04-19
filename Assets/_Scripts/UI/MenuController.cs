using UnityEngine;
﻿using UnityEngine.SceneManagement;
﻿using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject bubbleTitle;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject gameSetupMenu;
    public GameObject fullscreenButton;

    public InputField player1Name;
    public InputField player2Name;
    public InputField player3Name;
    public InputField player4Name;

    private bool isSetup = true;
    private SoundManager soundManager;

    void Start()
    {
        fullscreenButton.SetActive(false);

        #if UNITY_EDITOR
        if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.WebGL) {
            TweakWebGL();
        }
        #else
        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            TweakWebGL();
        }
        #endif

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayIntroMusic();

        InitPlayerNames();
        SwitchToMainMenu();
    }

    void TweakWebGL()
    {
        GameObject.Find("QuitButton").SetActive(false);
        fullscreenButton.SetActive(true);
    }

    void InitPlayerNames()
    {
        player1Name.text = PlayerPrefs.GetString("Player1Name", "Fish 1");
        player2Name.text = PlayerPrefs.GetString("Player2Name", "Fish 2");
        player3Name.text = PlayerPrefs.GetString("Player3Name", "Fish 3");
        player4Name.text = PlayerPrefs.GetString("Player4Name", "Fish 4");

        isSetup = false;
        SetPlayerNames();
    }

    void Update()
    {
        if (mainMenu.activeSelf == false && Input.GetButtonDown("MenuCancel")){
            SwitchToMainMenu();
        }
    }

    public void ToggleIntroMusic()
    {
        soundManager.ToggleIntroMusic();
    }

    public void SwitchToMainMenu()
    {
        bubbleTitle.SetActive(true);
        gameSetupMenu.SetActive(false);
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SwitchToOptions()
    {
        bubbleTitle.SetActive(false);
        mainMenu.SetActive(false);
        gameSetupMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void SwitchToGameSetup()
    {
        bubbleTitle.SetActive(false);
        mainMenu.SetActive(false);
        optionMenu.SetActive(false);
        gameSetupMenu.SetActive(true);
    }

    public void SwitchToGame2Players()
    {
        SwitchToGame(2);
    }

    public void SwitchToGame3Players()
    {
        SwitchToGame(3);
    }

    public void SwitchToGame4Players()
    {
        SwitchToGame(4);
    }

    void SwitchToGame(int playerCount)
    {
        PlayerPrefs.SetInt("playerCount", playerCount);
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetPlayerNames()
    {
        if (isSetup) {
            return;
        }

        PlayerPrefs.SetString("Player1Name", player1Name.text);
        PlayerPrefs.SetString("Player2Name", player2Name.text);
        PlayerPrefs.SetString("Player3Name", player3Name.text);
        PlayerPrefs.SetString("Player4Name", player4Name.text);
        PlayerPrefs.Save();
    }
}
