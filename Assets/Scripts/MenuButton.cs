using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

	public string actionString;
	public SuperManager superManager;
	public Text textObject;

	public string customParamsString;

	void Start(){
		superManager = FindObjectOfType(typeof(SuperManager)) as SuperManager;
		if(!superManager){
			Debug.Log ("SuperManager is missing from "+name);
		}

		gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
	}

	void OnClick(){

		superManager.soundManager.PlaySound(Sound.ButtonClick);

		switch(actionString){

		case "menustart":
			superManager.menuManager.MoveToLevelSelection();
			break;

		case "startlevel":
			superManager.menuManager.StartLevel(customParamsString);
			break;

		case "levelselectionback":
			superManager.menuManager.LevelSelectionBack();
			break;

		case "backtomainmenu":
			superManager.gameManager.currentGameState = GameState.LevelSelection;
			superManager.menuManager.BackToMainMenu();
			break;
		
		case "showcredits":
			superManager.menuManager.ShowCredits();
			break;

		case "creditsback":
			superManager.menuManager.CreditsBack();
			break;

		case "nextlevel":
			superManager.gameManager.LoadNextLevel();
			break;
		}
	}

	public void UpdateButton(string newText, string newActionString, string newCustomParamsString){
		textObject.text = newText;
		actionString = newActionString;
		customParamsString = newCustomParamsString;
	}

	public void SetPosition(Vector3 newPosition){
		gameObject.GetComponent<RectTransform>().anchoredPosition3D = newPosition;
	}

	public Vector2 GetSize(){
		return gameObject.GetComponent<RectTransform>().rect.size;
	}
}
