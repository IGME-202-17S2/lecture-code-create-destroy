using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public void Move() {
		// advances the box towards the right at 3 units per second
		Vector3 pos = transform.position;
		pos += new Vector3(3 * Time.deltaTime, 0, 0);
		transform.position = pos;
	}

	public bool ShouldDestroy() {
		// returns true if the box is offscreen left
		return Camera.main.WorldToScreenPoint (transform.position).x > Screen.width;
	}
}
