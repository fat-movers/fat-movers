using UnityEngine;
using System.Collections;

public class Sofa : MonoBehaviour {

	private SuperManager superManager;

	private bool canPlayStepSound;

	void Start () {
		superManager = FindObjectOfType(typeof(SuperManager)) as SuperManager;
		canPlayStepSound = true;
	}

	void FixedUpdate(){
		if(Mathf.Abs(rigidbody.velocity.x) > 0.2 || Mathf.Abs(rigidbody.velocity.z) > 0.2){
			StartCoroutine(MakeSomeStepSounds());
		}
	}

	IEnumerator MakeSomeStepSounds(){
		if(!canPlayStepSound){

		}else{
			canPlayStepSound = false;
			superManager.soundManager.PlaySound(Sound.Step);
			yield return new WaitForSeconds(0.6f);
			canPlayStepSound = true;
		}
	}

	void OnCollisionEnter(Collision c){
		superManager.soundManager.PlaySound(Sound.Bump);
	}
}
