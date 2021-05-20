using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public Sprite fullEnergy;
    public Sprite emptyEnergy;

    public Image energyImage;
        
    public Text energyText;

    public int energyAmount;

    public TimeScript timeScript;
    public TaskManager taskManagerScript;



    private int maxEnergyAmount = 0;
    private int minEnergyAmount = 0;

    private void Start()
    {
        maxEnergyAmount = taskManagerScript.energy;
        energyAmount = maxEnergyAmount;
        energyText.text = energyAmount.ToString();
        energyImage.sprite = fullEnergy;
        Debug.Log(energyAmount);
    }

    private void Update()
    {
        energyText.text = energyAmount.ToString();

        if (energyAmount > minEnergyAmount)
        {
            energyImage.sprite = fullEnergy;
        }
        else
        {
            energyImage.sprite = emptyEnergy;
            timeScript.dayNumber += 1;
        }
    }

    public void RefillEnergy()
    {
        energyAmount = maxEnergyAmount;
    }
}
