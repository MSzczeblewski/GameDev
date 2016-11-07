using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour {

	public string loadLevel;
	public AudioSource winLevel;


	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
		{
			StartCoroutine (Play ());
		}

	}


	IEnumerator Play(){
		winLevel.Play ();
		PlayerHealthManager.resetGame = true;
		yield return new WaitForSeconds(6f);
	}
}