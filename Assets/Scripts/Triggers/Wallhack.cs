using UnityEngine;
using System.Collections;

public class Wallhack : MonoBehaviour {

	private SofaMover[] movers;

	void Start() {
		movers = FindObjectsOfType<SofaMover>();
		InvokeRepeating ("ShootAllRays", 1.0f, 1.5f);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Y)) {
			foreach(MonoBehaviour m in gameObject.GetComponents<MonoBehaviour>()) {
				if(this != m) m.enabled = !m.enabled;
			}
		}
	}

	// Update is called once per frame
	void ShootAllRays () {
		foreach(SofaMover mover in movers) {
			Collider coll = mover.collider;
			ShootRayTo(coll.bounds.center);
		}
	}

	void ShootRayTo(Vector3 point) {
		Ray ray = new Ray (Camera.main.transform.position, point - Camera.main.transform.position);
		RaycastHit hit;
		//Debug.DrawRay(ray.origin, ray.direction);
		if (Physics.Raycast (ray, out hit)) {
			Wall wall = hit.collider.GetComponent<Wall>();
			if(wall != null) {
				wall.SetWallInvisible();
			};
		}
	}
}
