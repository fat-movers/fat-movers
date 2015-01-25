using UnityEngine;
using System.Collections;

public class Sofa : MonoBehaviour {

	private SuperManager superManager;

	void Start () {
		superManager = FindObjectOfType(typeof(SuperManager)) as SuperManager;
	}

	void OnCollisionEnter(Collision c){
		superManager.soundManager.PlaySound(Sound.Bump);
	}
}
