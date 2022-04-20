using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDetect : MonoBehaviour
{
    Collider[] inZoneColliders;
    int numinColliders = 0;
    List<Transform> LiveCells = new List<Transform>();
    List<Transform> DeadCells = new List<Transform>();

    int[,] numOfNeighbours;

    GameObject gridCreator;

    //public blockCollide boolBoi;

    //public bool decider = true;

    //equals if the cube is alive or not to decide which code to run

    //public bool colliderAlive = ;

    //int aliveInCollider = 1;
    public static void Start()
    {

        /*//for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                numOfNeighbours[x, y] = 0;
            }
        }*/
    }
    public void Update()
    {
        //bool decider = GetComponent<blockCollide>().isAlive;

        inZoneColliders = Physics.OverlapBox(transform.position, new Vector3(6.5f, 6.5f, 6.5f));

        foreach (Collider collider in inZoneColliders) //counts every collider intersecting with its own collider (including itself for some reason)
        {
            
            if(collider.transform.tag == "Living") //only colliders that are alive tick up the count
            {

                ++numinColliders; //count used to represent num of surrounding alive cubes

            }//end if
                    //return;
        }//end foreach
        /*
        int x = 0;
        int y = 0;
        if (x < witdh)
        {
          numOfNeighbours[x, y] = numInColliders;
          x++;
        }
        else
        {
          x = 0;
          y++;
         numOfNeighbours[x, y] = numInColliders
        }
        */
        /*
        int i = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                numOfNeighbours[x, y] = inZoneColliders[i];
            }
        }
        i = 0;
        */
        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //numberColliderCheck();
            //SetCellState();


        }
        numinColliders = 0;
    }

    //private void numberColliderCheck()
    //{
    //    //bool decider = GetComponent<blockCollide>().isAlive;
    //    //gameObject.GetComponentInChildren<Transform>().tag = "Living";

    //    if (transform.tag == "Living")
    //    {
    //        //code for when cube is alive

    //        if (numinColliders >= 5) //overpopulation +1 to account itself
    //        {
    //            GetComponentInParent<MeshRenderer>().material.color = Color.white;
    //            GetComponent<blockCollide>().isAlive = false;
    //            gameObject.transform.Find("Overlap").tag = "Dead";
    //            //gameObject.transform.parent.tag = "Dead";
    //            //transform.parent.gameObject.tag = "Dead";
    //            //gameObject.transform.Find("Overlap").parent.tag = "Dead";
    //            transform.tag = "Dead";
    //        }

    //        if (numinColliders == 1) // isolation prt.1 +1 to account itself
    //        {
    //            GetComponentInParent<MeshRenderer>().material.color = Color.white;
    //            GetComponent<blockCollide>().isAlive = false; //SOME ISSUE WITH THIS LINE - object refrence not set to an instance of an object
    //            gameObject.transform.Find("Overlap").parent.tag = "Dead";
    //            //gameObject.transform.parent.tag = "Dead";
    //            //transform.parent.gameObject.tag = "Dead";
    //            //gameObject.transform.Find("Overlap").parent.tag = "Dead";
    //            transform.tag = "Dead";
    //        }

    //        if (numinColliders == 2) // isolation prt.2 +1 to account itself
    //        {
    //            GetComponentInParent<MeshRenderer>().material.color = Color.white;
    //            GetComponent<blockCollide>().isAlive = false; //SOME ISSUE WITH THIS LINE - object refrence not set to an instance of an object
    //            gameObject.transform.Find("Overlap").tag = "Dead";
    //            //gameObject.transform.parent.tag = "Dead";
    //            //transform.parent.gameObject.tag = "Dead";
    //            //gameObject.transform.Find("Overlap").parent.tag = "Dead";
    //            transform.tag = "Dead";
    //        }

    //        if (numinColliders == 3) // survives prt.1 +1 to account itself
    //        {
    //            GetComponentInParent<MeshRenderer>().material.color = Color.blue;
    //            GetComponent<blockCollide>().isAlive = true; //SOME ISSUE WITH THIS LINE - object refrence not set to an instance of an object 
    //            gameObject.transform.Find("Overlap").tag = "Living";
    //            //gameObject.transform.parent.tag = "Living";
    //            //transform.parent.gameObject.tag = "Living";

    //            //gameObject.transform.Find("Overlap").parent.tag = "Living";
    //            transform.tag = "Living";
    //        }

    //        if (numinColliders == 4) // survives prt.2 +1 to account itself
    //        {
    //            GetComponentInParent<MeshRenderer>().material.color = Color.blue;
    //            GetComponent<blockCollide>().isAlive = true; //SOME ISSUE WITH THIS LINE - object refrence not set to an instance of an object 
    //            gameObject.transform.Find("Overlap").tag = "Living";
    //            //gameObject.transform.parent.tag = "Living";
    //            //transform.parent.gameObject.tag = "Living";
    //            //gameObject.transform.Find("Overlap").parent.tag = "Living";
    //            transform.tag = "Living";
    //        }

    //    }

    //    if (transform.tag == "Dead")
    //    {
    //        //code for when cube is dead (only birth script)

    //        if (numinColliders == 3) // born   will it detect itself? it shouldn't because itself isn't alive? idk so i set it to 3 for now(without +1)
    //        {
    //            GetComponentInParent<MeshRenderer>().material.color = Color.blue;
    //            GetComponent<blockCollide>().isAlive = true;
    //            gameObject.transform.Find("Overlap").tag = "Living";
    //            //gameObject.transform.parent.tag = "Living";
    //            //transform.parent.gameObject.tag = "Living";
    //            //gameObject.transform.Find("Overlap").parent.tag = "Living";
    //            transform.tag = "Living";
    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }




    //    if (inZoneColliders == null)
    //    {
    //        Debug.LogError("error found with inZoneColliders");
    //    }

    //    //print(gameObject.transform.parent.tag); - shows what tags are being set


    //    //#################################################################################################
    //    /* //this is to check which ones light up and as a default back if the new code doesn't work
    //    if (numinColliders == 9) //
    //    {
    //        GetComponent<MeshRenderer>().material.color = Color.white;
    //        GetComponent<blockCollide>().isAlive = false;
    //    }
    //    if (numinColliders == 6) //
    //    {
    //        GetComponent<MeshRenderer>().material.color = Color.red;
    //        GetComponent<blockCollide>().isAlive = false;
    //    }
    //    if (numinColliders == 4) //
    //    {
    //        GetComponent<MeshRenderer>().material.color = Color.green;
    //        GetComponent<blockCollide>().isAlive = false;
    //    }
    //    */


    //    //############################################################################################
    //    /*
    //    if (numinColliders == 5) //currently this can go up to like 170 for some reason
    //    {
    //        GetComponent<MeshRenderer>().material.color = Color.black;
    //        //GetComponent<blockCollide>().isAlive = false;
    //    }
    //    if (numinColliders == 7) //currently this can go up to like 170 for some reason
    //    {
    //        GetComponent<MeshRenderer>().material.color = Color.yellow;
    //        //GetComponent<blockCollide>().isAlive = false;
    //    }
    //    */
    //}
    private void numberColliderCheck()
    {
        //GameObject g = GetComponent<blockCollide>.isAlive;


        if (transform.tag == "Living")
        {
            //numinColliders += 1;
            if (numinColliders == 3 || numinColliders == 4)
            {
                //living cell
                LiveCells.Add(transform);
            }
            else
            {
                //dead cell
                DeadCells.Add(transform);
            }

        }
        else
        {
            if (numinColliders == 4)
            {
                //living cell
                LiveCells.Add(transform);
            }
            else
            {
                //dead cell
                DeadCells.Add(transform);
            }
        }
        
    }

    private void OnDrawGizmos() //draws the overlap box for easier representation in scene
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(6.5f, 6.5f, 6.5f));
    }

    private void SetCellState()
    {
        for(int i = 0; i < LiveCells.Count; i++) {
            LiveCells[i].transform.GetComponentInParent<MeshRenderer>().material.color = Color.blue;
            LiveCells[i].transform.GetComponent<blockCollide>().isAlive = true;
            LiveCells[i].transform.gameObject.transform.Find("Overlap").tag = "Living";
            LiveCells[i].transform.tag = "Living";
        }
        for(int i = 0;i < DeadCells.Count; i++) {
            DeadCells[i].transform.GetComponentInParent<MeshRenderer>().material.color = Color.white;
            DeadCells[i].transform.GetComponent<blockCollide>().isAlive = false;
            DeadCells[i].transform.gameObject.transform.Find("Overlap").tag = "Dead";
            DeadCells[i].transform.tag = "Dead";
        }

        LiveCells.Clear();
        DeadCells.Clear();
    }
}//end numbercollidercheck





