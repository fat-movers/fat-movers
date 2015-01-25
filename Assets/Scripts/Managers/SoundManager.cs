using UnityEngine;
using System.Collections;

public enum Sound{
	ButtonClick,
	WinFare,
	Bump,
}

public class SoundManager : MonoBehaviour {

	public GameObject soundPrefab;

	public AudioClip buttonClickAudioClip;
	public AudioClip winFareAudioClip;
	public AudioClip[] bumpAudioClips;

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

		case Sound.Bump:
			soundObject.GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
			soundObject.GetComponent<AudioSource>().clip = bumpAudioClips[Random.Range(0,bumpAudioClips.Length)];
			break;
		}

		soundObject.GetComponent<AudioSource>().Play();
	}
}
