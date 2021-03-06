using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoralHealth : MonoBehaviour
{
    public float startHealth = 6;
    public float health;
    Text healthText;
    public ParticleSystem IncreaseCoral;
    public ParticleSystem DecreaseCoral;

    private void Awake()
    {
        TaskManager.onTaskCompleted += UpdateCoralHealthStat;
    }

    void Start()
    {
        health = startHealth;
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
            IncreaseCoral.Play();
        }
        if(task.coralOutcome < 0)
        {
            DecreaseCoral.Play();
        }
    }
}
