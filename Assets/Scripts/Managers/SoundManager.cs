using UnityEngine;
using System.Collections;

public enum Sound{
	ButtonClick,
	WinFare
}

public class SoundManager : MonoBehaviour {

	public GameObject soundPrefab;

	public AudioClip buttonClickAudioClip;
	public AudioClip winFareAudioClip;

	public void PlaySound(Sound newSound){

		GameObject soundObject = Instantiate(soundPrefab) as GameObject;
		soundObject.transform.SetParent(gameObject.transform);

		switch(newSound){
		case Sound.ButtonClick:
			soundObject.GetComponent<AudioSource>().clip = buttonClickAudioClip;
			break;

		case Sound.WinFare:
			soundObject.GetComponent<AudioSource>().clip = winFareAudioClip;
			break;
		}

		soundObject.GetComponent<AudioSource>().Play();
	}
}
