using UnityEngine.UI;
using UnityEngine;

public class StoreReviveItem : MonoBehaviour
{

    [SerializeField]
    private int price = 500;

    [SerializeField]
    private Text countText;
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private Image buttonImage;
    [SerializeField]
    private Color haveEnoughMoneyColor;
    [SerializeField]
    private Color cantAffordItColor;

    [SerializeField]
    private StoreRefresher storeRefresher;

    void Start()
    {
        Init();
        storeRefresher.refresh += Init;
    }

    public void BuyOne()
    {
        PlayerData.allCoin -= price;
        PlayerData.reviveItemCount++;

        FileManager.Save();

        storeRefresher.RefreshStore();
    }

    private void Init()
    {
        countText.text = "" + PlayerData.reviveItemCount;
        priceText.text = "" + price;
        if (PlayerData.allCoin < price)
        {
            buttonImage.color = cantAffordItColor;
            buyButton.interactable = false;
        }
        else
        {
            buttonImage.color = haveEnoughMoneyColor;
        }
    }
}
