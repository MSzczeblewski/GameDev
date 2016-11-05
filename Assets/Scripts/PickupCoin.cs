using UnityEngine;
using System.Collections;


public class PickupCoin : MonoBehaviour {

	public int pointsAwarded;
	public AudioSource pickupSound;
	SpriteRenderer pickupSprite;
	bool isPickedUp = false;

	void Start () {
		pickupSprite = GetComponent<SpriteRenderer> ();
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		if (!isPickedUp) {
			scoreManagement.currentSessionScore += pointsAwarded;

			//StartCoroutine (PickupAnimation ());
			StartCoroutine (DestroyPickup ());
		}
	}



	IEnumerator PickupAnimation()
	{
		pickupSound.Play ();
		pickupSprite.color = new Color32(194, 194, 194, 0);
		yield return new WaitForSeconds(0f);
	}


	IEnumerator DestroyPickup()
	{
		isPickedUp = true;
		pickupSound.Play ();
		pickupSprite.color = new Color32(194, 194, 194, 0);
		yield return new WaitForSeconds(.6f);
		Destroy(gameObject);
	}
}