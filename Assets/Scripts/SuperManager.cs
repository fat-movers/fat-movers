using UnityEngine;
using System.Collections;

public class SuperManager : MonoBehaviour {

	public GameManager gameManager;
	public MenuManager menuManager;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	void Start () {
		
	}
}
