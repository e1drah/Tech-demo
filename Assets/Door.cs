using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;

    public float speed;

    public int triggersNeeded;

    private int triggersActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float tSpeed = speed * Time.deltaTime;
        if (triggersNeeded <= triggersActive)
        {
            if (gameObject.transform.position.y < (pointB.transform.position.y))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pointB.transform.position, speed);
            }
        }
        else
        {
            if (gameObject.transform.position.y > (pointA.transform.position.y))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pointA.transform.position, speed);
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
}
