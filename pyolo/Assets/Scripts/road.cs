using UnityEngine;
using System.Collections;

public class road : MonoBehaviour {
    public GameObject[] points;
    public GameObject minion;
    void Start () {
        Instantiate(minion).GetComponent<move>().points = points;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
