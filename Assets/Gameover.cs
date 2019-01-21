using UnityEngine;

public class Gameover : MonoBehaviour
{
    public delegate void ContinueGame();

    public event ContinueGame continueGame;

    [SerializeField]
    private SceneLoader sceneLoader;

    public void Continue()
    {
        Time.timeScale = 1;
        continueGame();
    }

    public void GoToLobby()
    {
        Time.timeScale = 1;
        sceneLoader.GoToLobby();
    }
}
