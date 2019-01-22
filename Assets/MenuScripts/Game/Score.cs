using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    private int secondMultiply = 3;

    public Text scoreText;
    public Text coinText;
    private float score;

    void Start()
    {
        scoreText.text = "0";
        coinText.text = "0";
        score = 0;
        PlayerData.actualGameScore = (int)score;
    }

    void Update()
    {
        score += Time.deltaTime*secondMultiply;
        PlayerData.actualGameScore = (int)score;
        scoreText.text = "" + (int)score;
        coinText.text = "" + PlayerData.actualCoin;
    }
}
