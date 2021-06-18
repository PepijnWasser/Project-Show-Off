using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TaskTests : MonoBehaviour
{
    [UnityTest]
    public IEnumerator TestSorting()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<ApproveAtBuildingTask>();
        gameObject.GetComponent<ApproveAtBuildingTask>().coralOutcome = 1;
        gameObject.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 0;
        
        var gameObject2 = new GameObject();
        gameObject2.AddComponent<ApproveAtBuildingTask>();
        gameObject2.GetComponent<ApproveAtBuildingTask>().coralOutcome = 0;
        gameObject2.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 1;

        var gameObject3 = new GameObject();
        gameObject3.AddComponent<ApproveAtBuildingTask>();
        gameObject3.GetComponent<ApproveAtBuildingTask>().coralOutcome = 0;
        gameObject3.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 0;
        
        var gameObject4 = new GameObject();
        var taskManager = gameObject4.AddComponent<TaskManager>();

        taskManager.potentialTaskObjects = new List<GameObject> { gameObject, gameObject2, gameObject3 };
        taskManager.SortTasks();

        Assert.AreEqual(1, taskManager.positiveCoralTasks.Count);
        Assert.AreEqual(1, taskManager.positivePopularityTasks.Count);
        Assert.AreEqual(1, taskManager.neutralOrNegativeTasks.Count);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestGeneratingPositiveCoral()
    {
        var task = new GameObject();
        task.AddComponent<ApproveAtBuildingTask>();
        task.GetComponent<ApproveAtBuildingTask>().coralOutcome = 1;
        task.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 0;
        task.GetComponent<ApproveAtBuildingTask>().placeOfQuest = ApproveAtBuildingTask.Building.Haven;

        var task2 = new GameObject();
        task2.AddComponent<ApproveAtBuildingTask>();
        task2.GetComponent<ApproveAtBuildingTask>().coralOutcome = 0;
        task2.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 1;
        task2.name = "task2";

        var gameObject4 = new GameObject();
        var taskManager = gameObject4.AddComponent<TaskManager>();

        var building = new GameObject();
        building.AddComponent<Building>();
        
        building.tag = "Haven";
        building.GetComponent<Building>().objectsToHighlight = new List<Renderer>();

        taskManager.potentialTaskObjects = new List<GameObject> { task, task2 };
        taskManager.tasksAvailible = 1;
        taskManager.minMaxPositiveCoralTask = new Vector2(1, 1);
        taskManager.SortTasks();
        taskManager.GenerateTasksForNewDay();

        Debug.Log(taskManager.currentTasks[0].name);
        bool b = taskManager.currentTasks.Contains(task2.GetComponent<Task>());
        Assert.AreEqual(false, b);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestGeneratingPositivePopularity()
    {
        var task = new GameObject();
        task.AddComponent<ApproveAtBuildingTask>();
        task.GetComponent<ApproveAtBuildingTask>().coralOutcome = 1;
        task.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 0;
        task.GetComponent<ApproveAtBuildingTask>().placeOfQuest = ApproveAtBuildingTask.Building.Haven;

        var task2 = new GameObject();
        task2.AddComponent<ApproveAtBuildingTask>();
        task2.GetComponent<ApproveAtBuildingTask>().coralOutcome = 0;
        task2.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 1;
        task2.name = "task2";

        var gameObject4 = new GameObject();
        var taskManager = gameObject4.AddComponent<TaskManager>();

        var building = new GameObject();
        building.AddComponent<Building>();
        building.tag = "Haven";
        building.GetComponent<Building>().objectsToHighlight = new List<Renderer>();

        taskManager.potentialTaskObjects = new List<GameObject> { task, task2 };
        taskManager.tasksAvailible = 1;
        taskManager.minMaxPositiveCoralTask = new Vector2(0, 0);
        taskManager.minMaxPositivePopularityTask = new Vector2(1, 1);
        taskManager.SortTasks();
        taskManager.GenerateTasksForNewDay();

        Debug.Log(taskManager.currentTasks[0].name);
        bool b = taskManager.currentTasks.Contains(task2.GetComponent<Task>());
        Assert.AreEqual(true, b);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestGeneratingNegative()
    {
        var task = new GameObject();
        task.AddComponent<ApproveAtBuildingTask>();
        task.GetComponent<ApproveAtBuildingTask>().coralOutcome = 1;
        task.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 0;
        task.GetComponent<ApproveAtBuildingTask>().placeOfQuest = ApproveAtBuildingTask.Building.Haven;

        var task2 = new GameObject();
        task2.AddComponent<ApproveAtBuildingTask>();
        task2.GetComponent<ApproveAtBuildingTask>().coralOutcome = 0;
        task2.GetComponent<ApproveAtBuildingTask>().popularityOutcome = 0;
        task2.name = "task2";

        var gameObject4 = new GameObject();
        var taskManager = gameObject4.AddComponent<TaskManager>();

        var building = new GameObject();
        building.AddComponent<Building>();
        building.tag = "Haven";
        building.GetComponent<Building>().objectsToHighlight = new List<Renderer>();

        taskManager.potentialTaskObjects = new List<GameObject> { task, task2 };
        taskManager.tasksAvailible = 1;
        taskManager.minMaxPositiveCoralTask = new Vector2(0, 0);
        taskManager.minMaxPositivePopularityTask = new Vector2(0, 0);
        taskManager.SortTasks();
        taskManager.GenerateTasksForNewDay();

        Debug.Log(taskManager.currentTasks[0].name);
        bool b = taskManager.currentTasks.Contains(task2.GetComponent<Task>());
        Assert.AreEqual(true, b);

        yield return null;
    }
}
