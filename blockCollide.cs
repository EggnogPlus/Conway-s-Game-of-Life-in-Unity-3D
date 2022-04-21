using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCollide : MonoBehaviour
{
    public bool isAlive = false;
    //public bool isAliveCollide = false;
    //public Color Color = Color.white;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("thrownBlock"))
        {
            if (isAlive == false)
            {
                GetComponent<MeshRenderer>().material.color = Color.blue;
                isAlive = true;
                //isAliveCollide = true;
                gameObject.transform.tag = "Living";
                gameObject.transform.Find("Overlap").tag = "Living";
                return;

            }

            if (isAlive != false)
            {
                GetComponent<MeshRenderer>().material.color = Color.white;
                isAlive = false;
                //isAliveCollide = false;
                gameObject.transform.tag = "Dead";
                gameObject.transform.Find("Overlap").tag = "Dead";
                //gameObject.GetComponentInChildren<Transform>().tag = "Dead";
                return;
            }
        }

    }

    public void updateLocalState(bool state)
    {
        if (state == true)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            isAlive = true;
            //isAliveCollide = true;
            gameObject.transform.tag = "Living";
            gameObject.transform.Find("Overlap").tag = "Living";
            return;

        }

        if (state != true)
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
            isAlive = false;
            //isAliveCollide = false;
            gameObject.transform.tag = "Dead";
            gameObject.transform.Find("Overlap").tag = "Dead";
            //gameObject.GetComponentInChildren<Transform>().tag = "Dead";
            return;
        }

    }


 //##########################################################################################

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
