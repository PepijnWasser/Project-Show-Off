using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text timeText;
    public int dayNumber;

    private void Start()
    {
        dayNumber = 0;
        timeText.text = "Day: " + dayNumber;
    }

    private void Update()
    {
        timeText.text = "Day: " + dayNumber;
    }
}
