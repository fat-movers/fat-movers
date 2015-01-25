using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public SuperManager superManager;

	public GameObject mainMenuPrefab;
	public GameObject gameMenuPrefab;

	public GameObject startCanvas;
	public GameObject creditsCanvas;
	public GameObject levelSelectionCanvas;
	public GameObject gameMenuCanvas;
	public GameObject levelWonCanvas;
	public GameObject touchControlsCanvas;
	public GameObject faderCanvas;


	public GameObject menuButtonPrefab;

	private GameObject currentMenu;
	private bool lastFaderEnabled = false; 
	
	public void InitMenu(GameState gameState) {

		if(currentMenu){
			Destroy(currentMenu);
		}

		switch(gameState){

		case GameState.StartScreen:{
			currentMenu = Instantiate(mainMenuPrefab) as GameObject;
			currentMenu.name = "Menu";
			startCanvas = GameObject.Find("/Menu/StartCanvas");
			startCanvas.GetComponent<Canvas>().enabled = true;
			levelSelectionCanvas = GameObject.Find("/Menu/LevelSelectionCanvas");
			levelSelectionCanvas.GetComponent<Canvas>().enabled = false;
			creditsCanvas = GameObject.Find("/Menu/CreditsCanvas");
			creditsCanvas.GetComponent<Canvas>().enabled = false;
			faderCanvas = GameObject.Find("/Menu/FaderCanvas");
			CreateLevelSelectionMenu();
		}
			break;

		case GameState.LevelSelection:{
			currentMenu = Instantiate(mainMenuPrefab) as GameObject;
			currentMenu.name = "Menu";
			startCanvas = GameObject.Find("/Menu/StartCanvas");
			startCanvas.GetComponent<Canvas>().enabled = false;
			levelSelectionCanvas = GameObject.Find("/Menu/LevelSelectionCanvas");
			levelSelectionCanvas.GetComponent<Canvas>().enabled = true;
			creditsCanvas = GameObject.Find("/Menu/CreditsCanvas");
			creditsCanvas.GetComponent<Canvas>().enabled = false;
			faderCanvas = GameObject.Find("/Menu/FaderCanvas");
			CreateLevelSelectionMenu();
		}
			break;
			
		case GameState.Level:{
			currentMenu = Instantiate(gameMenuPrefab) as GameObject;
			currentMenu.name = "Menu";
			gameMenuCanvas = GameObject.Find("/Menu/GameMenu");
			levelWonCanvas = GameObject.Find("/Menu/LevelWonCanvas");
			levelWonCanvas.GetComponent<Canvas>().enabled = false;
			faderCanvas = GameObject.Find("/Menu/FaderCanvas");
			faderCanvas.GetComponent<Canvas>().enabled = true;
			touchControlsCanvas = GameObject.Find("/Menu/TouchControlsCanvas");
			if(!superManager.gameManager.isIOSBuild){
				touchControlsCanvas.GetComponent<Canvas>().enabled = false;
			}
		}
			break;
		
		case GameState.Credits:{
			currentMenu = Instantiate(mainMenuPrefab) as GameObject;
			currentMenu.name = "Menu";
			levelSelectionCanvas = GameObject.Find("/Menu/LevelSelectionCanvas");
			startCanvas = GameObject.Find("/Menu/StartCanvas");
			startCanvas.GetComponent<Canvas>().enabled = false;
			creditsCanvas = GameObject.Find("/Menu/CreditsCanvas");
			creditsCanvas.GetComponent<Canvas>().enabled = true;
			faderCanvas = GameObject.Find("/Menu/FaderCanvas");
			CreateLevelSelectionMenu();
			levelSelectionCanvas = GameObject.Find("/Menu/LevelSelectionCanvas");
			levelSelectionCanvas.GetComponent<Canvas>().enabled = false;
		}
			break;
		
	}

		faderCanvas.GetComponent<Canvas>().enabled = lastFaderEnabled;
	}

	// Private methods
	void CreateLevelSelectionMenu(){
		for(int i = 0; i < superManager.gameManager.levels.Count; i++){
			GameObject newMenuButton = Instantiate(menuButtonPrefab) as GameObject;
			newMenuButton.transform.SetParent(levelSelectionCanvas.transform);

			MenuButton menuButton = newMenuButton.GetComponent<MenuButton>() as MenuButton;
			LevelObject levelObject = superManager.gameManager.levels[i];
			menuButton.UpdateButton(levelObject.levelName, "startlevel", levelObject.levelSceneName);

			if(i < 3){
				menuButton.SetPosition(new Vector3(-148+(i*menuButton.GetSize().x+(i*10)),-60,0));
			}else{
				menuButton.SetPosition(new Vector3(-105+((i-3)*menuButton.GetSize().x+(i*10)),-110,0));
			}

		}
	}

	// Public methods
	public void MoveToLevelSelection(){
		StartCoroutine (DoMoveToLevelSelection ());
	}
	IEnumerator DoMoveToLevelSelection() {
		if(startCanvas && levelSelectionCanvas){
			startCanvas.animation.Play("CanvasOut");
			yield return new WaitForSeconds(0.2f);
			levelSelectionCanvas.animation.Play("CanvasIn");
		}
	}

	public void StartLevel(string customParamsString){
		StartCoroutine ("DoStartLevel", customParamsString);
	}
	IEnumerator DoStartLevel(string customParamsString){
		levelSelectionCanvas.animation.Play("CanvasOut");
		faderCanvas.animation.Play ("FaderIn");
		lastFaderEnabled = true;
		yield return new WaitForSeconds(0.2f);
		superManager.gameManager.MoveToScene(customParamsString);
		superManager.gameManager.currentGameState = GameState.Level;
		yield return new WaitForSeconds(0.1f);
		faderCanvas.animation.Play ("FaderOut");
		lastFaderEnabled = false;
	}

	public void LevelSelectionBack(){
		StartCoroutine (DoLevelSelectionBack ());
	}
	IEnumerator DoLevelSelectionBack() {
		levelSelectionCanvas.animation.Play("CanvasOut");
		yield return new WaitForSeconds(0.2f);
		startCanvas.animation.Play("CanvasIn");
	}
	
	public void BackToMainMenu(){
		StartCoroutine(DoBackToMainMenu());
	}
	IEnumerator DoBackToMainMenu() {
		faderCanvas.animation.Play ("FaderIn");
		lastFaderEnabled = true;
		yield return new WaitForSeconds(0.2f);
		superManager.gameManager.MoveToScene("mainmenu");
		yield return new WaitForSeconds(0.1f);
		faderCanvas.animation.Play ("FaderOut");
		lastFaderEnabled = false;
		levelSelectionCanvas.animation.Play("CanvasIn");
	}
	
	public void BackToMainMenuCredits(){
		StartCoroutine(DoBackToMainMenuCredits());
	}
	IEnumerator DoBackToMainMenuCredits() {
		faderCanvas.animation.Play ("FaderIn");
		lastFaderEnabled = true;
		Time.timeScale = 1;
		yield return new WaitForSeconds(0.2f);
		superManager.gameManager.MoveToScene("mainmenu");
		yield return new WaitForSeconds(0.1f);
		faderCanvas.animation.Play ("FaderOut");
		lastFaderEnabled = false;
		creditsCanvas.animation.Play("CanvasIn");
	}

	public void ShowLevelWonMenu(){
		StartCoroutine(DoShowLevelWonMenu());
	}
	IEnumerator DoShowLevelWonMenu(){
		touchControlsCanvas.animation.Play("CanvasOut");
		yield return new WaitForSeconds(0.2f);
		levelWonCanvas.animation.Play("CanvasIn");
	}

	public void ShowCredits(){
		StartCoroutine(DoShowCredits());
	}

	IEnumerator DoShowCredits(){
		startCanvas.animation.Play("CanvasOut");
		yield return new WaitForSeconds(0.2f);
		creditsCanvas.animation.Play("CanvasIn");
	}

	public void CreditsBack(){
		StartCoroutine (DoCreditsBack ());
	}
	IEnumerator DoCreditsBack() {
		creditsCanvas.animation.Play("CanvasOut");
		yield return new WaitForSeconds(0.2f);
		startCanvas.animation.Play("CanvasIn");
	}
}
