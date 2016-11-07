using UnityEngine;
using System.Collections;

public class PickupOneUp : MonoBehaviour {


	public int pointsAwarded;
	public AudioSource pickupSound;
	SpriteRenderer pickupSprite;
	bool isPickedUp = false;

	// Use this for initialization
	void Start () {
		pickupSprite = GetComponent<SpriteRenderer> ();
	}
	

	void OnTriggerEnter2D (Collider2D other)
	{
		if (!isPickedUp && 	other.tag == "Player") {
			PlayerHealthManager.playerLives++;
			StartCoroutine (DestroyPickup ());
		}
	}

	IEnumerator DestroyPickup()
	{
		isPickedUp = true;
		pickupSound.Play ();
		pickupSprite.color = new Color32(194, 194, 194, 0);
		yield return new WaitForSeconds(.8f);
		Destroy(gameObject);
	}
}
