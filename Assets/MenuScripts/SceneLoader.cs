using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{ 
    private string LobbyScene = "Lobby";
    private string GameScene = "Game";
    private string MainScene = "Main";
    private string StoreScene = "Store";

    private string chosed;

    public void GoToLobbyAndSetScale()
    {
        Time.timeScale = 1;
        chosed = LobbyScene;
        StartCoroutine(GoToSceneAsync());
    }

    public void GoToMain()
    {
        chosed = MainScene;
        StartCoroutine(GoToSceneAsync());
    }

    public void GoToGame()
    {
        chosed = GameScene;
        StartCoroutine(GoToSceneAsync());
    }

    public void GoToStore()
    {
        chosed = StoreScene;
        StartCoroutine(GoToSceneAsync());
    }      

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator GoToSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(chosed);
        while (!operation.isDone)
        {
            //float progress = Mathf.Clamp01(operation.progress / 0.9f); YAGNI :D
            yield return null;
        }
    }
}
