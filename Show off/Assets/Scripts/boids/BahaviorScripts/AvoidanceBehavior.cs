using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior :  FilteredFlockBehavior
{
    public float avoidanceRadius;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbour, return no adjustment
        if (context.Count == 0)
        {
            return Vector3.zero;
        }
        //get average points
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < avoidanceRadius * avoidanceRadius)
            {
                nAvoid += 1;
                avoidanceMove += agent.transform.position - item.position;
            }
        }
        if(nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
        }
        return avoidanceMove;
    }
}
