using UnityEngine;
using System.Collections;

public class MineExplode : MonoBehaviour {

	public AudioSource hurtSound;
	public AudioSource mineExplode;

	public int damageAmount;
	private bool flashing = false;
	SpriteRenderer playerSprite;
	SpriteRenderer mineSprite;
	Animator mineAnimator;
	BoxCollider2D enemyBoxCollider;

	// Use this for initialization
	void Start () {
		mineSprite = GetComponent<SpriteRenderer> ();
		enemyBoxCollider = GetComponent<BoxCollider2D> ();
	}
	


	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
		{
		if (!PlayerHealthManager.isInvincible && !PlayerHealthManager.isPlayerNeedingReset) {
				hurtSound.Play ();
				PlayerHealthManager.HurtPlayer (damageAmount);
				playerSprite = other.gameObject.GetComponent <SpriteRenderer> ();
				if (other.gameObject.CompareTag ("Player")) {


					if (flashing == false) {
						StartCoroutine (DoBlinks ());
						StartCoroutine (MineAnimation ());
						StartCoroutine (DestroyMine ());
					}
				}

			}
		}

	}
	IEnumerator DoBlinks()
	{
		flashing = true;
		playerSprite.color = new Color32(194, 194, 194, 70);
		yield return new WaitForSeconds(0.2f);
		playerSprite.color = new Color32(194, 194, 194, 255);
		yield return new WaitForSeconds(0.2f);
		playerSprite.color = new Color32(194, 194, 194, 70);
		yield return new WaitForSeconds(0.2f);
		playerSprite.color = new Color32(194, 194, 194, 255);
		flashing = false;
	}

	IEnumerator MineAnimation()
	{
		mineAnimator = GetComponent <Animator> ();
		mineAnimator.SetTrigger ("boom");
		mineExplode.Play ();
		enemyBoxCollider.enabled = false;
		yield return new WaitForSeconds(.6f);
		mineSprite.color = new Color32(194, 194, 194, 0);
	}

	IEnumerator DestroyMine()
	{
		yield return new WaitForSeconds(1f);
		Destroy (gameObject);
	}

}
