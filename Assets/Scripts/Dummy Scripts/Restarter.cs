using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour {

	public void ReStart () {
		FindObjectOfType<SuperManager> ().gameManager.currentGameState = GameState.StartScreen;
		FindObjectOfType<SuperManager> ().gameManager.MoveToScene ("mainmenu");
	}
}
