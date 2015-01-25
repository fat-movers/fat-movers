using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchControlsButton : MonoBehaviour {

	public bool isDown;

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	void OnClick(){
		//Debug.Log ("moi");
	}

	public void ButtonDown(){
		isDown = true;
	}

	public void ButtonUp(){
		isDown = false;
	}
}
