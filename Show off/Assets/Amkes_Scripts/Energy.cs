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
        //energyAmount = 5;
        maxEnergyAmount = taskManagerScript.tasksInADay;
        energyAmount = maxEnergyAmount;
        energyText.text = energyAmount.ToString();
        energyImage.sprite = fullEnergy;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            //Left-click -> increase
            if (Input.GetMouseButtonUp(0))
            {
                if (energyAmount < maxEnergyAmount) energyAmount++;
            }
            //Right-click -> decrease
            if (Input.GetMouseButtonUp(1))
            {
                if (energyAmount > minEnergyAmount) energyAmount--;
            }
        }

        energyText.text = energyAmount.ToString();

        if (energyAmount > minEnergyAmount)
        {
            energyImage.sprite = fullEnergy;
        }
        else
        {
            energyImage.sprite = emptyEnergy;

            if(Input.GetMouseButtonUp(2))
            {
                energyAmount = maxEnergyAmount;
                timeScript.dayNumber++;
            }
        }
    }
}
