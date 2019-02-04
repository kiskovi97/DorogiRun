using UnityEngine;

public class CharacterItems : MonoBehaviour
{
    [Header("Shield")]
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject shieldTimer;

    [Header("Magnet")]
    [SerializeField]
    private GameObject magnet;
    [SerializeField]
    private GameObject magnetTimer;

    private bool shielded = false;

    private float shieldOnTime;

    public bool Shielded
    {
        get
        {
            return shielded;
        }
    }

    private bool magnetOn = false;

    private float magnetOnTime;

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        if (shielded)
        {
            shieldOnTime -= Time.unscaledDeltaTime;
            if (shieldOnTime <= 0)
            {
                ShieldDeactivate();
            }
        }
        if (magnetOn)
        {
            magnetOnTime -= Time.unscaledDeltaTime;
            if (magnetOnTime <= 0)
            {
                DeactivateMagnet();
            }
        }
    }

    public void ShieldActivate()
    {
        if (shieldTimer.activeSelf)
        {
            ItemTimer itemTimer = shieldTimer.GetComponent<ItemTimer>();
            itemTimer.Init();
        }
        else
        {
            shieldTimer.SetActive(true);
        }
        shield.SetActive(true);
        shielded = true;
        shieldOnTime = StoreItemIniter.GetShieldDataTime();
    }

    public void ShieldDeactivate()
    {
        shieldTimer.SetActive(false);
        shield.SetActive(false);
        shielded = false;
    }

    public void ActivateMagnet()
    {
        if (magnetTimer.activeSelf)
        {
            ItemTimer itemTimer = magnetTimer.GetComponent<ItemTimer>();
            itemTimer.Init();
        }
        else
        {
            magnetTimer.SetActive(true);
        }
        magnet.SetActive(true);
        magnetOn = true;
        magnetOnTime = StoreItemIniter.GetMagnetDataTime();
    }

    private void DeactivateMagnet()
    {
        magnetOn = false;
        magnet.SetActive(false);
        magnetTimer.SetActive(false);
    }
}
