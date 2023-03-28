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
    public GameObject eye;

    public float detectionRange;
    public float outDetectionRange;
    public float attackRange = 1.5f;

    private Vector3 playerLastPostion;
    private Vector3 nextPoint;
    private enum STATE
    {
        PATROL,
        FOLLOW,
        SEARCH,
        RETREAT,
        ATTACK
    }
    //private int STATE_PATROLLING = 1;
    //private int STATE_FOLLOWING = 2;
    //private int STATE_SEARCH = 3
    //private int STATE_RETREET = 4;

    private STATE state;
    private NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = point1.position;
        nextPoint = point1.position;
        state = (int)STATE.PATROL;
    }
    private void Update()
    {
        if (RangeChecker(detectionRange))
        {
            state = STATE.FOLLOW;
        }
        if ( OutRangeChecker(outDetectionRange) && (state == STATE.FOLLOW))
        {
            state = STATE.SEARCH;
        }
        if (((playerLastPostion.x == gameObject.transform.position.x) && (playerLastPostion.z == gameObject.transform.position.z)) && (state == STATE.SEARCH))
        {
            state = STATE.RETREAT;
        }
        if ((state == STATE.RETREAT) && (gameObject.transform.position == point1.position))
        {
            state = STATE.PATROL;
        }
        if (RangeChecker(attackRange))
        {
            state = STATE.ATTACK;
        }
        StateUpdate();
    }
    public void StateUpdate()
    {
        if (state == STATE.PATROL)
        {
            Patrol();
        }
        if (state == STATE.FOLLOW)
        {
            Follow();
        }
        if (state == STATE.SEARCH)
        {
            Search();
        }
        if (state == STATE.RETREAT)
        {
            Retreat();
        }
        if (state == STATE.ATTACK)
        {
            Attack();
        }
    }
    void Patrol()
        {
            if (gameObject.transform.position == point1.position)
            {
                Debug.Log("point 1 reached");
                agent.destination = point2.position;
                nextPoint = point2.position;
            }
            if (gameObject.transform.position == point2.position)
            {
                Debug.Log("point 2 reached");
                agent.destination = point3.position;
                nextPoint = point2.position;
            }
            if (gameObject.transform.position == point3.position)
            {
                Debug.Log("point 3 reached");
                agent.destination = point4.position;
                nextPoint = point4.position;
            }
            if (gameObject.transform.position == point4.position)
            {
                Debug.Log("point 4 reached");
                agent.destination = point1.position;
                nextPoint = point1.position;
            }
        }
    void Follow()
    {
        agent.destination = player.transform.position;
        playerLastPostion = player.transform.position;
        eye.GetComponent<Renderer>().material.color = Color.red;
        gameObject.GetComponentInChildren<Light>().color = Color.red;

        if (RangeChecker(detectionRange))
        {
            state = STATE.FOLLOW;
        }
    }
    void Search()
    {
        agent.destination = playerLastPostion;
        eye.GetComponent<Renderer>().material.color = Color.yellow;
        gameObject.GetComponentInChildren<Light>().color = Color.yellow;
    }
}
    void Retreat()
    {
        agent.destination = playerLastPostion;
        eye.GetComponent<Renderer>().material.color = Color.yellow;
        gameObject.GetComponentInChildren<Light>().color = Color.yellow;
    }

    void Attack()
    {
        eye.GetComponent<Renderer>().material.color = Color.magenta;
        agent.destination = gameObject.transform.position;
        gameObject.GetComponentInChildren<Light>().color = Color.magenta;
    }
    public bool RangeChecker(float range)
    {
        if((player.transform.position.x - gameObject.transform.position.x <= range) && (player.transform.position.z - gameObject.transform.position.z <= range) && ((player.transform.position.x - gameObject.transform.position.x >= -range) && (player.transform.position.z - gameObject.transform.position.z >= -detectionRange)))
        {
            return true;
        }
        return false;
    }
    public bool OutRangeChecker(float range)
    {
        if (((player.transform.position.x - gameObject.transform.position.x > range) || (player.transform.position.z - gameObject.transform.position.z > range)) || ((player.transform.position.x - gameObject.transform.position.x < -range) || (player.transform.position.z - gameObject.transform.position.z < -range)))
        {
            return true;
        }
        return false;
    }
}
