using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CoralState : MonoBehaviour
{
    public Text healthText;
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
    public CoralStates[] coralLevels;

    private void Update()
    {
        float healthScore = Int32.Parse(healthText.text);
        UpdateColor(healthScore);
    }

    private void UpdateColor(float healthScore)
    {
        for (int i = 0; i < coralLevels.Length; i++)
        {
            if (healthScore == (int)coralLevels[i])
            {
                if (coralLevels[i] == CoralStates.Dead)
                {
                    SetState(numberDead);
                }
                else if (coralLevels[i] == CoralStates.OnTheBrink)
                {
                    SetState(numberOnTheBrink);
                }
                else if (coralLevels[i] == CoralStates.FairlyDamaged)
                {
                    SetState(numberFairlyDamaged);
                }
                else if (coralLevels[i] == CoralStates.FairlyHealthy)
                {
                    SetState(numberFairlyHealthy);
                }
                if (coralLevels[i] == CoralStates.Thriving)
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
