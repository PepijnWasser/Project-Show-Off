using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Task : MonoBehaviour
{
    public bool completed;
    public float coralOutcome;
    public float popularityOutcome;
    public int energyCost;
    public string outcomeMessage;

    public enum Building
    {
            Harbor,
            CityHall,
            Lab,
            Hotel,
            QuestBoard,
            TestSite1,
            TestSite2
    }

    public Building placeOfQuest;

    public abstract void Update();
    public abstract void StartTask();

    public abstract void CompleteTask();
    public abstract void Reset();
}

