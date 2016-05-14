using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{

    void Start()
    {
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
        switch (this.name)
        {
            case "Level1":
                SceneManager.LoadScene("Level1");
                break;
        }
    }
}
