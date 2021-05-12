using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanelManager : MonoBehaviour
{
    public GameObject taskManager;
    public GameObject taskPanelPrefab;

    List<GameObject> placedPanels = new List<GameObject>();

    private void Awake()
    {
        TaskManager.onCurrentTasksChanged += UpdatePanels;
    }

    private void OnDestroy()
    {
        TaskManager.onCurrentTasksChanged -= UpdatePanels;
    }

    private void OnEnable()
    {
        UpdatePanels();
    }

    public void UpdatePanels()
    {
        if(placedPanels.Count > 0)
        {
            foreach (GameObject obj in placedPanels)
            {
                Destroy(obj);
            }
        }

        foreach(Task task in taskManager.GetComponent<TaskManager>().currentTasks)
        {
            GameObject tempObject = Instantiate(taskPanelPrefab, this.transform);
            tempObject.GetComponentInChildren<Text>().text = task.name + " in:\n " + task.placeOfQuest;
            placedPanels.Add(tempObject);
        }
    }
}
