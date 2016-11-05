using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public AudioSource hurtSound;
	public int damageAmount;
	private bool flashing = false;
	SpriteRenderer sprite;
	Controller2D playerTouched;
	public bool showLeft, showRight, showBelow;

	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer>();
	}
	


	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
		{
			//playerTouched = other.gameObject.GetComponent<Controller2D> ();

			
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
}
