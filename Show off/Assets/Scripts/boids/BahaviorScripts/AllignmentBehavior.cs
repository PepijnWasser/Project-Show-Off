using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Allignment")]
public class AllignmentBehavior : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbour, return no allignment
        if (context.Count == 0)
        {
            return agent.transform.forward;
        }

        //get average points
        Vector3 allignmentMove = Vector3.zero;
        foreach (Transform item in context)
        {
            allignmentMove += item.transform.forward;
        }
        allignmentMove /= context.Count;

        return allignmentMove;
    }
}