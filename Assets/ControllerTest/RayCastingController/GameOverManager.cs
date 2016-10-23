using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour {


	public float restartDelay = 5f;
	Player player;
	Animator gameOver;

	float restartTimer;
	// Use this for initialization
	void Start () {
		gameOver = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if(AnimationManager.isPlayerDead)
		{
			gameOver.SetTrigger ("GameOver"); 
			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
				SceneManager.LoadScene ("High Scores");
		}
	}
}
