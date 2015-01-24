using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState{
	None,
	Menu,
	Level
}

public class GameManager : MonoBehaviour {

	public GameState currentGameState;
	
	public SuperManager superManager;
	public List<LevelObject> levels;

	// Private methods
	void Start () {
		if(currentGameState == GameState.None){
			currentGameState = GameState.Menu;
		}

		superManager.menuManager.InitMenu(currentGameState);
	}

	// Public methods
	public void MoveToScene(string customParamsString){
		Application.LoadLevel(customParamsString);
	}
}
