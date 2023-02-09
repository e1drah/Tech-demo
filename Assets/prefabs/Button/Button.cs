using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        target.GetComponent<Door>().TriggerActive();
        //gameObject.transform.position
    }
    private void OnTriggerExit(Collider other)
    {
        target.GetComponent<Door>().TriggerUnactive();
    }
}
