using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //all these variables are editable in the unity editor :P
    public float pickUpRange = 5;
    public float moveForce = 250;
    public float throwForce = 600;
    public Transform holdParent;

    private GameObject heldObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //e to pickup
        {
            if (heldObj == null) //if not holding object
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (heldObj != null)
        {
            MoveObject();
            
            if(Input.GetMouseButtonDown(1))
            {
                heldObj.GetComponent<Rigidbody>().AddForce(holdParent.transform.forward * throwForce);
                DropObject();
                //this adds a throw force in teh direction of the object holder game object, so always throws forward from the holding point (allegedly)
            }
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject() //i wrote this btw
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}