using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DynamicDifficulty : MonoBehaviour
{
    [SerializeField] private TaskManager taskManagerScript;
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private CoralState coralStateScript;
    [SerializeField] private int easyDifficultyScore;
    [SerializeField] private int hardDifficultyScore;

    bool checkedDay3;
    bool checkedDay6;

    private void Update()
    {
        //Change difficulty according to player's score on day 3 and 6
        if (timeScript.dayNumber == 3)
        {
            if (checkedDay3)
            {
                checkedDay3 = true;
                float healthScore = Int32.Parse(coralStateScript.healthText.text);
                ModifyDificulty(healthScore);
            }
        }
        if (timeScript.dayNumber == 6)
        {
            if (checkedDay6)
            {
                checkedDay6 = true;
                float healthScore = Int32.Parse(coralStateScript.healthText.text);
                ModifyDificulty(healthScore);            
            }
        }
    }

    void ModifyDificulty(float healthScore)
    {
        if(healthScore <= easyDifficultyScore)
        {
            taskManagerScript.positiveCoralTasksToGenerate = 3;
        }
        else if (healthScore <= hardDifficultyScore)
        {
            taskManagerScript.positiveCoralTasksToGenerate = 2;
        }
        else
        {
            taskManagerScript.positiveCoralTasksToGenerate = 1;
        }
    }
}
