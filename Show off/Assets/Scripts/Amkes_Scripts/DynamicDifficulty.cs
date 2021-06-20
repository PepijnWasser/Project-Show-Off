using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DynamicDifficulty : MonoBehaviour
{
    [SerializeField] private TaskManager taskManagerScript;
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private CoralState coralStateScript;

    private void Update()
    {
        //Change difficulty according to player's score on day 3 and 6
        if (timeScript.dayNumber == 3 || timeScript.dayNumber == 6)
        {
            float healthScore = Int32.Parse(coralStateScript.healthText.text);

            //Coralhealth <=6           --> 3 good, 1 bad
            if (healthScore <= 6)
            {
                taskManagerScript.minMaxPositiveCoralTask = new Vector2(3, 3);
            }

            //Coralhealth >6 && <9      --> nothing changes
            if (healthScore > 6 && healthScore < 9)
            {
                taskManagerScript.minMaxPositiveCoralTask = new Vector2(1, 2);
            }

            //Coralhealth >= 9          --> 1 good, 3 bad
            if (healthScore >= 9)
            {
                taskManagerScript.minMaxPositiveCoralTask = new Vector2(1, 1);
            }
        }
    }
}
