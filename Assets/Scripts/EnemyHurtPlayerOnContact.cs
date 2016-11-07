using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class EnemyHurtPlayerOnContact : MonoBehaviour {

	public AudioSource hurtSound;
	public AudioSource enemyHit;
	public AudioSource enemyDeathSound;

	public int damageAmount;

	public bool flashing = false;
	public bool enemyStomped = false;
	public bool enemyDead = false;
	public bool playerHit = false;

	Collider2D playerTouching;
	SpriteRenderer sprite;

	SpriteRenderer enemyDeathSprite;
	BoxCollider2D enemyBoxCollider;
	Animator enemyAnimator;
	EnemyMovementNew enemySpeed;


	public Vector3 previousPosition;

	// Use this for initialization
	void Start () {
		enemyDeathSprite = GetComponent<SpriteRenderer> ();
		enemyBoxCollider = GetComponent<BoxCollider2D> ();
		enemyAnimator = GetComponent<Animator> ();
		enemySpeed =  GetComponent<EnemyMovementNew> ();
	}

	void Update(){
		if(enemyStomped && !enemyDead){
			StartCoroutine (DestroyEnemy ());
		}
		else if(playerHit)
		{
			StartCoroutine(DamagePlayer ());
		}
	}
		

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
		{
			playerTouching = other;
			sprite = other.gameObject.GetComponent <SpriteRenderer> ();
			playerHit = true;
		}
	}

	IEnumerator BlinkPlayer(){
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
		
	IEnumerator DamagePlayer()
	{
		if (!PlayerHealthManager.isInvincible && !PlayerHealthManager.isPlayerNeedingReset && !enemyStomped) {
			PlayerHealthManager.HurtPlayer (damageAmount);
			hurtSound.Play ();

			if (playerTouching.gameObject.CompareTag ("Player")) {
				if (!flashing) 
					StartCoroutine (BlinkPlayer ());
			}
		}
		playerHit = false;
		yield return new WaitForSeconds(0f);
	}

	IEnumerator DestroyEnemy()
	{
		enemyDead = true;
		enemyDeathSound.Play ();
		enemyHit.Play ();
		enemyBoxCollider.enabled = false;
		enemySpeed.speed = 0f;
		enemyAnimator.SetTrigger ("boom");
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
