using UnityEngine.UI;
using UnityEngine;

public class StoreItemIniter : MonoBehaviour
{
    private enum StoreItemType
    {
        shield, airplane
    }

    [SerializeField]
    private StoreItemType storeItemType;

    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Text priceText;

    [SerializeField]
    private Button priceButton;

    [SerializeField]
    private Image buttonImage;

    [SerializeField]
    private Color haveEnoughMoneyColor;

    [SerializeField]
    private Color cantAffordItColor;

    [SerializeField]
    private ScoreIniter scoreIniter;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        switch (storeItemType)
        {
            case StoreItemType.shield:
                ShieldInit();
                break;
            default:
                break;

        }
    }

    private void ShieldInit()
    {
        nameText.text = shieldName;
        int maxLevel = shieldData.Length;
        if (maxLevel > PlayerData.shieldLevel)
        {
            int price = GetShieldDataPrice(PlayerData.shieldLevel);
            priceText.text = "" + price;

            if (price <= PlayerData.allCoin)
            {
                buttonImage.color = haveEnoughMoneyColor;
            }
            else
            {
                buttonImage.color = cantAffordItColor;
                priceButton.interactable = false;
            }
        }
        else
        {
            priceText.text = "Max";
            priceButton.interactable = false;
        }
        slider.value = (float)PlayerData.shieldLevel / (float)maxLevel;
    }

    public void BuyOne()
    {
        switch (storeItemType)
        {
            case StoreItemType.shield:
                PlayerData.allCoin -= GetShieldDataPrice(PlayerData.shieldLevel);
                PlayerData.shieldLevel++;
                break;
            default:
                break;
        }

        scoreIniter.Init();
        Init();
        FileManager.Save();
    }

    private class StoreItemData
    {
        public int price;
        public int effectTime;

        public StoreItemData(int price, int effectTime)
        {
            this.price = price;
            this.effectTime = effectTime;
        }
    }

    #region Shield
    static private string shieldName = "Shield";
    static private StoreItemData[] shieldData = new StoreItemData[] { new StoreItemData(50, 5),
                                                              new StoreItemData(100, 6),
                                                              new StoreItemData(500, 7),
                                                              new StoreItemData(1000, 8),
                                                              new StoreItemData(10000, 10)};

    static public int GetShieldDataPrice(int level)
    {
        if (level > shieldData.Length)
        {
            return shieldData[shieldData.Length - 1].price;
        }
        return shieldData[level].price;
    }

    #endregion
}
