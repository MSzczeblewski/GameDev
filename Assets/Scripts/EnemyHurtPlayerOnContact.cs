using UnityEngine;
using System.Collections;

public class EnemyHurtPlayerOnContact : MonoBehaviour {

	public AudioSource hurtSound;
	public int damageAmount;
	private bool flashing = false;
	SpriteRenderer sprite;
	Controller2D playerTouched;
	public bool showLeft, showRight, showBelow;
	public bool lockEnemyPosition = false;

	public AudioSource enemyDeathSound;
	SpriteRenderer enemyDeathSprite;
	BoxCollider2D enemyBoxCollider;
	Animator enemyAnimator;
	Transform enemyTransform;

	public Vector3 previousPosition;

	// Use this for initialization
	void Start () {
		enemyDeathSprite = GetComponent<SpriteRenderer> ();
		enemyBoxCollider = GetComponent<BoxCollider2D> ();
		enemyAnimator = GetComponent<Animator> ();
		enemyTransform = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		if(lockEnemyPosition)
		{
			previousPosition = enemyTransform.position;
			enemyTransform.position = new Vector3 (previousPosition.x, previousPosition.y, previousPosition.z);
		}
	}




	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
		{
			playerTouched = other.gameObject.GetComponent<Controller2D> ();

			if(other.transform.position.y >= transform.position.y && playerTouched.collisions.below)
			{
				StartCoroutine (DestroyEnemy ());
			}

		 	else if (!PlayerHealthManager.isInvincible && !PlayerHealthManager.isPlayerNeedingReset) {
				hurtSound.Play ();
				PlayerHealthManager.HurtPlayer (damageAmount);
				sprite = other.gameObject.GetComponent <SpriteRenderer> ();
				if (other.gameObject.CompareTag ("Player")) {

					if (flashing == false) {
						StartCoroutine (DoBlinks ());
					}
				}

			}
		}

	}

	void OnTriggerStay2D(Collider2D other) {
		if (!PlayerHealthManager.isInvincible && !PlayerHealthManager.isPlayerNeedingReset) {
			hurtSound.Play ();
			PlayerHealthManager.HurtPlayer (damageAmount);
			sprite = other.gameObject.GetComponent <SpriteRenderer> ();
			if (other.gameObject.CompareTag ("Player")) {



				StartCoroutine (ExecuteAfterTime (1f));
				if (flashing == false) {
					StartCoroutine (DoBlinks ());
				}
			}

		}
	}


	IEnumerator DoBlinks()
	{

		flashing = true;


		sprite.color = new Color32(194, 194, 194, 70);
		yield return new WaitForSeconds(0.3f);
		sprite.color = new Color32(194, 194, 194, 255);
		yield return new WaitForSeconds(0.3f);
		sprite.color = new Color32(194, 194, 194, 70);
		yield return new WaitForSeconds(0.3f);
		sprite.color = new Color32(194, 194, 194, 255);
		flashing = false;

	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
	}

	IEnumerator DestroyEnemy()
	{
		enemyDeathSound.Play ();
		//enemyDeathSprite.color = new Color32(194, 194, 194, 0);
		enemyBoxCollider.enabled = false;
		lockEnemyPosition = true;
		enemyAnimator.SetTrigger ("boom");
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
