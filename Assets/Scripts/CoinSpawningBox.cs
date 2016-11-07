using UnityEngine;
using System.Collections;

public class CoinSpawningBox : MonoBehaviour {

	public GameObject poppedStateBox;

	void OnTriggerEnter2D(Collider2D collider){

		Vector3 heading = this.transform.position - collider.gameObject.transform.position;


		float distance = heading.magnitude;
		Vector3 direction = heading / distance;
		Debug.Log (direction);

		if ((direction.x < .1 && direction.x > -1.1) && (direction.y < 1.1 && direction.y > .1) && collider.tag == "Player")
			CoinPop ();
	}

	void CoinPop(){
		poppedStateBox.SetActive (true);
		this.gameObject.SetActive (false);
	}
}
