using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject checkPoint;
    public Vector3 respawnPoint;
    // Start is called before the first frame update

    void Start()
    {
        respawnPoint.x = gameObject.transform.position.x;
        respawnPoint.y = gameObject.transform.position.y;
        respawnPoint.z = gameObject.transform.position.z;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            respawnPoint.x = other.transform.position.x;
            respawnPoint.y = other.transform.position.y;
            respawnPoint.z = other.transform.position.z;

            other.gameObject.SetActive(false);
            //checkPoint = other.gameObject;
        }
        if(other.gameObject.CompareTag("Respawn"))
        {

            gameObject.transform.position = respawnPoint;
            //FirstPersonController.enabled = false;
            //gameObject.transform.position = checkPoint.gameObject.transform.position;
            //FirstPersonController.enabled = true;
        }
        if(other.gameObject.CompareTag("TelleportStart"))
        {
            gameObject.transform.position = other.gameObject.GetComponent<teleport>().telleportEnd.transform.position;
            //GetComponent<PIckUp>().totalThrows = 5;
        }
    }
}
