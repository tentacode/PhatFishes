using UnityEngine;
﻿using UnityEngine.SceneManagement;
﻿using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas optionMenu;

    public InputField player1Name;
    public InputField player2Name;
    public InputField player3Name;
    public InputField player4Name;

    void Start()
    {
        player1Name.text = PlayerPrefs.GetString("Player1Name");
        player2Name.text = PlayerPrefs.GetString("Player2Name");
        player3Name.text = PlayerPrefs.GetString("Player3Name");
        player4Name.text = PlayerPrefs.GetString("Player4Name");

        SwitchToMainMenu();
    }

    public void SwitchToMainMenu()
    {
        optionMenu.enabled = false;
        mainMenu.enabled = true;
    }

    public void SwitchToOptions()
    {
        mainMenu.enabled = false;
        optionMenu.enabled = true;
    }

    public void SwitchToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetPlayerNames()
    {
        PlayerPrefs.SetString("Player1Name", player1Name.text);
        PlayerPrefs.SetString("Player2Name", player2Name.text);
        PlayerPrefs.SetString("Player3Name", player3Name.text);
        PlayerPrefs.SetString("Player4Name", player4Name.text);
    }
}
