using UnityEngine;
using System.Collections;

public class SofaTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if(collider.bounds.Contains(other.bounds.min) && collider.bounds.Contains(other.bounds.max) && other.gameObject.GetComponent<Sofa>() != null) {
			Debug.Log("Sohva jeejee");
		}
	}
}
