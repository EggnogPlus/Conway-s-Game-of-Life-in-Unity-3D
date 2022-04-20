using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    Collider[] inZoneColliders;
    int numinColliders = 0;
    List<Transform> LiveCells = new List<Transform>();
    List<Transform> DeadCells = new List<Transform>();

    int[,] numOfNeighbours;

    GameObject gridCreator;


    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] private int depth;



    private float gridSpacing = 5f;

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
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject blockHolder = Instantiate(blockPrefab, new Vector3(x * 5, (y + 1) * 5, depth), Quaternion.identity);

                blockHolder.transform.SetParent(transform);
                blockHolder.name = $"{x} - {y}";

                blockGrid[x, y] = blockHolder;
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
        //bool decider = GetComponent<blockCollide>().isAlive;

        inZoneColliders = Physics.OverlapBox(transform.position, new Vector3(6.5f, 6.5f, 6.5f));

        foreach (Collider collider in inZoneColliders) //counts every collider intersecting with its own collider (including itself for some reason)
        {

            if (collider.transform.tag == "Living") //only colliders that are alive tick up the count
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
            numberColliderCheck();
            SetCellState();


        }
        numinColliders = 0;
    }

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

    private void SetCellState()
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


