using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour {

	public float sceneRestartDelay = 4f;
	public float gameRestartDelay = 30f;
	Player player;
	Animator gameOver;

	float restartTimer;
	// Use this for initialization
	void Start () {
		gameOver = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {


		//if(PlayerHealthManager.isPlayerDead && PlayerHealthManager.playerLives == 0)
		if(PlayerHealthManager.resetGame)
		{	
			gameOver.SetTrigger ("GameOver"); 
			restartTimer += Time.deltaTime;

			if(restartTimer >= gameRestartDelay){
				SceneManager.LoadScene ("High Scores");
			}
		}
		//else if (PlayerHealthManager.playerHealth <= 0) {
		else if (PlayerHealthManager.isPlayerNeedingReset) {
			if (restartTimer >= sceneRestartDelay) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
			restartTimer += Time.deltaTime;
		}

	}
}
