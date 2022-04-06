using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{ 
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
        
    }
}
