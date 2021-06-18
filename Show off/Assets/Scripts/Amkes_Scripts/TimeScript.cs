using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text timeText;

    public int dayNumber = 1;

    public delegate void OnDayChanged();
    public static event OnDayChanged onDayNumberChanged;

    private void Awake()
    {
        Energy.onDayCompleted += AddDay;
    }

    private void Start()
    {
        timeText.text = "Dag: " + dayNumber;
    }

    private void OnDestroy()
    {
        Energy.onDayCompleted -= AddDay;
    }

    void AddDay()
    {
        dayNumber += 1;
        timeText.text = "Day: " + dayNumber;
        onDayNumberChanged?.Invoke();
    }
}
