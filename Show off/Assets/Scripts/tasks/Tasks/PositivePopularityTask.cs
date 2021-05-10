using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PositivePopularityTask", menuName = "Tasks/PositivePopularityTask")]
public class PositivePopularityTask : Task
{
    public override void CheckTask()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            completed = true;
        }
    }

    public override void Reset()
    {
        completed = false;
    }
}
