using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CoralState : MonoBehaviour
{
    public Text healthText;

    [SerializeField] private Material coral1Material;
    [SerializeField] private Material coral2Material;
    [SerializeField] private Material coral3Material;
    [SerializeField] private Material coral4Material;
    [SerializeField] private float numberDead;
    [SerializeField] private float numberOnTheBrink;
    [SerializeField] private float numberFairlyDamaged;
    [SerializeField] private float numberFairlyHealthy;
    [SerializeField] private float numberThriving;

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
        UpdateState(healthScore);
    }

    private void UpdateState(float healthScore)
    {
        //Check coral health-score with the set states and update material accordingly
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
