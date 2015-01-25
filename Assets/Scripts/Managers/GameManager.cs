using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState{
	None,
	StartScreen,
	LevelSelection,
	Level,
	Credits
}

public class GameManager : MonoBehaviour {

	public GameState currentGameState;
	
	public SuperManager superManager;
	public List<LevelObject> levels;

	public bool currentLevelWon;

	// Private methods
	void Start(){
		OnLevelWasLoaded();
	}

	void Update(){
		if(Input.GetKey(KeyCode.W)){
			if(Input.GetKey(KeyCode.O)){
				if(Input.GetKey(KeyCode.N)){
					if(currentGameState == GameState.Level){
						LevelWon();
					}
				}
			}
		}
	}

	void OnLevelWasLoaded () {
		if(currentGameState == GameState.None){
			currentGameState = GameState.StartScreen;
		}

		currentLevelWon = false;
		superManager.menuManager.InitMenu(currentGameState);

		superManager.soundManager.musicAudioSource.Play();
	}

	// Public methods
	public void MoveToScene(string customParamsString){
		Application.LoadLevel(customParamsString);
	}

	public void RestartCurrentLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LevelWon(){
		if(currentLevelWon){
			return;
		}else{
			currentLevelWon = true;
		}

		superManager.soundManager.StopMusic();
		superManager.soundManager.PlaySound(Sound.WinFare);
		superManager.menuManager.ShowLevelWonMenu();
	}

	public void LoadNextLevel(){
		string nextLevel = GetNextSceneName ();
		if (nextLevel == "none") {
			SuperManager.instance.gameManager.currentGameState = GameState.Credits;
			superManager.menuManager.BackToMainMenuCredits();
		} else {
			MoveToScene(nextLevel);
		}
	}

	public string GetNextSceneName(){
		string nextSceneName = "none";

		string currentLevelName = Application.loadedLevelName;
		for(int i = 0; i < levels.Count-1; i++){
			if(levels[i].levelSceneName == currentLevelName){
				nextSceneName = levels[i+1].levelSceneName;
			}
		}

		return nextSceneName;
	}
}
