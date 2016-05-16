using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {
    public GameObject[] points;
    public GameObject minion;
    void Start () {
        Instantiate(minion).GetComponent<Move>().points = points;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
