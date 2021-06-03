using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> potentialTaskObjects;

    public List<Task> positiveCoralTasks = new List<Task>();
    public List<Task> positivePopularityTasks = new List<Task>();
    public List<Task> neutralOrNegativeTasks = new List<Task>();

    public List<Task> currentTasks = new List<Task>();

    public int tasksAvailible;
    public int energy;
    public Vector2 minMaxPositiveCoralTask;
    public Vector2 minMaxPositivePopularityTask;

    public List<Building> buildingsToHighLight = new List<Building>();

    public delegate void CurrentTasksChanged();
    public static event CurrentTasksChanged onCurrentTasksChanged;

    public delegate void TaskCompleted(Task task);
    public static event TaskCompleted onTaskCompleted;

    //Amke's mess
    public Energy energyScript;
    public CoralHealth coralHealthScript;
    public PopulationCondition populationScoreScript;

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
            GameObject.FindGameObjectWithTag("DebugText").GetComponent<Text>().text = "Changing task";
            EndTask(task);
        }
    }

    void GenerateNewDay()
    {
        StopAllHighLightsOfList(currentTasks);
        GenerateTasksForNewDay();
        StartTasks(currentTasks);
    }

    void GenerateTasksForNewDay()
    {
        List<Task> newTasks = new List<Task>();
        GeneratePositiveCoralTasks(newTasks);
        GeneratePositivePopulationTasks(newTasks);
        GenerateNegativeTasks(newTasks);
        currentTasks = newTasks;

        onCurrentTasksChanged?.Invoke();
    }

    void GeneratePositiveCoralTasks(List<Task> newTasks)
    {
        if (positiveCoralTasks.Count >= minMaxPositiveCoralTask.x)
        {
            //trim taskCount
            int taskCount = positiveCoralTasks.Count;
            if (taskCount > minMaxPositiveCoralTask.y)
            {
                taskCount = (int)minMaxPositiveCoralTask.y;
            }
            if(taskCount > tasksAvailible)
            {
                taskCount = tasksAvailible;
            }
            if(taskCount > tasksAvailible - minMaxPositivePopularityTask.x)
            {
                taskCount = tasksAvailible - (int)minMaxPositivePopularityTask.x;
                if(taskCount < minMaxPositiveCoralTask.x)
                {
                    Debug.LogWarning("to few PositiveCoralTasks after trimming");
                }
            }

            taskCount = Random.Range((int)minMaxPositiveCoralTask.x, taskCount + 1);
            for (int i = 0; i < taskCount; i++)
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
    }

    void GeneratePositivePopulationTasks(List<Task> newTasks)
    {
        if (positivePopularityTasks.Count >= minMaxPositivePopularityTask.x)
        {
            int taskCount = positivePopularityTasks.Count;
            if (taskCount > tasksAvailible - newTasks.Count)
            {
                taskCount = tasksAvailible - newTasks.Count;
            }
            if (taskCount > minMaxPositivePopularityTask.y)
            {
                taskCount = (int)minMaxPositivePopularityTask.y;
            }

            taskCount = Random.Range((int)minMaxPositivePopularityTask.x, taskCount + 1);
            for (int i = 0; i < taskCount; i++)
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
    }

    void GenerateNegativeTasks(List<Task> newTasks)
    {
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
            Debug.Log(newTasks.Count);
        }
    }

    void StopHighlightingbuildingOfTask(Task task)
    {
        bool needToStop = true;
        foreach(Task _task in currentTasks)
        {
            if(_task.placeOfQuest == task.placeOfQuest && _task != task && _task.completed == false)
            {
                needToStop = false;
                break;
            }
        }
        if (needToStop)
        {
            GameObject building = GameObject.FindGameObjectWithTag(task.placeOfQuest.ToString());
            if(building.GetComponent<Building>() == null)
            {
                //GameObject.FindGameObjectWithTag("DebugText").GetComponent<Text>().text = "error found";
            }

            building.GetComponent<Building>().active = false;
        }
    }

    void StopAllHighLightsOfList(List<Task> taskList)
    {
        foreach(Task task in taskList)
        {
            GameObject building = GameObject.FindGameObjectWithTag(task.placeOfQuest.ToString());
            building.GetComponent<Building>().active = false;
        }
    }

    void HighLightbuildingOfTask(Task task)
    {
        GameObject building = GameObject.FindGameObjectWithTag(task.placeOfQuest.ToString());
        building.GetComponent<Building>().active = true;
    }

    void StartTasks(List<Task> tasks)
    {
        foreach (Task task in tasks)
        {
            ResetTask(task);
            task.StartTask();
            HighLightbuildingOfTask(task);
        }
    }

    void ResetTask(Task taskToReset)
    {
        taskToReset.Reset();
    }

    void EndTask(Task task)
    {
        StopHighlightingbuildingOfTask(task);
        currentTasks.Remove(task);
        onCurrentTasksChanged?.Invoke();
        onTaskCompleted?.Invoke(task);

        //Amke's mess
        coralHealthScript.healthScore += task.coralOutcome;
        if (coralHealthScript.healthScore > 10)
        {
            coralHealthScript.healthScore = 10;
        }

        populationScoreScript.populationScore += task.popularityOutcome;
        /*
        if (populationScoreScript.populationScore > 10)
        {
            populationScoreScript.populationScore = 10;
        }
        */
    }

    void SortTasks()
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
            //tasks that have neutral or negative popularity and neutral or negative 
            else
            {
                neutralOrNegativeTasks.Add(potentialTasks[i]);
            }
        }

    }
}
