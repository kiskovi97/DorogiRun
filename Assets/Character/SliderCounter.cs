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
    private SceneLoader sceneLoader;

    [SerializeField]
    private Slider slider;

    private float countingUnit;

    void Start()
    {
        countingUnit = 1 / timeLimit;
    }

    private void OnEnable()
    {
        slider.value = 1;
    }

    void Update()
    {
        if(slider.value == 0)
        {
            GoToLobby();
        }
        slider.value -= Time.unscaledDeltaTime * countingUnit;
    }

    public void GoToLobby()
    {
        sceneLoader.GoToLobby();
    }
}
