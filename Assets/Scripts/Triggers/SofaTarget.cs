using UnityEngine;
using System.Collections;

public class SofaTarget : MonoBehaviour {

	public GameObject gameEnderObject;
	private bool won = false;

	void OnTriggerStay(Collider other) {
		if(collider.bounds.Contains(other.bounds.min) &&
		   collider.bounds.Contains(other.bounds.max) &&
		   other.gameObject.GetComponent<Sofa>() != null &&
		   Mathf.Abs(other.gameObject.transform.rotation.y - transform.rotation.y) < 0.10f) {
			//Debug.Log(other.gameObject.transform.rotation.y + " " + transform.rotation.y);
			//Debug.Log("Sohva jeejee");
			Win();
		}


	}

	void Win() {
		if (won) return;
		won = true;
		Time.timeScale = 0;
		Instantiate (gameEnderObject);
		Debug.Log ("You win!");
	}
}
