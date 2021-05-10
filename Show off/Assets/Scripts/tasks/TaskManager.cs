using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public List<Task> potentialTasks;

    public int tasksAvailible;
    public int tasksInADay;

    public List<Task> positiveCoralTasks = new List<Task>();
    public List<Task> positivePopularityTasks = new List<Task>();
    public List<Task> neutralOrNegativeTasks = new List<Task>();

    public List<Task> currentTasks = new List<Task>();

    private void Start()
    {
        for(int i = 0; i < potentialTasks.Count; i++)
        {
            //tasks that have positive coral and any poularity
            if(potentialTasks[i].coralOutcome > 0)
            {
                positiveCoralTasks.Add(potentialTasks[i]);
            }
            //tasks that have positive popularity and neutral or negative coral
            else if (potentialTasks[i].popularityOutcome > 0)
            {
                positivePopularityTasks.Add(potentialTasks[i]);
            }
            //tasks that have neutral or negative popularity and neutral or negative 
            else
            {
                neutralOrNegativeTasks.Add(potentialTasks[i]);
            }
        }

        currentTasks = positiveCoralTasks;
    }

    private void Update()
    {
        int completedTasks = 0;
        foreach(Task task in currentTasks)
        {
            task.CheckTask();
            if (task.completed)
            {
                completedTasks++;
            }
        }
        if(completedTasks >= tasksInADay)
        {
            Debug.Log("Tasks complete");
            ResetTasks(currentTasks);
        }
    }


    void GenerateTasksForNewDay()
    {
        List<Task> newTasks = new List<Task>();
        if(positiveCoralTasks.Count >= 2)
        {
            int taskCount = positiveCoralTasks.Count;
            if(taskCount > 4)
            {
                taskCount = 4;
            }
            for(int i = 0; i < taskCount; i++)
            {
                int r = Random.Range(0, positiveCoralTasks.Count);
                while (newTasks.Contains(positiveCoralTasks[r]))
                {
                    r = Random.Range(0, positiveCoralTasks.Count);
                }
                newTasks.Add(positiveCoralTasks[r]);
            }
        }
        else
        {
            Debug.LogWarning("to few PositiveCoralTasks");
        }

        if (positivePopularityTasks.Count >= 1)
        {
            int taskCount = positivePopularityTasks.Count;
            if(taskCount > tasksAvailible - newTasks.Count)
            {
                taskCount = tasksAvailible - newTasks.Count;
            }
            if(taskCount > 3)
            {
                taskCount = 3;
            }

            for(int i = 0; i < taskCount; i++)
            {
                int r = Random.Range(0, positivePopularityTasks.Count);
                while (newTasks.Contains(positivePopularityTasks[r]))
                {
                    r = Random.Range(0, positivePopularityTasks.Count);
                }
                newTasks.Add(positivePopularityTasks[r]);
            }
        }
        else
        {
            Debug.LogWarning("to few PositivePopularityTasks");
        }

        if (neutralOrNegativeTasks.Count >= tasksAvailible - newTasks.Count)
        {
            for (int i = newTasks.Count; i < tasksAvailible; i++)
            {
                int r = Random.Range(0, neutralOrNegativeTasks.Count);
                while (newTasks.Contains(neutralOrNegativeTasks[r]))
                {
                    r = Random.Range(0, neutralOrNegativeTasks.Count);
                }
                newTasks.Add(neutralOrNegativeTasks[r]);
            }
        }
        else
        {
            Debug.LogWarning("to few NeutralOrNegativeTasks");
        }
    }

    void ResetTasks(List<Task> taskListToReset)
    {
        foreach(Task task in taskListToReset)
        {
            task.Reset();
        }
    }
}
