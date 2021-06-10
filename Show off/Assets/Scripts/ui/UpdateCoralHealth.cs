using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoralHealth : MonoBehaviour
{
    float health;
    Text healthText;


    private void Awake()
    {
        TaskManager.onTaskCompleted += UpdateCoralHealthStat;
    }

    void Start()
    {
        health = 10;
        healthText = GetComponent<Text>();
        UpdateCoralHealthStat();
    }

    private void OnDestroy()
    {
        TaskManager.onTaskCompleted -= UpdateCoralHealthStat;
    }

    void UpdateCoralHealthStat()
    {
        healthText.text = health.ToString();
    }

    void UpdateCoralHealthStat(Task task)
    {
        health += task.coralOutcome;
        healthText.text = health.ToString();

        if(task.coralOutcome > 0)
        {

        }
        if(task.coralOutcome < 0)
        {

        }
    }
}
