using UnityEngine;
using System.Collections;

public class PlayerControllerSimple : MonoBehaviour {

	Animator player;

	private int leftTotal=0;
	private float leftDelay=0;
	private int rightTotal=0;
	private float rightDelay=0;

	private bool dead = false;

	private float move;

	private int xVelocity=3;


	//---------------------------------------------------------------
	void Start () {
		player = GetComponent<Animator> ();
	}


	//---------------------------------------------------------------
	void Update () {
		 move = Input.GetAxis ("Horizontal");

		if (!dead) {
			
				if (Input.GetKey (KeyCode.RightArrow)) {

				if (Input.GetKey (KeyCode.Space) && xVelocity > 1)
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (move, 0);
				else if (Input.GetKey (KeyCode.Space) && xVelocity == 0)
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				else 
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (move + xVelocity, GetComponent<Rigidbody2D> ().velocity.y);
				
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) 
					rightTotal++;
			
				if (Input.GetKeyUp (KeyCode.RightArrow)) 
					xVelocity = 0;
			
				if ((rightTotal == 1) && (rightDelay < .5)) 
					rightDelay += Time.deltaTime;
			
				if ((rightTotal == 1) && (rightDelay >= .5)) {
					rightDelay = 0;
					rightTotal = 0;
				}
				if ((rightTotal == 2) && (rightDelay < .5)) {
					xVelocity = 5;
					rightTotal = 0;
				}
				if ((rightTotal == 2) && (rightDelay >= .5)) {
					xVelocity = 0;
					rightTotal = 0;
					rightDelay = 0;
				}


				if (Input.GetKey (KeyCode.LeftArrow)) {

					if (Input.GetKey (KeyCode.Space) && xVelocity > 1)
						GetComponent<Rigidbody2D> ().velocity = new Vector2 (move, 0);
				
					else if (Input.GetKey (KeyCode.Space) && xVelocity == 0)
						GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				
					else
						GetComponent<Rigidbody2D> ().velocity = new Vector2 (move - xVelocity, GetComponent<Rigidbody2D> ().velocity.y);

				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) 
					leftTotal++;
			
				if (Input.GetKeyUp (KeyCode.LeftArrow)) 
					xVelocity = 0;
			
				if ((leftTotal == 1) && (leftDelay < .5)) 
					leftDelay += Time.deltaTime;
			
				if ((leftTotal == 1) && (leftDelay >= .5)) {
					leftDelay = 0;
					leftTotal = 0;
				}
				if ((leftTotal == 2) && (leftDelay < .5)) {
					xVelocity = 5;
					leftTotal = 0;
				}
				if ((leftTotal == 2) && (leftDelay >= .5)) {
					xVelocity = 0;
					leftTotal = 0;
					leftDelay = 0;
				}
			}

			if (Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Delete))
				dead = true;
	}
		
}
