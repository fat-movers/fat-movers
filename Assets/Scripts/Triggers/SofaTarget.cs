using UnityEngine;
using System.Collections;

public class SofaTarget : MonoBehaviour {

	public SuperManager superManager;
	public GameObject gameEnderObject;

	void Start(){
		superManager = FindObjectOfType(typeof(SuperManager)) as SuperManager;
	}

	void OnTriggerStay(Collider other) {

		if(collider.bounds.Contains(other.bounds.min) &&
		   collider.bounds.Contains(other.bounds.max) &&
		   other.gameObject.GetComponent<Sofa>() != null &&
		   Mathf.Abs(other.gameObject.transform.eulerAngles.y - transform.eulerAngles.y) < 10.0f) {
			//Debug.Log(other.gameObject.transform.rotation.y + " " + transform.rotation.y);
			//Debug.Log("Sohva jeejee");
			Win();
		}


	}

	void Win() {
		if(!superManager.gameManager.currentLevelWon){
			superManager.gameManager.LevelWon();
		}
	}
}
