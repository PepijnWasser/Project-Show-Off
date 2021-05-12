using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteTask : MonoBehaviour
{
    public void Complete()
    {
        foreach(Task task in this.transform.parent.parent.parent.GetComponent<Building>().taskAtThisLocation)
        {
            if(task.name == GetComponentInChildren<Text>().text)
            {
                task.completed = true;
            }
        }
    }
}
