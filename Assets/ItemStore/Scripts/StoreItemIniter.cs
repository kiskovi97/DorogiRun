using UnityEngine.UI;
using UnityEngine;

public class StoreItemIniter : MonoBehaviour
{

    private readonly string maxLevelText = "Max level";
    private readonly string notMaxLevelText = "Level ";
    private readonly string maxButtonText = "Max";

    private enum StoreItemType
    {
        shield, airplane, magnet
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
    private Text levelText;

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

    private void Init()
    {
        switch (storeItemType)
        {
            case StoreItemType.shield:
                ShieldInit();
                break;
            case StoreItemType.magnet:
                MagnetInit();
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
            levelText.text = notMaxLevelText + (PlayerData.shieldLevel + 1);

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
            priceText.text = maxButtonText;
            priceButton.interactable = false;

            levelText.text = maxLevelText;
        }

        slider.value = (float)PlayerData.shieldLevel / (float)maxLevel;
    }

    private void MagnetInit()
    {
        nameText.text = magnetdName;
        int maxLevel = magnetData.Length;
        if (maxLevel > PlayerData.magnetLevel)
        {
            levelText.text = notMaxLevelText + (PlayerData.magnetLevel + 1);

            int price = GetMagnetDataPrice(PlayerData.magnetLevel);
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
            priceText.text = maxButtonText;
            priceButton.interactable = false;
            levelText.text = maxLevelText;
        }

        slider.value = (float)PlayerData.magnetLevel / (float)maxLevel;
    }

    public void BuyOne()
    {
        switch (storeItemType)
        {
            case StoreItemType.shield:
                PlayerData.allCoin -= GetShieldDataPrice(PlayerData.shieldLevel);
                PlayerData.shieldLevel++;
                break;
            case StoreItemType.magnet:
                PlayerData.allCoin -= GetMagnetDataPrice(PlayerData.magnetLevel);
                PlayerData.magnetLevel++;
                break;
            default:
                break;
        }

        FileManager.Save();

        storeRefresher.RefreshStore();
    }

    private class StoreItemData
    {
        public int price;
        public float effectTime;

        public StoreItemData(int price, float effectTime)
        {
            this.price = price;
            this.effectTime = effectTime;
        }
    }

    #region Shield
    static private string shieldName = "Shield";
    static private float shieldBaseTime = 3f;
    static private StoreItemData[] shieldData = new StoreItemData[] { new StoreItemData(50, 5f),
                                                              new StoreItemData(100, 6f),
                                                              new StoreItemData(500, 7f),
                                                              new StoreItemData(1000, 8f),
                                                              new StoreItemData(10000, 10f)};

    static public int GetShieldDataPrice(int level)
    {
        if (level > shieldData.Length)
        {
            return shieldData[shieldData.Length - 1].price;
        }
        return shieldData[level].price;
    }

    static public float GetShieldDataTime()
    {
        if(PlayerData.shieldLevel == 0)
        {
            return shieldBaseTime;
        }
        return shieldData[PlayerData.shieldLevel-1].effectTime;
    }

    #endregion

    #region Magnet

    static private string magnetdName = "Magnet";
    static private float magnetBaseTime = 5f;
    static private StoreItemData[] magnetData = new StoreItemData[] { new StoreItemData(100, 8f),
                                                              new StoreItemData(500, 12f),
                                                              new StoreItemData(1500, 15f),
                                                              new StoreItemData(4500, 20f),
                                                              new StoreItemData(15000, 30f)};

    static public int GetMagnetDataPrice(int level)
    {
        if (level > magnetData.Length)
        {
            return magnetData[magnetData.Length - 1].price;
        }
        return magnetData[level].price;
    }

    static public float GetMagnetDataTime()
    {
        if (PlayerData.magnetLevel == 0)
        {
            return magnetBaseTime;
        }
        return magnetData[PlayerData.magnetLevel - 1].effectTime;
    }

    #endregion
}
