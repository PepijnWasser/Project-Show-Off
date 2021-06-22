using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTransitionManager : MonoBehaviour
{
    public Canvas transitionCanvas;
    public Image blackPanel;
    public ClockUI clock;
    public Text dayText;
    public TimeScript timeScript;

    public float fadingTime;

    private float time;
    private bool fading = false;

    void Awake()
    {
        TimeScript.onDayNumberChanged += StartTransition;
        ClockUI.onClockCompleted += Finish;
    }

    private void OnDestroy()
    {
        TimeScript.onDayNumberChanged -= StartTransition;
        ClockUI.onClockCompleted -= Finish;
    }

    //fade to black
    void StartTransition()
    {
        Color c = blackPanel.GetComponent<Image>().color;
        blackPanel.GetComponent<Image>().color = new Color(c.r, c.g, c.b, 0);

        time = 0;
        fading = true;
        dayText.text = (timeScript.dayNumber).ToString();
        transitionCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (fading)
        {
            Fade();
        }
    }

    void Fade()
    {
        time += Time.deltaTime / fadingTime;
        Mathf.Clamp(time, 0, 1);

        Color c = blackPanel.GetComponent<Image>().color;
        blackPanel.GetComponent<Image>().color = new Color(c.r, c.g, c.b, time);

        if(time >= 1)
        {
            fading = false;
            PlayTransition();
        }
    }

    void PlayTransition()
    {
        clock.Reset();
        clock.gameObject.SetActive(true);
    }

    void Finish()
    {
        clock.gameObject.SetActive(false);
        transitionCanvas.gameObject.SetActive(false);
    }
}
