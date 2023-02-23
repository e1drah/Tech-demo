using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    public bool activateAtStart = false;
    void Start()
    {
        if (activateAtStart)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<Rigidbody>();
            cube.transform.position = gameObject.transform.position;
            cube.tag = "PickUp";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active()
    {
        if (!activateAtStart)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<Rigidbody>();
            cube.transform.position = gameObject.transform.position;
            cube.tag = "PickUp";
            activateAtStart = true;
        }
        cube.transform.position = gameObject.transform.position;
    }
}
