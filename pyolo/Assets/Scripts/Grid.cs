using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
    public static GameObject[,] grid;
    public GameObject nodeprefab;
    public GameObject dGrid;
    public Vector2 gridWorldSize;
    int gridSizeX, gridSizeY, selectedY, selectedX, currentY, currentX;
    public int selectSize;
    List<GameObject> selected;
    void Start()
    {
        gridSizeX = 107;
        gridSizeY = 60;
        selectedY = 0;
        selectedX = 0;
        CreateGrid();
        selected = new List<GameObject>();
        selected =getAround(grid[selectedX, selectedY], selectSize);
    }

    private void CreateGrid()
    {
        grid = new GameObject[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * x * 0.375f + Vector3.up * y * 0.375f;
                grid[x, y] = Instantiate(nodeprefab, worldPoint, Quaternion.identity) as GameObject;
                grid[x, y].transform.parent = dGrid.transform;
                grid[x, y].GetComponent<Node>().x = x;
                grid[x, y].GetComponent<Node>().y = y;
            }
        }
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0&& selectSize!=1) selectSize--;
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) selectSize++;
        currentX = Mathf.RoundToInt(Input.mousePosition.x / 18);
        currentY = Mathf.RoundToInt(Input.mousePosition.y / 18);
        if (currentX != selectedX || currentY != selectedY || Input.GetAxis("Mouse ScrollWheel") != 0) {
            foreach (var n in selected){ n.GetComponent<Node>().setProperty(-2); }
            selectedX = currentX;
            selectedY = currentY;
            selected = getAround(grid[selectedX, selectedY], selectSize);
            
            foreach (var n in selected) {
                if (Input.GetMouseButton(0)) n.GetComponent<Node>().setProperty(0);
                else if (Input.GetMouseButton(1)) n.GetComponent<Node>().setProperty(1);
                else n.GetComponent<Node>().setProperty(-1); }
        }
    }


    public List<GameObject> getAround(GameObject center, int size)
    {
        List<GameObject> around = new List<GameObject>();
        if (size == 1) {
            around.Add(center);
            return around;
        }
        for (int x = -size / 2; x < size - (size / 2); x++)
        {
            for (int y = -size / 2; y < size - (size / 2); y++)
            {
                if (center.GetComponent<Node>().x + x<gridSizeX&&
                    center.GetComponent<Node>().x + x > -1 &&
                    center.GetComponent<Node>().y + y < gridSizeY &&
                    center.GetComponent<Node>().y + y > -1
                    ) { GameObject current = grid[center.GetComponent<Node>().x + x, center.GetComponent<Node>().y + y];
                    around.Add(current); }
            }
        }
        return around;
    }
}
