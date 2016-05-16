using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

public class Grid : MonoBehaviour {
    public GameObject[,] grid;
    public GameObject nodeprefab;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    float nodeDiameter;
    int gridSizeX, gridSizeY;
    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new GameObject[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                grid[x, y]=Instantiate(nodeprefab,worldPoint,Quaternion.identity) as GameObject;
            }
        }
    }
}
