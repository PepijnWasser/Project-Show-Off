using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationCondition : MonoBehaviour
{
    public Text populationText;
    public Image populationImage;

    [HideInInspector]
    public float populationScore;
    [HideInInspector]
    public float displayScore;

    private void Awake()
    {
        populationScore = 5.0f;
        populationText.text = populationScore.ToString();

        displayScore = populationScore * 10;
        populationText.text = displayScore.ToString();
        //populationImage.color = Color.green;
    }
    private void Update()
    {
        displayScore = populationScore * 10;
        populationText.text = displayScore.ToString();
        //UpdateColor();
    }

    /*
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
    */
}
