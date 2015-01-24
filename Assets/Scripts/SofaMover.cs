using UnityEngine;
using System.Collections;

public class SofaMover : MonoBehaviour {

	private float rotateMulti = 10.0f;
	private float walkMulti = 2.5f;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public SofaMover otherPlayer;
	public Animation animation;

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

	}
	
	void Update() {
	}

	void FixedUpdate () {

		Vector3 ownVelocity = Vector3.zero;
		Vector3 ownRotation = Vector3.zero;
		otherPlayer.SetRotation(Vector3.zero);
		otherPlayer.SetVelocity(Vector3.zero);

		if (Input.GetKey (leftKey) && Input.GetKey (rightKey)) {
			ownVelocity = Vector3.right*walkMulti;
			animation.CrossFade("BigGuy_Walk_FW");
		} else if (Input.GetKey (leftKey)) {
			otherPlayer.SetRotation(Vector3.up*rotateMulti);
			ownVelocity = Vector3.forward*walkMulti;
			animation.CrossFade("BigGuy_Walk_L");
		} else if (Input.GetKey (rightKey)) {
			otherPlayer.SetRotation(-Vector3.up*rotateMulti);
			ownVelocity = -Vector3.forward*walkMulti;
			animation.CrossFade("BigGuy_Walk_R");
		}else{
			if(Mathf.Abs(rigidbody.velocity.x) > 0.3f){
				animation.CrossFade("BigGuy_Walk_BW");
			}else{
				animation.CrossFade("BigGuy_Idle");
			}
		}

		rigidbody.angularVelocity = transform.TransformDirection(ownRotation + publicRotation);
		rigidbody.velocity = transform.TransformDirection(ownVelocity + publicVelocity);
	}
}
