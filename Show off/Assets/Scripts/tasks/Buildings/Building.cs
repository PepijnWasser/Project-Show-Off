using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Building : MonoBehaviour
{
    public bool showMenu;
    public bool active;
    public GameObject popupCanvas;
    public GameObject taskManager;
    public GameObject popupPrefab;
    public GameObject contentPanel;

    public List<Renderer> objectsToHighlight;

    [HideInInspector]
    public List<Task> taskAtThisLocation = new List<Task>();
    List<GameObject> placedListObjects = new List<GameObject>();

    public EventSystem m_EventSystem;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;



    private void Awake()
    {
        TaskManager.onCurrentTasksChanged += UpdatePanels;
    }

    private void Start()
    {
        m_Raycaster = GetComponentInChildren<GraphicRaycaster>();
       
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
            foreach(Renderer renderer in objectsToHighlight)
            {
                renderer.material.color = new Color(1, 1, 0);
            }
        }
        else
        {
            foreach (Renderer renderer in objectsToHighlight)
            {
                renderer.material.color = new Color(0, 0, 0);
            }
        }
    }

    void CheckClicked()
    {
        if (Input.GetMouseButtonDown(0) && active)
        {
            if (CheckForIfClickIsThis())
            {
                showMenu = true;
            }
            else
            {
                if (CheckChildUI() && showMenu)
                {
                    showMenu = true;
                }
                else
                {
                    showMenu = false;
                }
            }
        }

        if (active == false)
        {
            showMenu = false;
        }
    }
    public void ShowMenu()
    {
        if (popupCanvas != null)
        {
            if (showMenu)
            {
                popupCanvas.SetActive(true);
            }
            else
            {
                popupCanvas.SetActive(false);
            }
        }
    }

    void DestroyAllPlacedPrefabs()
    {
        foreach (GameObject obj in placedListObjects)
        {
            Destroy(obj);
        }
        placedListObjects.Clear();
    }

    void GenerateListPrefabs()
    {
        if (popupPrefab != null)
        {
            foreach (Task task in taskAtThisLocation)
            {
                try
                {
                    GameObject newObject = Instantiate(popupPrefab, contentPanel.transform);
                    newObject.transform.Find("TaskName").GetComponent<Text>().text = task.name;
                    newObject.transform.Find("Description").GetComponent<Text>().text = task.description;
                    
                    Transform acceptButton = newObject.transform.Find("AcceptButton");
                    acceptButton.transform.Find("Text").GetComponent<Text>().text = "Accept Task - " + task.energyCost;
                    acceptButton.GetComponent<CompleteTask>().creator = this.gameObject;
                    acceptButton.GetComponent<CompleteTask>().taskName = task.name;            

                    placedListObjects.Add(newObject);
                }
                catch(Exception e)
                {
                    Debug.LogError(e.Message, this);                 
                }

            }
        }
    }

    bool CheckForIfClickIsThis()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    bool CheckChildUI()
    {
        if(m_Raycaster == null)
        {
            m_Raycaster = GetComponentInChildren<GraphicRaycaster>();
            if(m_Raycaster == null)
            {
                return false;
            }
        }
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        int falseResuts = 0;
        foreach (RaycastResult result in results)
        {
            if (!result.gameObject.transform.IsChildOf(this.transform))
            {
                falseResuts++;
            }
        }

        if (results.Count == 0 || falseResuts == results.Count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
