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
        if (Input.GetKeyDown(KeyCode.E) && MyPauseMenu.GameIsPaused == false && customizeButton.GameIsCustomizing == false) //e to pickup and game is not paused or customizing button is pressed
        {
            if (heldObj == null) //if not holding object
            {
                //this physics raycast hit is something i learned from a tutorial, but using that knowledge i used raycast to create my button click scripts without a tutorial
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
            
            if(Input.GetMouseButtonDown(1)) //i wrote this if statement
            {
                heldObj.GetComponent<Rigidbody>().AddForce(holdParent.transform.forward * throwForce);
                DropObject();
                //this adds a throw force in the direction of the object holder game object, so always throws forward from the holding point (allegedly)
            }
        }
    }

    void MoveObject() //from tutorial
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj) //from tutorial
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