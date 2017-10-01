using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

	[Range(0, 0.05f)]
	public float accelerationAmount;

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		this.velocity = new Vector3 (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f), 0);
	}
	
	// Update is called once per frame
	void Update () {
		// find the mouse position as expressed in world-space coordinates
		Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		// find the vector from the item to the mouse
		Vector3 heading = targetPos - transform.position; // direction to desired location = (desired location - current location)
		heading.Normalize (); // as a unit vector now
		heading.z = 0; // make sure it doesn't leave the x-y plane

		// alter velocity by (magnitude) accelarationAmmout in the direction of heading
		this.velocity = this.velocity + (this.accelerationAmount * heading);

		// update the follower's position
		transform.position = transform.position + this.velocity;
	}
}
