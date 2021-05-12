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
    public GameManagerScript gameManagerScript;

    private void Start()
    {
        energyAmount = 5;
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
                if (energyAmount < 5) energyAmount++;
            }
            //Right-click -> decrease
            if (Input.GetMouseButtonUp(1))
            {
                if (energyAmount > 0) energyAmount--;
            }
        }

        energyText.text = energyAmount.ToString();

        if (energyAmount > 0)
        {
            energyImage.sprite = fullEnergy;
        }
        else
        {
            energyImage.sprite = emptyEnergy;

            if(Input.GetMouseButtonUp(2))
            {
                energyAmount = 5;
                gameManagerScript.dayNumber++;
            }
        }
    }
}
