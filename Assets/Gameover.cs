using UnityEngine;

public class Gameover : MonoBehaviour
{
    public delegate void ContinueGame();

    public event ContinueGame continueGame;

    private string playerTag = "Player";

    [SerializeField]
    private GameObject continueQuestion;
    [SerializeField]
    private SliderCounter sliderCounter;
    [SerializeField]
    private SceneLoader sceneLoader;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTag)
        {
            continueQuestion.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        continueQuestion.SetActive(false);
        continueGame();
    }

    public void GameOver()
    {
        Time.timeScale = 1;
        sceneLoader.GoToGameOverScene();
    }
}
