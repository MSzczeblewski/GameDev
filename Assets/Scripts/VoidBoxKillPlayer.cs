using UnityEngine;
using System.Collections;

public class VoidBoxKillPlayer : MonoBehaviour {

	public int damageAmount = 100;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player")
		{
			PlayerHealthManager.HurtPlayer (damageAmount);
		}
	}
}
