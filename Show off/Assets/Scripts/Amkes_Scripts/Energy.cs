using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public int energyAmount { get; private set; }

    [SerializeField] private Sprite fullEnergy;
    [SerializeField] private Sprite emptyEnergy;
    [SerializeField] private Image energyImage;
    [SerializeField] private Text energyText;
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private TaskManager taskManagerScript;
    [SerializeField] private ParticleSystem minusEnergy;
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

    private void RemoveEnergy(Task task)
    {
        energyAmount -= task.energyCost;
        minusEnergy.Play();
    }

    private void UpdateHUD(Task task)
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

    private void UpdateHUD()
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

    private void CheckNewDay(Task task)
    {
        if(energyAmount <= 0)
        {
            RefillEnergy();
            onDayCompleted?.Invoke();
        }
    }
    private void RefillEnergy()
    {
        energyAmount = maxEnergyAmount;
        UpdateHUD();
    }
}
