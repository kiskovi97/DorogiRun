﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string LobbyScene = "Lobby";
    [SerializeField]
    private string GameScene = "Game";
    [SerializeField]
    private string Main = "Main";

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene(LobbyScene);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(Main);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
