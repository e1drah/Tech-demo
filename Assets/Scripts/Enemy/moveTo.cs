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
    public GameObject player;

    private Vector3 playerLastPostion;
    private enum STATE
    {
        PATROL,
        FOLLOW,
        SEARCH,
        RETREAT
    }
    //private int STATE_PATROLLING = 1;
    //private int STATE_FOLLOWING = 2;
    //private int STATE_SEARCH = 3
    //private int STATE_RETREET = 4;

    private int state;
    private NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = point1.position;
        state = (int) STATE.PATROL;
    }
    private void Update()
    {
        if ((player.transform.position.x - gameObject.transform.position.x <= 10) && (player.transform.position.y - gameObject.transform.position.y <= 10))
        {
            state = (int) STATE.FOLLOW;
        }
        if ((player.transform.position.x - gameObject.transform.position.x >= 10) && (player.transform.position.y - gameObject.transform.position.y >= 10))
        {
            state = (int) STATE.SEARCH;
        }
        if ((gameObject.transform.postion == playerLastPostion) && (state == (int) STATE.SEARCH))
        {
            state = (int) STATE.RETREAT;
        }
        if ((state == (int) STATE.RETREAT) && (gameObject.transform.position == point1.position))
        {
            state = (int) STATE.PATROL;
        }
        StateUpdate();
    }
    public void StateUpdate()
    {
        if (state == (int) STATE.PATROL)
        {
            Patrol();
        }
        if (state == (int) STATE.FOLLOW)
        {
            agent.destination = player.transform.position;
            playerLastPostion = player.transform.position;
        }
        if (state == (int) STATE.SEARCH)
        {
            agent.destination = playerLastPostion;
        }
        if (state == (int) STATE.RETREAT)
        {
            agent.destination = point1.postion;
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

    //public void OnTriggerEnter(Collider other)
    //{
    //    state = STATE_FOLLOWING;
    //}
    //public void OnTriggerExit(Collider other)
    //{
    //    state = STATE_RETREET;
    //}
}
