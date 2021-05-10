using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PositiveCoralTask", menuName = "Tasks/PositiveCoralTask")]
public class PositiveCoralTask : Task
{
    public override void CheckTask()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            completed = true;
        }
    }

    public override void Reset()
    {
        completed = false;
    }
}
