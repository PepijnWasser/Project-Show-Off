using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBetweenPointsSupport : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;
    [HideInInspector]
    public Vector3 activepoint;

    public int distanceToCompletion;

    public void changePoint(FlockAgent agent)
    {
        if(Vector3.Distance(agent.transform.position, activepoint) < distanceToCompletion)
        {
            if (activepoint == point1)
            {
                activepoint = point2;
            }
            else
            {
                activepoint = point1;
            }
        }
    }
}
