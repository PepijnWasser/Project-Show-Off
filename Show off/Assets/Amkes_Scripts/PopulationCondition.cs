using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationCondition : MonoBehaviour
{
    public Text populationText;
    public Image populationImage;
    public float populationScore;

    private void Start()
    {
        populationScore = 5.0f;
        populationText.text = populationScore.ToString();
        populationImage.color = Color.green;
    }
    private void Update()
    {
        /*
        if (Input.GetKey(KeyCode.X))
        {
            //Left-click -> increase
            if (Input.GetMouseButtonUp(0))
            {
                if (populationScore < 10) populationScore += 0.5f;
            }
            //Right-click -> decrease
            if (Input.GetMouseButtonUp(1))
            {
                if (populationScore > 0) populationScore -= 0.5f;
            }
        }
        */

        populationText.text = populationScore.ToString();
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (populationScore > 8 && populationScore <= 10)
        {
            //Too much -> Red
            populationImage.color = new Vector4(1, 0, 0, 1);
        }
        else if (populationScore <= 8 && populationScore >6)
        {
            //Little too much -> Orange
            populationImage.color = new Vector4(1, 0.6f, 0, 1);
        }
        else if (populationScore <= 6 && populationScore > 4)
        {
            //Perfect -> Green
            populationImage.color = new Vector4(0, 1, 0, 1);
        }
        else if (populationScore <= 4 && populationScore > 2)
        {
            //Little too little -> Orange
            populationImage.color = new Vector4(1, 0.6f, 0, 1);
        }
        if (populationScore <= 2 && populationScore > 0)
        {
            //Too little -> Red
            populationImage.color = new Vector4(1, 0, 0, 1);
        }
    }
}
