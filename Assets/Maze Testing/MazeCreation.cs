using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCreation : MonoBehaviour
{
    [SerializeField]
    public MazeCell mazeCellPrefab;

    [SerializeField]
    private int mazeWidth;

    [SerializeField]
    private int mazeDepth;

    private MazeCell[,] mazeGrids;


    // Start is called before the first frame update
    void Start()
    {
        mazeGrids = new MazeCell[mazeWidth, mazeDepth];

        for (int x = 0; x < mazeWidth; x++)
        {
            for (int z = 0; z < mazeDepth; z++)
            {
                // this will create the maze depends on x and z.
                mazeGrids[x, z] = Instantiate(mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
