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
        if (triggersNeeded <= triggersActive)
        {

        }
        else
        {
            if (gameObject.transform.position.y > (pointA.transform.position.y))
            {
                gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
}
