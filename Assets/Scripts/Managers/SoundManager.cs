using UnityEngine;
using System.Collections;

public enum Sound{
	ButtonClick
}

public class SoundManager : MonoBehaviour {

	public GameObject soundPrefab;

	public AudioClip buttonClickAudioClip;

	public void PlaySound(Sound newSound){

		GameObject soundObject = Instantiate(soundPrefab) as GameObject;
		soundObject.transform.SetParent(gameObject.transform);

		switch(newSound){
		case Sound.ButtonClick:
			soundObject.GetComponent<AudioSource>().clip = buttonClickAudioClip;
			soundObject.GetComponent<AudioSource>().Play();
			break;
		}
	}
}
