using UnityEngine;
using System.Collections;

public class PickupOneUp : MonoBehaviour {


	public int pointsAwarded;
	public AudioSource pickupSound;
	SpriteRenderer pickupSprite;

	// Use this for initialization
	void Start () {
		pickupSprite = GetComponent<SpriteRenderer> ();
	}
	

	void OnTriggerEnter2D (Collider2D other)
	{
		PlayerHealthManager.playerLives ++;
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
		yield return new WaitForSeconds(.8f);
		Destroy(gameObject);
	}
}
