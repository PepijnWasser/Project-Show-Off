using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NegativeTask", menuName = "Tasks/NegativeTask")]
public class NegativeTask : Task
{
    public override void CheckTask()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            completed = true;
        }
    }

    public override void Reset()
    {
        completed = false;
    }
}
