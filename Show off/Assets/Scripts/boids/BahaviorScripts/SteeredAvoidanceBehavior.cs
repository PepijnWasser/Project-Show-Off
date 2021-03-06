using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/SteeredAvoidance")]
public class SteeredAvoidanceBehavior : FilteredFlockBehavior
{
    Vector3 currentVelocity;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier;
    public float agentSmoothTime = 0.5f;



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
            float rAvoid = flock.neighbourRadius * avoidanceRadiusMultiplier;
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < rAvoid * rAvoid)
            {
                nAvoid += 1;
                avoidanceMove += agent.transform.position - item.position;

            }
        }
        if (nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
            avoidanceMove = Vector3.SmoothDamp(agent.transform.forward, avoidanceMove, ref currentVelocity, agentSmoothTime);
        }
        return avoidanceMove;
    }
}
