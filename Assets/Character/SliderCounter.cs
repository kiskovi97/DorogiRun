using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderCounter : MonoBehaviour
{
    [SerializeField]
    private float timeLimit = 5;

    [SerializeField]
    private string sceneName;

    private SceneLoader sceneLoader;

    private Slider slider;
    private float countingUnit;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        countingUnit = 1 / timeLimit;
        sceneLoader = new SceneLoader();
        Debug.Log("staaart");
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0)
        {
            sceneLoader.LoadScene(sceneName);
        }
        slider.value -= Time.deltaTime * countingUnit;
    }
}
