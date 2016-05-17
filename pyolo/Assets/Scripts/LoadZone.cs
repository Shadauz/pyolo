using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadZone : MonoBehaviour {
    public static int test;
    void Start() {
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
    void OnMouseUp()
    {
        switch (this.name) {
            case "Zone1":
                SceneManager.LoadScene("Zone1");
                break;
        }
    }
}
