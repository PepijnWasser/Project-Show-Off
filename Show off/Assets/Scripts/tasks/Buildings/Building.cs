using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
            if (CheckForIfClickIsThis())
            {
                showMenu = true;
            }
            else
            {
                if (CheckChildUI())
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
    void ShowMenu()
    {
        if (menu != null)
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
        foreach (GameObject obj in placedListObjects)
        {
            Destroy(obj);
        }
        placedListObjects.Clear();
    }

    void GenerateListPrefabs()
    {
        if (AcceptButtonPrefab != null)
        {
            foreach (Task task in taskAtThisLocation)
            {
                GameObject newObject = Instantiate(AcceptButtonPrefab, menuPanel.transform);
                newObject.GetComponentInChildren<Text>().text = task.name;
                placedListObjects.Add(newObject);
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
