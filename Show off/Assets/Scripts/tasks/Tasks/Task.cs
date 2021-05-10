using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Task : ScriptableObject
{
    public bool completed;
    public float coralOutcome;
    public float popularityOutcome;

    public abstract void CheckTask();
    public abstract void Reset();
}

