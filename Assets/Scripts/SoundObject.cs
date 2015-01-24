using UnityEngine;
using System.Collections;

public class SoundObject : MonoBehaviour {

	void Start () {
		StartCoroutine(DestroyAfterSeconds(2.0f));
	}

	IEnumerator DestroyAfterSeconds(float secondToDestroy){
		yield return new WaitForSeconds(secondToDestroy);
		Destroy(gameObject);
	}
}
