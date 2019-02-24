using UnityEngine;
using UnityEngine.UI;

public class ItemTimer : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType = ItemType.shield;
    [SerializeField]
    private Image image;

    private float amount;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        image.fillAmount = 1;
        amount = GetTime();
    }

    private float GetTime()
    {
        switch (itemType)
        {
            case ItemType.shield:
                return StoreItemIniter.GetShieldDataTime();
            case ItemType.magnet:
                return StoreItemIniter.GetMagnetDataTime();
            default:
                break;
        }
        return 1;
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        image.fillAmount -= Time.unscaledDeltaTime / amount;
        if (image.fillAmount <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private enum ItemType
    {
        shield, magnet
    }


}
