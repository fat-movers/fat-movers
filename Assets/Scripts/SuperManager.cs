using UnityEngine;
using System.Collections;

public class SuperManager : MonoBehaviour {

	public GameManager gameManager;
	public MenuManager menuManager;
	public SoundManager soundManager;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}
