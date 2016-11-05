using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

	Controller2D playerTouched;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnColliderEnter2D(Collider2D other){
//		if(other.tag == "Player")
//		{
//			playerTouched = other.gameObject.GetComponent<Controller2D> ();
//
//			if(playerTouched.collisions.below && !playerTouched.collisions.left && !playerTouched.collisions.right )
//				Destroy(gameObject);
//
//			else if (!PlayerHealthManager.isInvincible && !PlayerHealthManager.isPlayerNeedingReset) {
//				hurtSound.Play ();
//				PlayerHealthManager.HurtPlayer (damageAmount);
//				sprite = other.gameObject.GetComponent <SpriteRenderer> ();
//				if (other.gameObject.CompareTag ("Player")) {
//
//
//
//					StartCoroutine (ExecuteAfterTime (1f));
//					if (flashing == false) {
//						StartCoroutine (DoBlinks ());
//					}
//				}
//
//			}
//		}

	}
}
