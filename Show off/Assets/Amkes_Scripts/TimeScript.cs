using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text timeText;

    private int dayNumber = 1;

    private void Awake()
    {
        Energy.onDayCompleted += AddDay;
    }

    private void Start()
    {
        timeText.text = "Day: " + dayNumber;
    }

    private void OnDestroy()
    {
        Energy.onDayCompleted -= AddDay;
    }

    void AddDay()
    {
        dayNumber += 1;
        timeText.text = "Day: " + dayNumber;
    }
}
