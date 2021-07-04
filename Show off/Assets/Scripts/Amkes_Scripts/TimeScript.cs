using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public int dayNumber { get; private set; }

    [SerializeField] private Text timeText;
    
    public delegate void OnDayChanged();
    public static event OnDayChanged onDayNumberChanged;

    private void Awake()
    {
        Energy.onDayCompleted += AddDay;
    }

    private void Start()
    {
        dayNumber = 1;
        timeText.text = "Dag: " + dayNumber;
    }

    private void OnDestroy()
    {
        Energy.onDayCompleted -= AddDay;
    }

    private void AddDay()
    {
        dayNumber += 1;
        timeText.text = "Dag: " + dayNumber;
        onDayNumberChanged?.Invoke();
    }
}
