using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeutralTask", menuName = "Tasks/NeutralTask")]
public class NeutralTask : Task
{
    public override void CheckTask()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            completed = true;
        }
    }

    public override void Reset()
    {
        completed = false;
    }
}
