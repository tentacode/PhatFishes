using UnityEngine;
﻿using UnityEngine.SceneManagement;
﻿using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;

    public InputField player1Name;
    public InputField player2Name;
    public InputField player3Name;
    public InputField player4Name;

    private bool isSetup = true;

    void Start()
    {
        if (PlayerPrefs.HasKey("Player1Name")) {
            player1Name.text = PlayerPrefs.GetString("Player1Name");
        }

        if (PlayerPrefs.HasKey("Player2Name")) {
            player2Name.text = PlayerPrefs.GetString("Player2Name");
        }

        if (PlayerPrefs.HasKey("Player3Name")) {
            player3Name.text = PlayerPrefs.GetString("Player3Name");
        }

        if (PlayerPrefs.HasKey("Player4Name")) {
            player4Name.text = PlayerPrefs.GetString("Player4Name");
        }

        isSetup = false;

        SwitchToMainMenu();
    }

    void Update()
    {
        if (mainMenu.activeSelf == false && Input.GetButtonDown("MenuCancel")){
            SwitchToMainMenu();
        }
    }

    public void SwitchToMainMenu()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SwitchToOptions()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void SwitchToGame()
    {
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
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
