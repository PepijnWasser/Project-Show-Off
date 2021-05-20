using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteTask : MonoBehaviour
{
    GameObject energyScript;

    private void Start()
    {
        energyScript = GameObject.FindGameObjectWithTag("Energy");
        Debug.Log(energyScript);
    }

    public void Complete()
    {
        foreach(Task task in this.transform.parent.parent.parent.GetComponent<Building>().taskAtThisLocation)
        {
            if(task.name == GetComponentInChildren<Text>().text)
            {
                if(energyScript.GetComponent<Energy>().energyAmount > task.energyCost)
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
