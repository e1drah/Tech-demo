using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public GameObject cubeTube;

    public void Pressed()
    {
        cubeTube.GetComponent<CubeShoot>().Active();
    }
}
