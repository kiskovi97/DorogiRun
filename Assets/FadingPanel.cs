using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadingPanel : MonoBehaviour
{
    [SerializeField]
    private Fader fader;
    [SerializeField]
    private Image img;

    [SerializeField]
    private FadeType fadeType;

    private float time;

    private int direction = 1;

    void Start()
    {
        if(fadeType == FadeType.FadeOut)
        {
            direction = 1;
            time = fader.FadeOutTime;
        }
        else
        {
            direction = -1;
            time = fader.FadeInTime;
        }
    }

    void Update()
    {
        Color color = img.color;
        if(fadeType == FadeType.FadeIn && color.a <= 0)
        {
            gameObject.SetActive(false);
        }

        color.a += direction * Time.unscaledDeltaTime / time;
        img.color = color;
    }

    private enum FadeType
    {
        FadeOut, FadeIn
    }
}
