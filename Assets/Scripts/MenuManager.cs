using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public SuperManager superManager;

	public GameObject mainMenuPrefab;
	public GameObject gameMenuPrefab;

	public GameObject startCanvas;
	public GameObject levelSelectionCanvas;
	public GameObject gameMenuCanvas;

	public GameObject menuButtonPrefab;

	private GameObject currentMenu;
	
	public void InitMenu(GameState gameState) {

		if(currentMenu){
			Destroy(currentMenu);
		}

		switch(gameState){

		case GameState.StartScreen:{
			currentMenu = Instantiate(mainMenuPrefab) as GameObject;
			currentMenu.name = "Menu";
			startCanvas = GameObject.Find("/Menu/StartCanvas");
			startCanvas.SetActive(true);
			levelSelectionCanvas = GameObject.Find("/Menu/LevelSelectionCanvas");
			levelSelectionCanvas.SetActive(false);
			startCanvas.SetActive(true);
			CreateLevelSelectionMenu();
		}
			break;

		case GameState.LevelSelection:{
			currentMenu = Instantiate(mainMenuPrefab) as GameObject;
			currentMenu.name = "Menu";
			startCanvas = GameObject.Find("/Menu/StartCanvas");
			startCanvas.SetActive(false);
			levelSelectionCanvas = GameObject.Find("/Menu/LevelSelectionCanvas");
			levelSelectionCanvas.SetActive(true);
			CreateLevelSelectionMenu();
		}
			break;

		case GameState.Level:{
			currentMenu = Instantiate(gameMenuPrefab) as GameObject;
			currentMenu.name = "Menu";
			gameMenuCanvas = GameObject.Find("/Menu/GameMenu");
		}
			break;

		}
	}

	// Private methods
	void CreateLevelSelectionMenu(){
		for(int i = 0; i < superManager.gameManager.levels.Count; i++){
			GameObject newMenuButton = Instantiate(menuButtonPrefab) as GameObject;
			newMenuButton.transform.SetParent(levelSelectionCanvas.transform);

			MenuButton menuButton = newMenuButton.GetComponent<MenuButton>() as MenuButton;
			LevelObject levelObject = superManager.gameManager.levels[i];
			menuButton.UpdateButton(levelObject.levelName, "startlevel", levelObject.levelSceneName);
			menuButton.SetPosition(new Vector3(0,0-(i*menuButton.GetSize().y+5),0));
		}
	}

	// Public methods
	public void MoveToLevelSelection(){
		if(startCanvas && levelSelectionCanvas){
			startCanvas.SetActive(false);
			levelSelectionCanvas.SetActive(true);
		}
	}

	public void StartLevel(string customParamsString){
		superManager.gameManager.MoveToScene(customParamsString);
		superManager.gameManager.currentGameState = GameState.Level;
	}

	public void LevelSelectionBack(){
		if(startCanvas && levelSelectionCanvas){
			startCanvas.SetActive(true);
			levelSelectionCanvas.SetActive(false);
		}
	}

	public void BackToMainMenu(){
		superManager.gameManager.MoveToScene("mainmenu");
	}
}
