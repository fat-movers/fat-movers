using UnityEngine;
using System.Collections;
using System;

public enum WalkingState {
	None,
	Left,
	Right,
	Forward,
	length
}

public class SofaMover : MonoBehaviour {

	private float rotateMulti = 10.0f;
	private float walkMulti = 2.5f;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public SofaMover otherPlayer;
	private Animation myAnimation;
	public WalkingState forceWalkingState = WalkingState.None;
	public AlkuHopotys[] alkuHopotykset;

	private Vector3 publicRotation = Vector3.zero;
	private Vector3 publicVelocity = Vector3.zero;

	public void SetRotation(Vector3 rotation) {
		publicRotation = rotation;
	}

	public void SetVelocity(Vector3 velocity) {
		publicVelocity = velocity;
	}

	// Use this for initialization
	void Start () {
		myAnimation = transform.Find("BigGuy_Animated").animation;
		StartCoroutine (AlkuHopota ());
	}

	IEnumerator AlkuHopota() {
		foreach(AlkuHopotys alkuHopotys in alkuHopotykset) {
			yield return new WaitForSeconds (alkuHopotys.waitBeforeStarting);
			Say (alkuHopotys.text, alkuHopotys.width, alkuHopotys.height, alkuHopotys.waitTime);
		}
	}
	
	void Update() {
	}

	void FixedUpdate () {

		Vector3 ownVelocity = Vector3.zero;
		Vector3 ownRotation = Vector3.zero;
		otherPlayer.SetRotation(Vector3.zero);
		otherPlayer.SetVelocity(Vector3.zero);

		if (forceWalkingState == WalkingState.Forward || Input.GetKey (leftKey) && Input.GetKey (rightKey)) {
			ownVelocity = Vector3.right*walkMulti;
			myAnimation.CrossFade("BigGuy_Walk_FW");
		} else if (forceWalkingState == WalkingState.Left || Input.GetKey (leftKey)) {
			otherPlayer.SetRotation(Vector3.up*rotateMulti);
			ownVelocity = Vector3.forward*walkMulti;
			myAnimation.CrossFade("BigGuy_Walk_L");
		} else if (forceWalkingState == WalkingState.Right || Input.GetKey (rightKey)) {
			otherPlayer.SetRotation(-Vector3.up*rotateMulti);
			ownVelocity = -Vector3.forward*walkMulti;
			myAnimation.CrossFade("BigGuy_Walk_R");
		}else{
			if(Mathf.Abs(rigidbody.velocity.x) > 0.3f){
				myAnimation.CrossFade("BigGuy_Walk_BW");
			}else{
				myAnimation.CrossFade("BigGuy_Idle");
			}
		}

		rigidbody.angularVelocity = transform.TransformDirection(ownRotation + publicRotation);
		rigidbody.velocity = transform.TransformDirection(ownVelocity + publicVelocity);
	}

	public void Say(string text, int width, int height, float waitTime) {
		Transform kuplaTrans = transform.Find ("Puhekupla");
		UnityEngine.UI.Text kuplaText = kuplaTrans.GetComponentInChildren<UnityEngine.UI.Text> ();
		kuplaText.rectTransform.sizeDelta = new Vector2 (width-100, height-100);
		kuplaText.text = "";
		kuplaTrans.GetComponent<RectTransform>().sizeDelta = new Vector2 (width, height);
		kuplaTrans.Find("Panel").GetComponent<RectTransform>().sizeDelta = new Vector2 (width, height);
		StartCoroutine (DoSay (waitTime, text));
	}

	IEnumerator DoSay(float waitTime, string text) {
		yield return new WaitForSeconds (1.0f);
		Transform kuplaTrans = transform.Find ("Puhekupla");
		Animation kuplaAnim = kuplaTrans.animation;
		UnityEngine.UI.Text kuplaText = kuplaTrans.GetComponentInChildren<UnityEngine.UI.Text> ();
		kuplaAnim.Play ("BubbleIn");
		float tickLength = 0.05f;
		for (int i = 0; i < text.Length; i++) {
			yield return new WaitForSeconds (tickLength);
			kuplaText.text += text[i];
		}
		yield return new WaitForSeconds (kuplaAnim["BubbleIn"].length+waitTime-(text.Length*tickLength));
		kuplaAnim.Play("BubbleOut");
	}
}


[Serializable]
public class AlkuHopotys {
	public string text;
	public int width;
	public int height;
	public float waitTime;
	public float waitBeforeStarting;
}
