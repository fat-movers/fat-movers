using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState{
	None,
	StartScreen,
	LevelSelection,
	Level,
}

public class GameManager : MonoBehaviour {

	public GameState currentGameState;
	
	public SuperManager superManager;
	public List<LevelObject> levels;

	// Private methods
	void Start(){
		OnLevelWasLoaded();
	}

	void OnLevelWasLoaded () {
		if(currentGameState == GameState.None){
			currentGameState = GameState.StartScreen;
		}

		superManager.menuManager.InitMenu(currentGameState);
	}

	// Public methods
	public void MoveToScene(string customParamsString){
		Application.LoadLevel(customParamsString);
	}

	public void RestartCurrentLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
