using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			this.transform.root.gameObject.GetComponent<EnemyHurtPlayerOnContact> ().enemyStomped = true;
			//this.transform.root.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
		
	}
}
