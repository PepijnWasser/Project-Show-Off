using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CoralState : MonoBehaviour
{
    public Text healthText;
    public Image healthImage;
    public Material coral1Material;
    public Material coral2Material;
    public Material coral3Material;
    public Material coral4Material;
    public float numberDead;
    public float numberOnTheBrink;
    public float numberFairlyDamaged;
    public float numberFairlyHealthy;
    public float numberThriving;

    public enum CoralStates
    {
        Dead,
        OnTheBrink,
        FairlyDamaged,
        FairlyHealthy,
        Thriving
    };

    [Header("Designer-tool: Set Coral States")]
    public CoralStates coral0;
    public CoralStates coral1;
    public CoralStates coral2;
    public CoralStates coral3;
    public CoralStates coral4;
    public CoralStates coral5;
    public CoralStates coral6;
    public CoralStates coral7;
    public CoralStates coral8;
    public CoralStates coral9;
    public CoralStates coral10;

    private Dictionary<int, CoralStates> coralHealthLevels = new Dictionary<int, CoralStates>();

    private void Start()
    {
        coralHealthLevels.Add(0, coral0);
        coralHealthLevels.Add(1, coral1);
        coralHealthLevels.Add(2, coral2);
        coralHealthLevels.Add(3, coral3);
        coralHealthLevels.Add(4, coral4);
        coralHealthLevels.Add(5, coral5);
        coralHealthLevels.Add(6, coral6);
        coralHealthLevels.Add(7, coral7);
        coralHealthLevels.Add(8, coral8);
        coralHealthLevels.Add(9, coral9);
        coralHealthLevels.Add(10, coral10);
    }

    private void Update()
    {
        float healthScore = Int32.Parse(healthText.text);
        UpdateColor(healthScore);
    }

    private void UpdateColor(float healthScore)
    {
        foreach (var healthLevel in coralHealthLevels)
        {
            if (healthScore == healthLevel.Key)
            {
                if (healthLevel.Value == CoralStates.Dead)
                {
                    SetState(numberDead);
                }
                else if (healthLevel.Value == CoralStates.OnTheBrink)
                {
                    SetState(numberOnTheBrink);
                }
                else if (healthLevel.Value == CoralStates.FairlyDamaged)
                {
                    SetState(numberFairlyDamaged);
                }
                else if (healthLevel.Value == CoralStates.FairlyHealthy)
                {
                    SetState(numberFairlyHealthy);
                }
                if (healthLevel.Value == CoralStates.Thriving)
                {
                    SetState(numberThriving);
                }
            }
        }

    }

    private void SetState(float stateNum)
    {
        coral1Material.SetFloat("CoralHealth", stateNum);
        coral2Material.SetFloat("CoralHealth", stateNum);
        coral3Material.SetFloat("CoralHealth", stateNum);
        coral4Material.SetFloat("CoralHealth", stateNum);
    }
}
