using UnityEngine;
using System.Collections;

public class PoopoScript : MonoBehaviour {

	private SofaMover myMover;

	void Start () {
		myMover = GetComponent<SofaMover> ();
		StartCoroutine (PoopoiLe());
	}

	void OnCollisionStay(Collision c) {
		StopAllCoroutines ();
		myMover.otherPlayer.forceWalkingState = WalkingState.None;
		StartCoroutine (PoopoiLe());
	}

	IEnumerator PoopoiLe() {
		myMover.forceWalkingState = (WalkingState)Random.Range (0, (int)WalkingState.length);
		yield return new WaitForSeconds (Random.Range (0.3f, 1.5f));
		StartCoroutine (PoopoiLe());
	}
}
