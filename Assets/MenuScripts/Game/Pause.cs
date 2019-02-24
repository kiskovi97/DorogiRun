using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Text counter;
    [SerializeField]
    private int countMax = 3;

    private int count;

    private float prevTime = 1f;

    public void PauseGame()
    {
        prevTime = Time.timeScale;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        //Time.timeScale = prevTime;
        count = countMax;
        CountDown();
        pauseMenu.SetActive(false);
    }

    private void CountDown()
    {
        if (count == countMax)
        {
            counter.gameObject.SetActive(true);
        }
        counter.text = "" + count;
        count--;
        if (count != -1)
        {
            StartCoroutine(CallInTime(1f));
        }
        else
        {
            count = countMax;
            counter.gameObject.SetActive(false);
            Time.timeScale = prevTime;
        }
    }

    private IEnumerator CallInTime(float time)
    {
        var t = 0f;
        while (t < 1)
        {
            t += Time.unscaledDeltaTime / time;
            yield return null;
        }
        CountDown();
    }
}
