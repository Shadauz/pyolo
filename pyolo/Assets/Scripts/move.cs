using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    [HideInInspector]
    public GameObject[] points;
    private int currentPoint = 0;
    private float lastPointSwitchTime;
    public float speed = 1.0f;
    void Start () {
        lastPointSwitchTime = Time.time;
    }
	void Update () {
        Vector3 startPosition = points[currentPoint].transform.position;
        Vector3 endPosition = points[currentPoint + 1].transform.position;
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastPointSwitchTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentPoint < points.Length - 2)
            {
                currentPoint++;
                lastPointSwitchTime = Time.time;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
