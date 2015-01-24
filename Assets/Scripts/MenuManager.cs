using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public SuperManager superManager;

	public GameObject startCanvas;
	public GameObject levelSelectionCanvas;

	public GameObject menuButtonPrefab;
	
	public void InitMenu(GameState gameState) {
		if(gameState == GameState.Menu){
			startCanvas = GameObject.Find("/Menu/StartCanvas");
			levelSelectionCanvas = GameObject.Find("/Menu/LevelSelectionCanvas");
			if(levelSelectionCanvas){
				levelSelectionCanvas.SetActive(false);
			}

			CreateLevelSelectionMenu();
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
	}
}
