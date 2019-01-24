using UnityEngine;

public class Gameover : MonoBehaviour
{
    public delegate void ContinueGame();

    public event ContinueGame continueGame;

    [SerializeField]
    private Fader fader;

    public void Continue()
    {
        continueGame();
    }
}
