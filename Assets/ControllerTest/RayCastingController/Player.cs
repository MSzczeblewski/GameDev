using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {


	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	const float defaultSpeed = 7;
	float moveSpeed = 7;
	float runSpeed = 20;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;

	void Start() {
		controller = GetComponent<Controller2D> ();

		//simplification of how high to jump and time in air 
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		//print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void Update() {

		//keep gravity from accumilating
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		//directional input
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		//jumping input
		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift)) {
			moveSpeed = runSpeed;
		} else {
			moveSpeed = defaultSpeed;
		}

		//player movement, adjust velocity & smoothing for direction changing
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}