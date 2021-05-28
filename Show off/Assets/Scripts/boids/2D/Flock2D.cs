using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flock2D : MonoBehaviour
{
    public FlockAgent2D agentPrefab;
    List<FlockAgent2D> agents = new List<FlockAgent2D>();
    public FlockBehavior2D behavior;

    [Range(5, 20)]
    public int startingCount = 10;
    const float agentDensity = 0.5f;

    [Range(1f, 100f)]
    public float driveFactor = 1f;

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }


    private void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++)
        {
            FlockAgent2D newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * startingCount * agentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0, 360)),
                transform
                );
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }
    }

    private void Update()
    {
        foreach(FlockAgent2D agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            agent.GetComponentInChildren<Image>().color = Color.Lerp(Color.white, Color.red, context.Count / 6);

            /*
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if(move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.move(move);
            */
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent2D agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach(Collider2D c in contextColliders)
        {
            if(c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