/*
List<Transform> LiveCells;
List<Transform> DeadCells;
private void numberColliderCheck()
   {
        if (transform.tag == "Living")
        {
            if (numinColliders >= 5) //overpopulation +1 to account itself
            {
                DeadCells.Add(transform);
            }

            if (numinColliders == 1) // isolation prt.1 +1 to account itself
            {
                DeadCells.Add(transform);
            }

            if (numinColliders == 2) // isolation prt.2 +1 to account itself
            {
                DeadCells.Add(transform);
            }

            if (numinColliders == 3) // survives prt.1 +1 to account itself
            {
                LiveCells.Add(transform);
            }

            if (numinColliders == 4) // survives prt.2 +1 to account itself
            {
                LiveCells.Add(transform);
            }

        }
        
        if (transform.tag == "Dead")
        {
            if (numinColliders == 3) // born   will it detect itself? it shouldn't because itself isn't alive? idk so i set it to 3 for now(without +1)
            {
                LiveCells.Add(transform);
            }
        }
        else
        {
            return;
        }
  }
        

private void SetCellState() {
    for(int i in LiveCells.Count; i++) {
        LiveCells[i].GetComponentInParent<MeshRenderer>().material.color = Color.blue;
        LiveCells[i].GetComponent<blockCollide>().isAlive = true;
        LiveCells[i].gameObject.transform.Find("Overlap").tag = "Living";
        LiveCells[i].tag = "Living";
    }
    for(int i in DeadCells.Count; i++) {
        DeadCells[i].GetComponentInParent<MeshRenderer>().material.color = Color.white;
        DeadCells[i].GetComponent<blockCollide>().isAlive = false;
        DeadCells[i].gameObject.transform.Find("Overlap").tag = "Dead";
        DeadCells[i].tag = "Dead"; 
    }
    LiveCells.Clear();
    DeadCells.Clear();
}
 
*/

/*
 * ######################################################################################################################
 * check to see how many sphere overlaps there are
 *  if (numinColliders >= 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            GetComponent<blockCollide>().isAlive = false;
        }
        if (numinColliders >= 2)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
            GetComponent<blockCollide>().isAlive = false;
        }
        if (numinColliders >= 3)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            GetComponent<blockCollide>().isAlive = false;
        }
        if (numinColliders >= 4)
        {
            GetComponent<MeshRenderer>().material.color = Color.black;
            GetComponent<blockCollide>().isAlive = false;
        }
        if (numinColliders >= 5)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            GetComponent<blockCollide>().isAlive = false;
        }
        if (numinColliders >= 6)
        {
            GetComponent<MeshRenderer>().material.color = Color.grey;
            GetComponent<blockCollide>().isAlive = false;
        }
        if (numinColliders >= 7)
        {
            GetComponent<MeshRenderer>().material.color = Color.magenta;
            GetComponent<blockCollide>().isAlive = false;
        }
        if (numinColliders >= 8)
        {
            GetComponent<MeshRenderer>().material.color = Color.cyan;
            GetComponent<blockCollide>().isAlive = false;
        }

*/