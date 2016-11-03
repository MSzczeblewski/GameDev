using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public AudioSource hurtSound;
	public int damageAmount;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player")
		{
			if(!PlayerHealthManager.isInvincible)
				hurtSound.Play ();
			//PlayerHealthManager.HurtPlayer (damageAmount);
		}
	}
}
