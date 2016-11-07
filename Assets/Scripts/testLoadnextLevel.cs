using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class testLoadnextLevel : MonoBehaviour {

	public string loadLevel;
	public AudioSource winLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
		{
			StartCoroutine (Play ());
		}

	}


	IEnumerator Play(){
		winLevel.Play ();
		yield return new WaitForSeconds(6f);
		SceneManager.LoadScene (loadLevel);
	}
}
