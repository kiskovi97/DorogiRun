using UnityEngine;
using UnityEngine.UI;

public class ItemTimer : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType = ItemType.shield;
    [SerializeField]
    private Slider slider;

    private float amount;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        slider.value = 1;
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
        slider.value -= Time.unscaledDeltaTime/amount; 
        if(slider.value <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private enum ItemType
    {
        shield, magnet
    }


}
