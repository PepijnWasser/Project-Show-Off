using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public Sprite fullEnergy;
    public Sprite emptyEnergy;

    public Image energyImage;
        
    public Text energyText;

    public int energyAmount;

    public TimeScript timeScript;
    public TaskManager taskManagerScript;

    private int maxEnergyAmount;

    public delegate void DayCompleted();
    public static event DayCompleted onDayCompleted;

    private void Awake()
    {
        TaskManager.onTaskCompleted += RemoveEnergy;
        TaskManager.onTaskCompleted += UpdateHUD;
        TaskManager.onTaskCompleted += CheckNewDay;
    }

    private void Start()
    {
        maxEnergyAmount = taskManagerScript.energy;
        energyAmount = maxEnergyAmount;
        energyText.text = energyAmount.ToString();
        energyImage.sprite = fullEnergy;
    }

    private void OnDestroy()
    {
        TaskManager.onTaskCompleted -= RemoveEnergy;
        TaskManager.onTaskCompleted -= UpdateHUD;
        TaskManager.onTaskCompleted -= CheckNewDay;
    }

    void RemoveEnergy(Task task)
    {
        energyAmount -= task.energyCost;
    }

    void UpdateHUD(Task task)
    {
        energyText.text = energyAmount.ToString();
        if (energyAmount > 0)
        {
            energyImage.sprite = fullEnergy;
        }
        else
        {
            energyImage.sprite = emptyEnergy;
        }
    }

    void UpdateHUD()
    {
        energyText.text = energyAmount.ToString();
        if (energyAmount > 0)
        {
            energyImage.sprite = fullEnergy;
        }
        else
        {
            energyImage.sprite = emptyEnergy;
        }
    }

    void CheckNewDay(Task task)
    {
        if(energyAmount <= 0)
        {
            RefillEnergy();
            onDayCompleted?.Invoke();
        }
    }
    void RefillEnergy()
    {
        energyAmount = maxEnergyAmount;
        UpdateHUD();
    }
}
