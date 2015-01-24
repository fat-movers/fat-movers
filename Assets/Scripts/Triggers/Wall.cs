using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	private bool isInvisible = false;
	private float wallSetInvisible = -10.0f;
	private float lastTimeInvisible = -10.0f;
	private float animationLength = 0.4f;
	private float invisibilityLength = 2.0f;
	private Color mainColor;
	private float startAlpha;

	void Start() {
		mainColor = renderer.material.color;
	}

	public void SetWallInvisible() {
		if (isInvisible == false) {
			isInvisible = true;
			wallSetInvisible = Time.time;
			startAlpha = renderer.material.color.a;
		}
		lastTimeInvisible = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (isInvisible) {
			if(Time.time > lastTimeInvisible+invisibilityLength) {
				isInvisible = false;
				startAlpha = renderer.material.color.a;
			} else {
				mainColor.a = Mathf.Lerp(startAlpha,0.4f,(Time.time-wallSetInvisible)/animationLength);
				renderer.material.color = mainColor;
			}
		} else if(Time.time < lastTimeInvisible+invisibilityLength+animationLength) {
			mainColor.a = Mathf.Lerp(startAlpha,1.0f,(Time.time-(lastTimeInvisible+invisibilityLength))/animationLength);
			renderer.material.color = mainColor;
		}
	}
}
