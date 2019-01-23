using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private SceneLoader sceneLoader;

    private float prevTime = 1f;

    public void PauseGame()
    {
        prevTime = Time.timeScale;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = prevTime;
        pauseMenu.SetActive(false);
    }

    public void GoToLobby()
    {
        Time.timeScale = 1;
        sceneLoader.GoToLobby();
    }
}
