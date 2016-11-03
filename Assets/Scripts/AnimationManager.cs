using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;

[RequireComponent (typeof (Player))]
[RequireComponent (typeof (Controller2D))]
public class AnimationManager : MonoBehaviour {

	//[HideInInspector]
//	public static bool isPlayerDead = false;
	public bool needRestart = false;
	private bool flipAnimation = true;
	SpriteRenderer flipPlayer; 
	Controller2D playerController;
	Animator playerAnimation;


	//Sounds
	public AudioSource deathSound;
	public AudioSource climbSound;
	public AudioSource runSound;
	public AudioSource jumpSound;

	public Vector2 dirInput;
	public Vector3 showVelocity;

	public bool isGrounded;
	public bool isJumping;
	public bool isClimbing;

/*--------------------------------------------------------------------------------------------------------------*/

	void Start () {
		flipPlayer = gameObject.GetComponent<SpriteRenderer>();
		playerAnimation = GetComponent<Animator> ();
		playerController = GetComponent<Controller2D> ();
	}

/*--------------------------------------------------------------------------------------------------------------*/

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		dirInput = directionalInput;
		showVelocity = Player.velocity;

		playerDead ();

		if (!PlayerHealthManager.isPlayerNeedingReset) {
			if (directionalInput.x > 0 && !flipAnimation)
				Flip ();
			else if (directionalInput.x < 0 && flipAnimation)
				Flip ();
		}

		HandleMovement (directionalInput.x);

		isGrounded = IsPlayerGrounded ();

		isClimbing = IsPlayerClimbing ();

		IsPlayerJumping ();

		if(!needRestart)
			IsMovingPlaySound ();
	}

/*--------------------------------------------------------------------------------------------------------------*/

	private void HandleMovement(float horizontalInput){
		playerAnimation.SetFloat ("Speed", Mathf.Abs (horizontalInput));

		//speed up jumping animation old school mario style
		if((isJumping && !isClimbing) || (Mathf.Abs (showVelocity.x) > 5.2)){
			playerAnimation.speed = 4.0f;
		}
		else{
			playerAnimation.speed = 1.0f;
		}

		//Testing out animation states with booleans vs others
		//if(isClimbing && !this.playerAnimation.GetCurrentAnimatorStateInfo (0).IsName ("Climb")){
		if(isClimbing){
			playerAnimation.SetBool ("Climb", true);
		}
		else if (!isClimbing){
			playerAnimation.SetBool ("Climb", false);
		}
	}

	private void IsMovingPlaySound(){
		if (isClimbing && isJumping && !isGrounded)
			climbSound.Play ();
		if (Input.GetKeyDown (KeyCode.Space) && jumpSound.isPlaying == false && (isGrounded ))
			jumpSound.Play();
		if (isJumping || isClimbing || (Mathf.Abs (showVelocity.x) <= 5.1))
			runSound.Stop ();
		else if ((climbSound.isPlaying == false && runSound.isPlaying == false && isPlayerDead() == false) && (Mathf.Abs (showVelocity.x) > 5))
			runSound.Play ();

	}

	void Flip(){
		if (flipAnimation) 
			flipPlayer.flipX = true;
		else 
			flipPlayer.flipX = false;

		flipAnimation = !flipAnimation;
	}
		
	private bool IsPlayerClimbing(){
		if (Player.velocity.y < 0) {
			if (playerController.collisions.left || playerController.collisions.right)
				return true;
		}
		else{
			 return false;
		}
		return false;
	}

	private bool IsPlayerGrounded(){
		if (playerController.collisions.below) 
			return true;
		else
			return false;
	}

	private void IsPlayerJumping(){
		if(Input.GetKeyDown (KeyCode.Space)){
			isJumping = true;
		}
		else if (Player.velocity.y == 0){
			isJumping = false;
		}
//		else if (isClimbing){
//			isJumping = false;
//		}
	}

	private bool isPlayerDead()
	{
		if (PlayerHealthManager.isPlayerNeedingReset)
			return true;
		else
			return false;
	}

	private void playerDead(){
		if ((PlayerHealthManager.isPlayerDead || PlayerHealthManager.isPlayerNeedingReset)  && !needRestart) {
			Player.velocity.Set (0, 0, 0);
			playerAnimation.SetInteger ("State", 8);
			deathSound.Play ();
			needRestart = true;
		} 
	}
}
 