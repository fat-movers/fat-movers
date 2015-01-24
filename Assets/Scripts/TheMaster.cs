using UnityEngine;
using System.Collections;

public class TheMaster : MonoBehaviour {

	public SuperManager superManager;

	void Start () {
		superManager = SuperManager.instance;
	}
}
