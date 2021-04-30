using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public int energy;
    public int numOfEnergy;

    public Image[] energyPoints;
    public Sprite fullEnergy;
    public Sprite emptyEnergy;

    private void Update()
    {
        //Make sure energy doesn't go above max amount of energy
        if (energy > numOfEnergy) energy = numOfEnergy;
        //Make sure energy doesn't go below 0
        if (energy < 0) energy = 0;
        
        for (int i = 0; i < energyPoints.Length; i++)
        {
            //Check if sprite i is empty or full
            if (i < energy)
            {
                energyPoints[i].sprite = fullEnergy;
            }
            else
            {
                energyPoints[i].sprite = emptyEnergy;
            }

            //Only display energy-sprites for amount given
            if (i < numOfEnergy)
            {
                energyPoints[i].enabled = true;
            }
            else
            {
                energyPoints[i].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //Add energy
            energy++;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Subtract energy
            energy--;
        }
    }
}
