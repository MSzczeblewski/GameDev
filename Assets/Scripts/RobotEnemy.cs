using UnityEngine;
using System.Collections;

public class RobotEnemy : MonoBehaviour {

	public AudioSource hurtSound;
	public AudioSource mineExplode;

	public int damageAmount;
	private bool flashing = false;
	SpriteRenderer playerSprite;
	Animator mineAnimator;
	Controller2D playerTouched;

	// Use this for initialization
	void Start () {
		
	}



	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
		{

			playerTouched = other.gameObject.GetComponent<Controller2D> ();

	

			//if (playerTouched.collisions.below && !playerTouched.collisions.left && !playerTouched.collisions.right)
			//if (playerTouched.collisions.below && !playerTouched.collisions.left && !playerTouched.collisions.right)
			if(other.transform.position.y >= transform.position.y && playerTouched.collisions.below)
			{
				Destroy (gameObject);
			}
			else if (!PlayerHealthManager.isInvincible && !PlayerHealthManager.isPlayerNeedingReset) {
				hurtSound.Play ();
				PlayerHealthManager.HurtPlayer (damageAmount);
				playerSprite = other.gameObject.GetComponent <SpriteRenderer> ();
				if (other.gameObject.CompareTag ("Player")) {



					StartCoroutine (ExecuteAfterTime (1f));
					if (flashing == false) {
						StartCoroutine (DoBlinks ());
					}
				}

			}
		}

	}
	IEnumerator DoBlinks()
	{

		flashing = true;


		playerSprite.color = new Color32(194, 194, 194, 70);
		yield return new WaitForSeconds(0.3f);
		playerSprite.color = new Color32(194, 194, 194, 255);
		yield return new WaitForSeconds(0.3f);
		playerSprite.color = new Color32(194, 194, 194, 70);
		yield return new WaitForSeconds(0.3f);
		playerSprite.color = new Color32(194, 194, 194, 255);
		flashing = false;

	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
	}
}
