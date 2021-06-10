using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Task : MonoBehaviour
{
    public bool completed;

    public int energyCost;
    public string description;

    public float coralOutcome;
    public float popularityOutcome;
    public string outcomeMessage;


    public enum Building
    {
            Haven,
            Stadhuis,
            Lab,
            Hotel,
            TaakBord,
            Winkel
    }

    public Building placeOfQuest;

    public abstract void Update();
    public abstract void StartTask();

    public abstract void CompleteTask();
    public abstract void Reset();
}

