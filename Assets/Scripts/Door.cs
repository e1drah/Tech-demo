using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;

    public float speed;

    public int triggersNeeded;

    public bool isRidable;

    private int triggersActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tSpeed = speed * Time.deltaTime;
        if (triggersNeeded <= triggersActive)
        {
            if ((gameObject.transform.position.x != pointB.transform.position.x)||
                (gameObject.transform.position.y != pointB.transform.position.y)||
                (gameObject.transform.position.z != pointB.transform.position.z))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pointB.transform.position, tSpeed);
            }
        }
        else
        {
            if ((gameObject.transform.position.x != pointA.transform.position.x) ||
                (gameObject.transform.position.y != pointA.transform.position.y) ||
                (gameObject.transform.position.z != pointA.transform.position.z))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pointA.transform.position, tSpeed);
            }
        }
    }
    public void TriggerActive()
    {
        triggersActive++;
    }
    public void TriggerUnactive()
    {
        triggersActive--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isRidable)
        {
            other.transform.parent = this.gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isRidable)
        {
            other.transform.parent = null;
        }
    }
}
