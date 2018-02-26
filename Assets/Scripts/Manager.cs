using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public GameObject greenPrefab;

	List<Box> boxes;

	// Use this for initialization
	void Start () {
		boxes = new List<Box> ();
	}

	void GenerateGreenBox () {
		// pick a random position on the right edge of the screen
		Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (0, Random.Range (0, Screen.height), 0));
		pos.z = 0;
		// instantiate a greenPrefab at that pos, with default rotation
		GameObject greenBox = Instantiate (greenPrefab, pos, Quaternion.identity);
		// keep a reference to the Box component
		boxes.Add (greenBox.GetComponent<Box> ());
	}
	
	// Update is called once per frame
	void Update () {
		
		// clicking anywhere creates a new GreenBox
		if (Input.GetMouseButtonDown (0)) {
			this.GenerateGreenBox ();
		}

		//*
		ExampleForEach ();
		/*/
		ExampleBackwardsFor ();
		//*/
	}

	void ExampleForEach () {
		// demonstrates iterating with a foreach loop
		foreach (Box box in boxes) {
			box.Move ();

			if (box.ShouldDestroy ()) {
				Destroy (box.gameObject);
				// Causes InvalidOperationException: The list was modified.
				// because we're still iterating over boxes when the Remove occurs
				boxes.Remove (box);
			}
		}
	}

	void ExampleBackwardsFor () {
		// demonstrates iterating with a for loop that counts down from the end of the ArrayList
		for (int i = boxes.Count - 1; i >= 0; i--) {
			Box box = boxes [i];

			box.Move ();

			if (box.ShouldDestroy ()) {
				Destroy (box.gameObject);
				boxes.RemoveAt (i);
			}
		}
	}
}
