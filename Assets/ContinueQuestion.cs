using UnityEngine;
using UnityEngine.UI;

public class ContinueQuestion : MonoBehaviour
{

    private static float scale = 1;
    private int neededAmount;

    [SerializeField]
    private int baseRevivePrice = 1;
    [SerializeField]
    private int multiplyValue = 2;
    [SerializeField]
    private int maxReviveCount = 100;
    [SerializeField]
    private Text amountText;
    [SerializeField]
    private Button continueButton;

    private void Init()
    {
        if(neededAmount == 0)
        {
            neededAmount = baseRevivePrice;
        }
        scale = Time.timeScale;
        Time.timeScale = 0;
        amountText.text = "" + neededAmount;
        if(neededAmount > PlayerData.reviveItemCount)
        {
            continueButton.interactable = false;
            //TODO: color change or something, ty Gergo :(
        }
    }

    private void OnEnable()
    {
        Init();
    }

    private void OnDisable()
    {
        Time.timeScale = scale;
        PlayerData.reviveItemCount -= neededAmount;
        neededAmount *= multiplyValue;
        if(neededAmount > maxReviveCount)
        {
            neededAmount = maxReviveCount;
        }
    }
}
