using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour
{
    // MoveTo.cs
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform player;

    private int STATE_PATROLLING = 1;
    private int STATE_FOLLOWING = 2;
    private int STATE_RETREET = 3;

    private int state;
        private NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = point1.position;
        state = STATE_PATROLLING;
    }
    private void Update()
    {
        if (state == STATE_PATROLLING)
        {
            Patrol();
        }
        if (state == STATE_FOLLOWING)
        {
            agent.destination = player.position;
        }
    }
    public void Patrol()
    {
        if (gameObject.transform.position == point1.position)
        {
            Debug.Log("point 1 reached");
            agent.destination = point2.position;
        }
        if (gameObject.transform.position == point2.position)
        {
            Debug.Log("point 2 reached");
            agent.destination = point3.position;
        }
        if (gameObject.transform.position == point3.position)
        {
            Debug.Log("point 3 reached");
            agent.destination = point4.position;
        }
        if (gameObject.transform.position == point4.position)
        {
            Debug.Log("point 4 reached");
            agent.destination = point1.position;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        state = STATE_FOLLOWING;
    }
    public void OnTriggerExit(Collider other)
    {
        state = STATE_RETREET;
    }
}
