using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationCondition : MonoBehaviour
{
    public Text populationText;
    public Image populationImage;
    private int populationScore;

    private void Start()
    {
        populationScore = 50;
        populationText.text = populationScore.ToString();
        populationImage.color = Color.green;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            //Left-click -> increase
            if (Input.GetMouseButtonUp(0))
            {
                if (populationScore < 100) populationScore += 5;
            }
            //Right-click -> decrease
            if (Input.GetMouseButtonUp(1))
            {
                if (populationScore > 0) populationScore -= 5;
            }
        }

        populationText.text = populationScore.ToString();
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (populationScore > 80 && populationScore <= 100)
        {
            //Too much -> Red
            populationImage.color = new Vector4(1, 0, 0, 1);
        }
        else if (populationScore <= 80 && populationScore >60)
        {
            //Little too much -> Orange
            populationImage.color = new Vector4(1, 0.6f, 0, 1);
        }
        else if (populationScore <= 60 && populationScore > 40)
        {
            //Perfect -> Green
            populationImage.color = new Vector4(0, 1, 0, 1);
        }
        else if (populationScore <= 40 && populationScore > 20)
        {
            //Little too little -> Orange
            populationImage.color = new Vector4(1, 0.6f, 0, 1);
        }
        if (populationScore <= 20 && populationScore > 0)
        {
            //Too little -> Red
            populationImage.color = new Vector4(1, 0, 0, 1);
        }
    }
}
