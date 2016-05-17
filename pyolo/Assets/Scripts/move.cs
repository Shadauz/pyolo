using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {
    void findPath(Vector3 start, Vector3 target)
    {
        GameObject startN = Grid.grid[Mathf.RoundToInt(start.x / 18), Mathf.RoundToInt(start.y / 18)];
        GameObject targetN = Grid.grid[Mathf.RoundToInt(target.x / 18), Mathf.RoundToInt(target.y / 18)];
        List<GameObject> openSet = new List<GameObject>();
        HashSet<GameObject> closetSet = new HashSet<GameObject>();
        openSet.Add(startN);
        while(openSet.Count > 0)
        {
            GameObject currentN = openSet[0];
            for(int i = 1; i < openSet.Count; i++)
            {
                if(openSet[i].GetComponent<Node>().fCost< currentN.GetComponent<Node>().fCost||
                    openSet[i].GetComponent<Node>().fCost == currentN.GetComponent<Node>().fCost&&
                    openSet[i].GetComponent<Node>().hCost < currentN.GetComponent<Node>().hCost)
                {
                    currentN = openSet[i];
                }
            }
            openSet.Remove(currentN);
            closetSet.Add(currentN);
            if (currentN == targetN)
            {
                return;
            }
        }
    }
}
