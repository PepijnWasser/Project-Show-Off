using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePopulation : MonoBehaviour
{
    public Text populationText;
    float populationScore;


    private void Awake()
    {
        TaskManager.onTaskCompleted += UpdatePopularityText;
    }

    private void Start()
    {
        populationScore = 4;
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
    }

}
