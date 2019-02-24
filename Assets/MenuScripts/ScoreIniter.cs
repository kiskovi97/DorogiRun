using UnityEngine;
using UnityEngine.UI;

public class ScoreIniter : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField]
    private Text topScore;
    [SerializeField]
    private Text lastScore;
    [SerializeField]
    private Text allCoin;
    [SerializeField]
    private StoreRefresher storeRefresher;

    void Start()
    {
        FileManager.Save();
        Init();
        if (storeRefresher != null)
        {
            storeRefresher.refresh += Init;
        }
    }

    public void Init()
    {
        if (topScore != null)
        {
            topScore.text = "" + PlayerData.topScore;
        }
        if (lastScore != null)
        {
            lastScore.text = "" + PlayerData.actualGameScore;
        }
        if (allCoin != null)
        {
            allCoin.text = "" + PlayerData.allCoin;
        }
    }
}
