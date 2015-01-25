using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	public SuperManager superManager;

	public SofaMover p1;
	public SofaMover p2;

	public TouchControlsButton p1Left;
	public TouchControlsButton p1Right;
	public TouchControlsButton p2Left;
	public TouchControlsButton p2Right;

	// Use this for initialization
	void Start () {
		superManager = FindObjectOfType(typeof(SuperManager)) as SuperManager;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(p1 && p2){
			if(p1Left.isDown && p1Right.isDown){
				p1.forceWalkingState = WalkingState.Forward;
			}else if(p1Left.isDown){
				p1.forceWalkingState = WalkingState.Left;
			}else if(p1Right.isDown){
				p1.forceWalkingState = WalkingState.Right;
			}else{
				p1.forceWalkingState = WalkingState.None;
			}

			if(p2Left.isDown && p2Right.isDown){
				p2.forceWalkingState = WalkingState.Forward;
			}else if(p2Left.isDown){
				p2.forceWalkingState = WalkingState.Left;
			}else if(p2Right.isDown){
				p2.forceWalkingState = WalkingState.Right;
			}else{
				p2.forceWalkingState = WalkingState.None;
			}
		}else{
			GameObject p1Obj = GameObject.Find("Sofa and Movers/Player1") as GameObject;
			if(p1Obj){
				p1 = p1Obj.GetComponent<SofaMover>();
			}

			GameObject p2Obj = GameObject.Find("Sofa and Movers/Player2") as GameObject;
			if(p2Obj){
				p2 = p2Obj.GetComponent<SofaMover>();
			}
		}
	}
}
