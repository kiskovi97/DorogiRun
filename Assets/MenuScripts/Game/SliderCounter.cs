using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderCounter : MonoBehaviour
{
    [SerializeField]
    private float timeLimit = 5;

    [SerializeField]
    private string gameOverScene;

    [SerializeField]
    private Fader fader;

    [SerializeField]
    private Slider slider;

    private float countingUnit;

    void Start()
    {
        countingUnit = 1 / timeLimit;
    }

    volatile bool countDown = false;

    private void OnEnable()
    {
        slider.value = 1;
        countDown = true;
    }

    void Update()
    {
        if(countDown && slider.value == 0)
        {
            GoToLobby();
            countDown = false;
        }
        slider.value -= Time.unscaledDeltaTime * countingUnit;
    }

    public void GoToLobby()
    {
        fader.StartFadingToLobby();
    }
}
