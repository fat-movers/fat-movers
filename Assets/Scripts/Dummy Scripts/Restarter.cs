using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour {
	
	public void ReStart () {
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1;
	}
}
