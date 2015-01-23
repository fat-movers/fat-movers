using UnityEngine;
using System.Collections;

public class SofaMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){
			rigidbody.AddRelativeForce(Vector3.left *1000);
			Vector3 currentDir = transform.TransformDirection(Vector3.left);
			Debug.DrawRay(transform.position, currentDir, Color.white, 1.0f);
		}else if(Input.GetKey(KeyCode.A)){
			
		}else if(Input.GetKey(KeyCode.D)){
			
		}
	}
}
