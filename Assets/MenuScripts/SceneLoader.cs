using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private string LobbyScene = "Lobby";
    private string GameScene = "Game";
    private string MainScene = "Main";
    private string StoreScene = "Store";

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToLobbyAndSetScale()
    {
        Time.timeScale = 1;
        GoToLobby();
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene(LobbyScene);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void GoToStore()
    {
        SceneManager.LoadScene(StoreScene);
    }      

    public void Quit()
    {
        Application.Quit();
    }
}
