using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDifficulty : MonoBehaviour
{
    public TaskManager taskManagerScript;
    public TimeScript timeScript;
    public CoralState coralStateScript;

    private void Update()
    {
        if(timeScript.dayNumber == 3 || timeScript.dayNumber == 6)
        {
            //Coralhealth <=6           --> 3 good, 1 bad

            //Coralhealth >6 && <9      --> nothing changes

            //Coralhealth >= 9          --> 1 good, 3 bad
        }
    }
}
