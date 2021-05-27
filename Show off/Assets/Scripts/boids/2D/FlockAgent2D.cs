using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent2D : MonoBehaviour
{
    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    private void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void move(Vector2 Velocity)
    {
        transform.up = Velocity;
        transform.position += (Vector3)Velocity * Time.deltaTime;
    }
}
