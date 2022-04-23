using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    Collider[] inZoneColliders;
    
    List<Transform> LiveCells = new List<Transform>();
    List<Transform> DeadCells = new List<Transform>();

    int[,] numOfNeighbours;

    GameObject gridCreator;


    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] private int depth;



    //private float gridSpacing = 5f;

    [SerializeField] private GameObject blockPrefab;
    private GameObject[,] blockGrid;

    private void BrickBuild()
    {
        blockGrid = new GameObject[width, height];
        if(blockPrefab == null)
        {
            Debug.LogError("FUUUUUUUU-");
            return;
        }
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject blockHolder = Instantiate(blockPrefab, new Vector3(x * 5, (height - y) * 5, depth), Quaternion.identity);

                blockHolder.transform.SetParent(transform);
                blockHolder.name = $"{y} - {x}";

                blockGrid[y, x] = blockHolder;
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        BrickBuild();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            numberColliderCheck();
            //SetCellState();

        }
        //numinColliders = 0;
    }

    private void numberColliderCheck()
    {
        //GameObject g = GetComponent<blockCollide>.isAlive;


        int[,] ajacencyGrid = new int [height, width]; //array to hold the current state of the grid to then later go through and make all changes to

        //i know i keep getting my x and y's messed up, i do nested loops different each time aha, but yeah this does work and only ticks up when .isAlive is true,
        //so no more messing with tags and overlap cubes, just checking each cube's state
        //dx and dy stands for each cubes cordinates in the ajacency grid, since it's different for every cube
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                int numinColliders = 0;

                for (int dy = y-1; dy <= y+1; ++dy)
                {
                    for (int dx = x-1; dx <= x+1; ++dx)
                    {
                        
                        if (dy >= 0 && dx >= 0 && dy <= height-1 && dx <= width-1 && !(dy == y && dx == x))
                        {
                            //Debug.LogFormat("Child: {0}, {1}", dy, dx);
                            if (blockGrid[dy, dx].transform.GetComponent<blockCollide>().isAlive == true)
                            {
                                numinColliders++;
                            }

                        }
                    }
                }
                ajacencyGrid[y,x] = numinColliders;

                

            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Transform child = blockGrid[y, x].transform;

                //Debug.LogFormat("Child: {0}, with adjacency {1}", child.gameObject.name, ajacencyGrid[y,x]); //checking detection : ONLY TURN ON WHEN NEEDED : creates a message for each cube, theres a lot of cubes...

                if (child.tag == "Living")
                {
                    //numinColliders += 1;
                    if (ajacencyGrid[y,x] == 2 || ajacencyGrid[y,x] == 3) //survive rule
                    {
                        //living cell
                        //LiveCells.Add(transform);
                        //child.gameObject.tag = "Living";
                        child.GetComponent<blockCollide>().BroadcastMessage("updateLocalState", true); //broadcast message gets past issue with using ints and variables in other script,
                                                                                                       //acts as if it runs the on collide script that has no issues,
                                                                                                       //with a true or false to determind what rules are implemented (dead or alive)
                    }
                    else //dies due to overpopulation or isolation
                    {
                        //dead cell
                        //DeadCells.Add(transform);
                        //child.gameObject.tag = "Dead";
                        child.GetComponent<blockCollide>().BroadcastMessage("updateLocalState", false);

                    }

                }
                else
                {
                    if (ajacencyGrid[y,x] == 3) //birth rule
                    {
                        //living cell
                        //LiveCells.Add(transform);
                        //child.gameObject.tag = "Living";
                        child.GetComponent<blockCollide>().BroadcastMessage("updateLocalState", true);

                    }
                    else //stays dead
                    {
                        //dead cell
                        //DeadCells.Add(transform);
                        //child.gameObject.tag = "Dead";
                        child.GetComponent<blockCollide>().BroadcastMessage("updateLocalState", false);

                    }
                }
            }
        }
        //foreach (Transform child in transform)
        //{
        //print("Foreach loop: " + child);
        //inZoneColliders = Physics.OverlapBox(child.position, new Vector3(6.5f, 6.5f, 6.5f));


        /*
                foreach (Collider collider in inZoneColliders) //counts every collider intersecting with its own collider (including itself for some reason)
                {

                    if (collider.transform.tag == "Living") //only colliders that are alive tick up the count
                    {

                        ++numinColliders; //count used to represent num of surrounding alive cubes

                    }//end if
                     //return;
                }//end foreach
        */

        /*if (child.tag == "Living")
        {
            numinColliders -= 1;
        }*/

        //}


    }

    private void OnDrawGizmos() //draws the overlap box for easier representation in scene
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(6.5f, 6.5f, 6.5f));
    }

    private void SetCellState() //not using currently : has 2 arrays which adds cordinates of cubes to, uses cordinates and whats in each array to do gol
    {
        for (int i = 0; i < LiveCells.Count; i++)
        {
            LiveCells[i].transform.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
            LiveCells[i].transform.GetComponentInChildren<blockCollide>().isAlive = true;
            LiveCells[i].transform.gameObject.transform.Find("Overlap").tag = "Living";
            LiveCells[i].transform.tag = "Living";
        }
        for (int i = 0; i < DeadCells.Count; i++)
        {
            DeadCells[i].transform.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
            DeadCells[i].transform.GetComponentInChildren<blockCollide>().isAlive = false;
            DeadCells[i].transform.gameObject.transform.Find("Overlap").tag = "Living";
            DeadCells[i].transform.tag = "Dead";
        }

        LiveCells.Clear();
        DeadCells.Clear();
    }
}


