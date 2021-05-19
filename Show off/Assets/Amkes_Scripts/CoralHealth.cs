using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoralHealth : MonoBehaviour
{
    public Text healthText;
    public Image healthImage;
    public float healthScore;

    private void Start()
    {
        healthScore = 10;
        healthText.text = healthScore.ToString();
        healthImage.color = Color.green;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            //Left-click -> increase
            if (Input.GetMouseButtonUp(0))
            {
                if (healthScore < 10) healthScore++;
            }
            //Right-click -> decrease
            if (Input.GetMouseButtonUp(1))
            {
                if (healthScore > 0) healthScore--;
            }
        }

        healthText.text = healthScore.ToString();
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (healthScore == 10)
        {
            //Thriving -> Green
            healthImage.color = new Vector4(0, 1, 0, 1);
        }
        else if (healthScore < 10 && healthScore >= 7)
        {
            //Fairly healthy -> Yellow
            healthImage.color = new Vector4(1, 0.92f, 0.016f, 1);
        }
        else if (healthScore < 7 && healthScore >= 4)
        {
            //Fairly damaged -> Orange
            healthImage.color = new Vector4(1, 0.6f, 0, 1);
        }
        else if (healthScore < 4 && healthScore > 0)
        {
            //On the brink -> Red
            healthImage.color = new Vector4(1, 0, 0, 1);
        }
        else if (healthScore == 0)
        {
            //Dead
            healthImage.color = new Vector4(0, 0, 0, 1);
            healthText.color = Color.white;
        }
    }
}
