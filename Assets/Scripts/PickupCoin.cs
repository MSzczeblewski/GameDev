using UnityEngine;
using System.Collections;


public class PickupCoin : MonoBehaviour {

	public int pointsAwarded;
	public AudioSource pickupSound;
	SpriteRenderer pickupSprite;

	void Start () {
		pickupSprite = GetComponent<SpriteRenderer> ();
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		scoreManagement.currentSessionScore += pointsAwarded;

		//StartCoroutine (PickupAnimation ());
		StartCoroutine (DestroyPickup ());
	}



	IEnumerator PickupAnimation()
	{
		pickupSound.Play ();
		pickupSprite.color = new Color32(194, 194, 194, 0);
		yield return new WaitForSeconds(0f);
	}


	IEnumerator DestroyPickup()
	{
		pickupSound.Play ();
		pickupSprite.color = new Color32(194, 194, 194, 0);
		yield return new WaitForSeconds(.6f);
		Destroy(gameObject);
	}
}