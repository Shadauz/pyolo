using UnityEngine;
using System.Collections;
public class Node : MonoBehaviour
{

    public bool walkable;
    public Vector3 worldPosition;
    public float diameter;
    void Start(bool _walkable, Vector3 _worldPosition)
    {
        walkable = _walkable;
        worldPosition = _worldPosition;
        GetComponent<Renderer>().material.color = Color.white;
    }
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
