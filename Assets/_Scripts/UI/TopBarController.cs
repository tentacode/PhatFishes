using UnityEngine;
﻿using UnityEngine.UI;
using System.Collections.Generic;


public class TopBarController : MonoBehaviour
{
    public GameManager gameManager;
    public List<Sprite> healthSprites;

	void Start()
	{
        HidePlayerUIs();
        InitNames();
        UpdatePlayerHealths();
	}

    void HidePlayerUIs()
    {
        GameObject.Find("Player1UI").SetActive(true);
        GameObject.Find("Player2UI").SetActive(true);

        switch (gameManager.GetPlayerCount()) {
            case 2:
                GameObject.Find("Player3UI").SetActive(false);
                GameObject.Find("Player4UI").SetActive(false);
                break;
            case 3:
                GameObject.Find("Player3UI").SetActive(true);
                GameObject.Find("Player4UI").SetActive(false);
                break;
            case 4:
                GameObject.Find("Player3UI").SetActive(true);
                GameObject.Find("Player4UI").SetActive(true);
                break;
        };

    }

    void InitNames()
    {
        GameObject.Find("Player1Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player1Name");
        GameObject.Find("Player2Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player2Name");

        switch (gameManager.GetPlayerCount()) {
            case 3:
                GameObject.Find("Player3Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player3Name");
                break;
            case 4:
                GameObject.Find("Player3Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player3Name");
                GameObject.Find("Player4Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player4Name");
                break;
        };
    }

	void Update()
	{
        UpdatePlayerHealths();
	}

    void UpdatePlayerHealths()
    {
        UpdatePlayerHealth(1);
        UpdatePlayerHealth(2);

        switch (gameManager.GetPlayerCount()) {
            case 2:
                break;
            case 3:
                UpdatePlayerHealth(3);
                break;
            case 4:
                UpdatePlayerHealth(3);
                UpdatePlayerHealth(4);
                break;

        };
    }

    void UpdatePlayerHealth(int playerIndex)
    {
        GameObject player = GameObject.Find(string.Format("Player{0}", playerIndex));
        if (!player) {
            return;
        }

        FishHealth fishHealth = player.GetComponent<FishHealth>();
        int health = fishHealth.GetHealth();

        Image healthImage = GameObject.Find("Player" + playerIndex + "Health").GetComponent<Image>();

        healthImage.sprite = healthSprites[health];
    }
}
