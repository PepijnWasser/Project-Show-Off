using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(2, 50)]
    public int startingCount = 25;
    const float agentDensity = 1.5f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float speed = 5f;

    [Range(1f, 100f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    void Start()
    {
        squareMaxSpeed = speed * speed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++)
        {
            Vector2 startPos = Random.insideUnitCircle * startingCount * agentDensity;
            FlockAgent newAgent = Instantiate(
                agentPrefab, 
                new Vector3(startPos.x, 0, startPos.y) + this.transform.position,
                Quaternion.Euler(Vector3.up * Random.Range(0, 360)),
                this.transform
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    void Update()
    {
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.y > 0 || move.y < 0)
            {
                move.y = 0;
            }
            if (move.sqrMagnitude != squareMaxSpeed)
            {
                move = move.normalized * speed;
            }
            agent.Move(move);
        }   
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);
        foreach(Collider c in contextColliders)
        {
            if(c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        agent.nearbyObjects = context;
        return context;
    }
}
