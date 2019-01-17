using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string LobbyScene = "Lobby";
    [SerializeField]
    private string GameOverScene = "GameOver";
    [SerializeField]
    private string GameScene = "Game";

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene(LobbyScene);
    }

    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(GameOverScene);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(GameScene);
    }
}
