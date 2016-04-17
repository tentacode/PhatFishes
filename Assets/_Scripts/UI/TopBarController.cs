using UnityEngine;
﻿using UnityEngine.UI;
using System.Collections.Generic;


public class TopBarController : MonoBehaviour
{
    public List<Sprite> healthSprites;

	void Start()
	{
        InitNames();
        UpdatePlayerHealths();
	}

    void InitNames()
    {
        GameObject.Find("Player1Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player1Name");
        GameObject.Find("Player2Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player2Name");
        GameObject.Find("Player3Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player3Name");
        GameObject.Find("Player4Name").GetComponent<Text>().text = PlayerPrefs.GetString("Player4Name");
    }

	void Update()
	{
        UpdatePlayerHealths();
	}

    void UpdatePlayerHealths()
    {
        UpdatePlayerHealth(1);
        UpdatePlayerHealth(2);
        UpdatePlayerHealth(3);
        UpdatePlayerHealth(4);
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
