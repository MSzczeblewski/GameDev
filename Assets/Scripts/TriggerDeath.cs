using UnityEngine;
using System.Collections;

public class TriggerDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnTriggerEnter2d(Collider2D hitObj){
//		if (hitObj.gameObject.tag == "KillPlayer")
//			AnimationManager.isPlayerDead = true;
//	}

	void OnCollisionEnter2d(Collider2D hitObj){
	//	if (hit.collider.tag == "KillPlayer") 
		AnimationManager.isPlayerDead = true;
	}
}
