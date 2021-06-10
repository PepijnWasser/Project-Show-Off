using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(1, 50)]
    public int startingCount = 25;
    const float agentDensity = 1.5f;

    [Range(1f, 100f)]
    public float speedMultiplier = 10f;

    [Range(1f, 100f)]
    public float neighbourRadius = 5f;

    float squareNeighbourRadius;


    void Start()
    {
        squareNeighbourRadius = neighbourRadius * neighbourRadius;

        for(int i = 0; i < startingCount; i++)
        {
            Vector2 startPos = Random.insideUnitCircle * startingCount * agentDensity;
            FlockAgent newAgent = Instantiate(
                agentPrefab, 
                new Vector3(startPos.x + this.transform.position.x, this.transform.position.y, startPos.y + this.transform.position.z),
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
            move *= speedMultiplier;
            float length = move.magnitude;
            move.y = 0;
            if(move.magnitude != length)
            {
                move = move.normalized * length;
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
