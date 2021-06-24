using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> potentialTaskObjects;

    public List<Task> positiveCoralTasks = new List<Task>();
    public List<Task> positivePopularityTasks = new List<Task>();

    [HideInInspector]
    public List<Task> currentTasks = new List<Task>();

    public int tasksAvailible;
    public int positiveCoralTasksToGenerate;
    public int energy;

    [SerializeField] private Text popularityText;
    [SerializeField] private float popularityDifficultyRange;
    [SerializeField] private UpdateCoralHealth coralHealthScript;

    public delegate void CurrentTasksChanged();
    public static event CurrentTasksChanged onCurrentTasksChanged;

    public delegate void TaskCompleted(Task task);
    public static event TaskCompleted onTaskCompleted;

    private void Awake()
    {
        Energy.onDayCompleted += GenerateNewDay;
    }

    private void Start()
    {
        SortTasks();
        GenerateNewDay();
    }

    private void OnDestroy()
    {
        Energy.onDayCompleted -= GenerateNewDay;
    }

    private void Update()
    {
        List<Task> tasksToRemove = new List<Task>();
        foreach (Task task in currentTasks)
        {
            task.Update();
            if (task.completed)
            {
                tasksToRemove.Add(task);
            }
        }
        foreach(Task task in tasksToRemove)
        {
            EndTask(task);
        }
    }

    void GenerateNewDay()
    {
        CheckCoralHealth();
        GenerateTasksForNewDay();
        StartTasks(currentTasks);
    }

    public void GenerateTasksForNewDay()
    {
        List<Task> newTasks = new List<Task>();
        GeneratePositiveCoralTasks(newTasks);
        GeneratePositivePopularityTasks(newTasks);
        currentTasks = newTasks;
        onCurrentTasksChanged?.Invoke();
    }

    void GeneratePositiveCoralTasks(List<Task> newTasks)
    {
        if (positiveCoralTasks.Count >= positiveCoralTasksToGenerate)
        {
            for (int i = 0; i < positiveCoralTasksToGenerate; i++)
            {
                int r = UnityEngine.Random.Range(0, positivePopularityTasks.Count);
                while (newTasks.Contains(positiveCoralTasks[r]))
                {
                    r = UnityEngine.Random.Range(0, positiveCoralTasks.Count);
                }
                newTasks.Add(positiveCoralTasks[r]);
            }
        }
        else
        {
            Debug.LogWarning("to few PositiveCoralTasks");
        }
    }

    void GeneratePositivePopularityTasks(List<Task> newTasks)
    {
        if (positivePopularityTasks.Count >= tasksAvailible - positiveCoralTasksToGenerate)
        {
            for (int i = 0; i < tasksAvailible - positiveCoralTasksToGenerate; i++)
            {
                int r = UnityEngine.Random.Range(0, positivePopularityTasks.Count);
                while (newTasks.Contains(positivePopularityTasks[r]))
                {
                    r = UnityEngine.Random.Range(0, positivePopularityTasks.Count);
                }
                newTasks.Add(positivePopularityTasks[r]);
            }
        }
        else
        {
            Debug.LogWarning("to few PositivePopularityTasks");
        }
    }

    void StartTasks(List<Task> tasks)
    {
        foreach (Task task in tasks)
        {
            ResetTask(task);
            task.StartTask();
        }
    }

    void ResetTask(Task taskToReset)
    {
        taskToReset.Reset();
    }

    void EndTask(Task task)
    {
        currentTasks.Remove(task);
        onCurrentTasksChanged?.Invoke();
        onTaskCompleted?.Invoke(task);
    }

    public void SortTasks()
    {
        List<Task> potentialTasks = new List<Task>();
        foreach (GameObject obj in potentialTaskObjects)
        {
            potentialTasks.Add(obj.GetComponent<Task>());
            GameObject newObject = Instantiate(obj);
            newObject.transform.parent = this.transform;
        }

        for (int i = 0; i < potentialTasks.Count; i++)
        {
            //tasks that have positive coral and any poularity
            if (potentialTasks[i].coralOutcome > 0)
            {
                positiveCoralTasks.Add(potentialTasks[i]);
            }
            //tasks that have positive popularity and neutral or negative coral
            else if (potentialTasks[i].popularityOutcome > 0)
            {
                positivePopularityTasks.Add(potentialTasks[i]);
            }
        }

    }

    private void CheckCoralHealth()
    {
        float popularityNum = Int32.Parse(popularityText.text);

        if (popularityNum >= popularityDifficultyRange)
        {
            Debug.Log("Subtracting 1 coral-health");
            coralHealthScript.health--;
        }
    }
}
