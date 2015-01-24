using UnityEngine;
using System.Collections;

public class SuperManager : MonoBehaviour {

	public GameManager gameManager;
	public MenuManager menuManager;
	public SoundManager soundManager;

	private static SuperManager superManagerInstance;

	public static SuperManager instance{
		get{ 
			if(!superManagerInstance){
				GameObject go = Instantiate(Resources.Load("SuperManager")) as GameObject;
				superManagerInstance = go.GetComponent<SuperManager>();
			}

			return superManagerInstance;
		}
	}

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}
