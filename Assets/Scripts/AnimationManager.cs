using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimationManager : MonoBehaviour {

	Animator animation;
	public BoxCollider2D player;
	public BoxCollider2D wall1;
	public BoxCollider2D wall2;
	private bool flipAnimation = true;
	public AudioSource deathSound;
	public AudioSource zsound1;
	public AudioSource zsound2;


	private bool dead = false;

	private float move;


	//---------------------------------------------------------------
	void Start () {
		animation = GetComponent<Animator> ();
	}


	//---------------------------------------------------------------
	void Update () {
		move = GetComponent<Rigidbody2D> ().velocity.x;

		if (move > 0 && !flipAnimation)
			Flip ();
		else {
			if (move < 0 && flipAnimation)
				Flip ();
		}

		if (player.IsTouching (wall1) || player.IsTouching (wall2)) {
			animation.SetInteger ("State", 0);
		} 
		else {
			if (move > 1 || move < -1) {
				animation.SetInteger ("State", 4);
				if (zsound1.isPlaying == false && zsound2.isPlaying == false && !dead)
					zsound2.Play ();
			} 
			else if (move > 0 && move <= 1) {
				animation.SetInteger ("State", 1);
				if (zsound1.isPlaying == false && zsound2.isPlaying == false && !dead)
					zsound1.Play ();
			}
			else if (move < 0){
				animation.SetInteger ("State", 1);
			if (zsound1.isPlaying == false && zsound2.isPlaying == false && !dead)
				zsound1.Play ();
			}
			else 
				animation.SetInteger ("State", 0);

			
	
		}
			
		if (Input.GetKeyUp (KeyCode.LeftArrow))
			animation.SetInteger ("State", 0);
		if (Input.GetKeyUp (KeyCode.RightArrow))
			animation.SetInteger ("State", 0);


		if ((Input.GetKeyDown (KeyCode.Backspace) || Input.GetKeyDown (KeyCode.Delete)) && (!dead)) {
			dead = true;
			animation.SetInteger ("State", 8);
			deathSound.Play ();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	//---------------------------------------------------------------
	void Flip(){
		flipAnimation = !flipAnimation;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
