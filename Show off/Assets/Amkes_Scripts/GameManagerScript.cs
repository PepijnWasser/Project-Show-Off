using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //public Energy energyScript;
    public Text timeText;
    public int dayNumber;
    //private int energy;

    private void Start()
    {
        dayNumber = 1;
        timeText.text = "Day: " + dayNumber;
        //energy = energyScript.energyAmount;
    }

    private void Update()
    {
        /*
        if (energy == 0)
        {
            dayNumber++;
            energy = 5;
        }
        */

        timeText.text = "Day: " + dayNumber;
    }
}
