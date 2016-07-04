using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	void Awake () {
		int scaling = 1;
		int TargetHeight = Screen.height;
		int PPA = 12;
		if (TargetHeight < 700){
			scaling = 1;
		}
		if (TargetHeight >= 700 && TargetHeight <= 900) {
			scaling = 2;
		}
		if (TargetHeight >= 900) {
			scaling = 3;
		}
		Camera.main.orthographicSize = TargetHeight/2/PPA/scaling;
	}

}
