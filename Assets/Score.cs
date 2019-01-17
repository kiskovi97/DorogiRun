using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{

    private Text scoreText;
    private float score;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
        score = 0;
        PlayerData.actualGameScore = (int)score;
    }

    void Update()
    {
        score += Time.deltaTime;
        PlayerData.actualGameScore = (int)score;
        scoreText.text = "" + (int)score;
    }
}
