using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproveAtBuildingTask : Task
{
    public override void StartTask()
    {
        
    }

    public override void Update()
    {
       
    }

    public override void Reset()
    {
        completed = false;
    }

    public override void CompleteTask()
    {
        completed = true;
    }
}