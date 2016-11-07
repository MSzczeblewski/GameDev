using UnityEngine;
using System.Collections;

public class PickupHealth : MonoBehaviour {

	public int healthAwarded;
	public AudioSource pickupSound;
	SpriteRenderer pickupSprite;
	bool isPickedUp = false;

	void Start () {
		pickupSprite = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
//		if (other.gameObject.CompareTag("Player"))
//			Destroy(gameObject);
		if (!isPickedUp && 	other.tag == "Player") {
			PlayerHealthManager.playerHealth += healthAwarded;

			StartCoroutine (PickupAnimation ());
			StartCoroutine (DestroyPickup ());
		}

	}


	IEnumerator PickupAnimation()
	{
		isPickedUp = true;
		pickupSound.Play ();
		pickupSprite.color = new Color32(194, 194, 194, 0);
		yield return new WaitForSeconds(0f);
	}


	IEnumerator DestroyPickup()
	{
		yield return new WaitForSeconds(.6f);
		Destroy(gameObject);
	}
}
