using UnityEngine;
﻿using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public CameraController cameraController;
    public GameObject jellyFish;

    public GameObject endGameUI;
    public Text endGameText;
    public List<string> randomWinTexts;

    private int playerCount;

    private SoundManager soundManager;

    private bool gameEnding = false;
    private bool gameEnded = false;

	void Awake()
	{
        endGameUI.SetActive(false);
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);

        playerCount = PlayerPrefs.GetInt("playerCount", 4);

        InitPlayers();
	}

    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayGameMusic();
    }

    void InitPlayers()
    {
        player1.SetActive(true);
        player2.SetActive(true);

        switch (playerCount)
        {
            case 2:
                player3.SetActive(false);
                player4.SetActive(false);
                break;
            case 3:
                player3.SetActive(true);
                player4.SetActive(false);
                break;
            case 4:
                player3.SetActive(true);
                player4.SetActive(true);
                break;
        }
    }

    void Update()
    {
        CheckEndGame();
    }

    void CheckEndGame()
    {
        if (gameEnding) {
            return;
        }

        if (CountAlivePlayers() <= 1) {
            gameEnding = true;
            Invoke("EndGame", 1);
        }
    }

    void EndGame()
    {
        gameEnded = true;

        if (CountAlivePlayers() == 0) {
            Draw();
        } else {
            Win(GetWinner());
        }

    }

    void Draw()
    {
        cameraController.Focus(jellyFish);
        endGameText.text = "DRAW!";
        endGameUI.SetActive(true);
        soundManager.PlayVictory();
    }

    void Win(GameObject winner)
    {
        cameraController.Focus(winner);
        endGameText.text = randomWinTexts[Random.Range(0, randomWinTexts.Count)];
        endGameUI.SetActive(true);
        soundManager.PlayVictory();
    }

    int CountAlivePlayers()
    {
        int alivePlayers = 0;

        if (player1.GetComponent<FishHealth>().GetHealth() > 0) {
            alivePlayers++;
        }

        if (player2.GetComponent<FishHealth>().GetHealth() > 0) {
            alivePlayers++;
        }

        if (playerCount > 2 && player3.GetComponent<FishHealth>().GetHealth() > 0) {
            alivePlayers++;
        }

        if (playerCount > 3 && player4.GetComponent<FishHealth>().GetHealth() > 0) {
            alivePlayers++;
        }

        return alivePlayers;
    }

    GameObject GetWinner()
    {
        if (player1.GetComponent<FishHealth>().GetHealth() > 0) {
            return player1;
        }

        if (player2.GetComponent<FishHealth>().GetHealth() > 0) {
            return player2;
        }

        if (playerCount > 2 && player3.GetComponent<FishHealth>().GetHealth() > 0) {
            return player3;
        }

        return player4;
    }

    public void Rematch()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public int GetPlayerCount()
    {
        return playerCount;
    }

    public bool IsGameEnded()
    {
        return gameEnded;
    }
}
