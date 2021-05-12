using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public bool showMenu;
    public bool active;
    public GameObject menu;
    public GameObject menuPanel;
    public GameObject taskManager;
    public GameObject AcceptButtonPrefab;

    public List<Task> taskAtThisLocation = new List<Task>();
    public List<GameObject> placedListObjects = new List<GameObject>();

    private void Awake()
    {
        TaskManager.onCurrentTasksChanged += UpdatePanels;
    }

    private void OnDestroy()
    {
        TaskManager.onCurrentTasksChanged -= UpdatePanels;
    }

    void Update()
    {
        CheckClicked();
        ShowMenu();
    }

    void UpdatePanels()
    {
        UpdateTaskList();
        CheckIfActive();
        UpdateColor();
        DestroyAllPlacedPrefabs();
        GenerateListPrefabs();
    }

    void UpdateTaskList()
    {
        taskAtThisLocation.Clear();
        foreach (Task task in taskManager.GetComponent<TaskManager>().currentTasks)
        {
            if (task.placeOfQuest.ToString() == this.tag)
            {
                taskAtThisLocation.Add(task);
            }
        }
    }
    void CheckIfActive()
    {
        if (taskAtThisLocation.Count > 0)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }

    void UpdateColor()
    {
        if (active)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }
    }

    void CheckClicked()
    {
        if (Input.GetMouseButtonDown(0) && active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    showMenu = true;
                }
                else
                {
                    showMenu = false;
                }
            }
        }
        else if(active == false)
        {
            showMenu = false;
        }
    }
    void ShowMenu()
    {
        if(menu != null)
        {
            if (showMenu)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }      
    }

    void DestroyAllPlacedPrefabs()
    {
        foreach(GameObject obj in placedListObjects)
        {
            Destroy(obj);
        }
        placedListObjects.Clear();
    }

    void GenerateListPrefabs()
    {
        if(AcceptButtonPrefab != null)
        {
            foreach (Task task in taskAtThisLocation)
            {
                GameObject newObject = Instantiate(AcceptButtonPrefab, menuPanel.transform);
                newObject.GetComponentInChildren<Text>().text = task.name;
                placedListObjects.Add(newObject);
            }
        }
    }
}
