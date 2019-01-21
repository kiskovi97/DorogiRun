using UnityEngine;
using UnityEngine.UI;

public class ScoreIniter : MonoBehaviour
{
    [SerializeField]
    private Text topScore;
    [SerializeField]
    private Text lastScore;
    [SerializeField]
    private Text allCoin;

    void Start()
    {
        FileManager.Save();
        topScore.text = "" + PlayerData.topScore;
        lastScore.text = "" + PlayerData.actualGameScore;
        allCoin.text = "" + PlayerData.allCoin;
    }
}
