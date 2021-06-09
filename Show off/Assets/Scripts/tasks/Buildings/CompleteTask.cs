using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteTask : MonoBehaviour
{
    GameObject energyScript;

    [HideInInspector]
    public GameObject creator;
    [HideInInspector]
    public string taskName;

    private void Start()
    {
        energyScript = GameObject.FindGameObjectWithTag("Energy");
    }

    public void Complete()
    {
        foreach (Task task in creator.GetComponent<Building>().taskAtThisLocation)
        {
            if(task.name == taskName)
            {
                if(energyScript.GetComponent<Energy>().energyAmount >= task.energyCost)
                {
                    task.completed = true;
                }
                else
                {
                    Debug.Log("too few energy");
                }
            }
        }
    }
}
