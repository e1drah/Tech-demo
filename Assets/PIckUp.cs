using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckUp : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 15.0f;



    [Header("Throw setting")]
    public int totalThrows;
    public float throwCoolDown;

    [Header(("throwing"))]
    public GameObject objectToThrow;
    public bool hasGun = false;
    public float shotForce;
    public float shotUpwardForce;


    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true; 
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if(heldObject == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
                {
                    if (hit.transform.gameObject.tag == "Ball")
                    {
                        hit.transform.gameObject.SetActive(false);
                        totalThrows++;
                    }
                    if (hit.transform.gameObject.tag == "Gun")
                    {
                        hasGun = true;
                        hit.transform.gameObject.SetActive(false);
                    }
                    if (hit.transform.gameObject.tag == "PickUp")
                    {
                        PickupObject(hit.transform.gameObject);
                    }
                    //if (hit.transform.gameObject.tag ==)
                }
            }
            else
            {
                DropObject();
            }
        }
        if (Input.GetMouseButtonDown(0) && heldObject == null && totalThrows > 0 && readyToThrow && hasGun)
        {
            ThrowObject();
        }
        if (heldObject != null)
        {
            MoveObject();
        }
    }
    private void ThrowObject()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, holdArea.position, gameObject.transform.rotation);
        
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = gameObject.transform.forward * shotForce + transform.up * shotUpwardForce;

        projectileRB.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetShot), throwCoolDown);

    }

    private void ResetShot()
    {
        readyToThrow = true;
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjectRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObject)
    {
        if (pickObject.GetComponent<Rigidbody>())
        {
            heldObjectRB = pickObject.GetComponent<Rigidbody>();
            heldObjectRB.useGravity = false;
            heldObjectRB.drag = 10;
            heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjectRB.transform.parent = holdArea;
            heldObject = pickObject;
        }
    }
    void DropObject()
    {
        heldObjectRB.useGravity = true;
        heldObjectRB.drag = 1;
        heldObjectRB.constraints = RigidbodyConstraints.None;

        heldObjectRB.transform.parent = null;
        heldObject = null;
    }
}
