using UnityEngine;
using UnityEngine.UI;

public class ScoreIniter : MonoBehaviour
{
    [SerializeField]
    private Text topScore;
    [SerializeField]
    private Text lastScore;

    void Start()
    {
        if(PlayerData.actualGameScore > PlayerData.topScore)
        {
            FileManager.Save();
        }
        topScore.text = "" + PlayerData.topScore;
        lastScore.text = "" + PlayerData.actualGameScore;
    }
}
