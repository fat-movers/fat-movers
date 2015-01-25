using UnityEngine;
using System.Collections;

public enum Sound{
	ButtonClick,
	WinFare,
	Bump,
	Grunt,
	Hurt,
	Step
}

public class SoundManager : MonoBehaviour {

	public AudioSource musicAudioSource;
	public GameObject soundPrefab;

	public AudioClip buttonClickAudioClip;
	public AudioClip winFareAudioClip;
	public AudioClip[] bumpAudioClips;
	public AudioClip[] gruntAudioClips;
	public AudioClip[] hurtAudioClips;
	public AudioClip[] stepAudioClips;

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

		case Sound.Grunt:
			soundObject.GetComponent<AudioSource>().clip = gruntAudioClips[Random.Range(0,bumpAudioClips.Length)];
			break;

		case Sound.Hurt:
			soundObject.GetComponent<AudioSource>().clip = hurtAudioClips[Random.Range(0,bumpAudioClips.Length)];
			break;

		case Sound.Step:
			soundObject.GetComponent<AudioSource>().clip = stepAudioClips[Random.Range(0,bumpAudioClips.Length)];
			break;
		}

		soundObject.GetComponent<AudioSource>().Play();
	}

	public void StopMusic(){
		musicAudioSource.Stop();
	}
}
