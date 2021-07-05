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
    [SerializeField] private int amountOfPositiveCoralTasksEasy;
    [SerializeField] private int amountOfPositiveCoralTasksMedium;
    [SerializeField] private int amountOfPositiveCoralTasksHard;

    bool checkedDay3;
    bool checkedDay6;

    private void Start()
    {
        CheckForErrors();
    }

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

    private void ModifyDificulty(float healthScore)
    {
        if(healthScore <= easyDifficultyScore)
        {
            taskManagerScript.positiveCoralTasksToGenerate = amountOfPositiveCoralTasksEasy;
        }
        else if (healthScore <= hardDifficultyScore)
        {
            taskManagerScript.positiveCoralTasksToGenerate = amountOfPositiveCoralTasksMedium;
        }
        else
        {
            taskManagerScript.positiveCoralTasksToGenerate = amountOfPositiveCoralTasksHard;
        }
    }

    private void CheckForErrors()
    {
        //Check for errors in difficulty score
        if (easyDifficultyScore > hardDifficultyScore)
        {
            Debug.LogError("easyDifficultyScore is bigger than hardDifficultyScore. Please lower this number.");
        }

        //Check for errors in more positive tasks than available tasks
        if (amountOfPositiveCoralTasksEasy > taskManagerScript.tasksAvailible ||
            amountOfPositiveCoralTasksMedium > taskManagerScript.tasksAvailible ||
            amountOfPositiveCoralTasksHard > taskManagerScript.tasksAvailible)
        {
            Debug.LogError("amountOfPositiveCoralTasks is bigger than tasksAvailable. Please lower this number.");
        }
        
        //Check for errors in amount of positive coral tasks
        if (amountOfPositiveCoralTasksEasy > amountOfPositiveCoralTasksHard)
        {
            Debug.LogError("amountOfPositiveCoralTasksEasy is bigger than amountOfPositiveCoralTasksHard. Please lower this number.");
        }
        else if (amountOfPositiveCoralTasksEasy > amountOfPositiveCoralTasksMedium)
        {
            Debug.LogError("amountOfPositiveCoralTasksEasy is bigger than amountOfPositiveCoralTasksMedium. Please lower this number.");
        }
        
        if (amountOfPositiveCoralTasksMedium > amountOfPositiveCoralTasksHard)
        {
            Debug.LogError("amountOfPositiveCoralTasksMedium is bigger than amountOfPositiveCoralTasksHard. Please lower this number.");
        }
    }
}
