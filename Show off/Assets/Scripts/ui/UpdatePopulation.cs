using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePopulation : MonoBehaviour
{
    public Text populationText;
    float populationScore;
    public ParticleSystem IncreasePopularity;
    public ParticleSystem DecreasePopularity;


    private void Awake()
    {
        TaskManager.onTaskCompleted += UpdatePopularityText;
    }

    private void Start()
    {
        populationScore = 0;
        UpdatePopularityText();
    }

    private void OnDestroy()
    {
        TaskManager.onTaskCompleted -= UpdatePopularityText;
    }

    void UpdatePopularityText()
    {
        float displayScore = populationScore * 10;

        populationText.text = displayScore.ToString();
    }

    void UpdatePopularityText(Task task)
    {
        populationScore += task.popularityOutcome;

        float displayScore = populationScore * 10;
        populationText.text = displayScore.ToString();

        if(task.popularityOutcome > 0)
        {
            IncreasePopularity.Play();
        }
        if(task.popularityOutcome < 0)
        {
            DecreasePopularity.Play();
        }
    }

}
