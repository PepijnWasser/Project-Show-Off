using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/SteeredMoveBetweenPoints")]
public class MoveBetweenPointsBehavior : FlockBehavior
{
    public float agentSmoothTime = 0.5f;
    Vector3 currentVelocity = Vector3.zero;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        moveBetweenPointsSupport flockSupport = flock.gameObject.GetComponent<moveBetweenPointsSupport>();
        Vector3 pointOffset = flockSupport.activepoint - agent.transform.position;
        flockSupport.changePoint(agent);


        pointOffset = Vector3.SmoothDamp(agent.transform.forward, pointOffset, ref currentVelocity, agentSmoothTime).normalized;
        return pointOffset;
    }
}
