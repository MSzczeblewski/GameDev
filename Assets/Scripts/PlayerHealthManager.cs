using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Media;
using System.Runtime.Remoting.Lifetime;

public class PlayerHealthManager : MonoBehaviour {

	public bool show1, show2;
	public int show3;
	public float showRestart;

//	private float restartTimer;
//	private float restartDelay = 5f;

	public static bool isPlayerNeedingReset = false;
	public static bool isPlayerDead = false;
	public static bool isInvincible = false;
	public static int playerHealth = 100;  
	public static int playerLives = 3;

	public static float damageRestartTimer;
	public static float damageRestartDelay = 1f;

	public static bool resetGame = false;



	public Text playerHealthBox;
	public Text playerLifeBox;

	// Use this for initialization
	void Start () {
		if (resetGame)
			resetTheGame ();
		
		resetPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		showMe ();
		damageRestartTimer += Time.deltaTime;
		isInv ();
	


		if(playerHealth <= 0 && playerLives == 0 )
		{
			playerHealth = 0;
			isPlayerNeedingReset = true;
			isPlayerDead = true;
			resetGame = true;
		}
		else if(playerHealth <= 0)
		{
			playerHealth = 0;

			if(!isPlayerNeedingReset)
				playerLives--;

			isPlayerNeedingReset = true;

			//restartTimer += Time.deltaTime;

//			if(restartTimer >= restartDelay){
//				//
//				//Store my score here in a player pref to 
//				//
//				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
//
//			}
		}
		playerHealthBox.text = "Health: " + playerHealth;
		playerLifeBox.text = "Life: " + playerLives;
	}
		
/*--------------------------------------------------------------------------------------------------------------*/
	public static void HurtPlayer(int damageAmount)
	{
		if (PlayerHealthManager.damageRestartTimer > PlayerHealthManager.damageRestartDelay){
			playerHealth -= damageAmount;
			PlayerHealthManager.damageRestartTimer = 0f;
		}	
	}

	//fix this for sound when dmged
	public void isInv(){
		if (PlayerHealthManager.damageRestartTimer < PlayerHealthManager.damageRestartDelay)
			isInvincible = true;
		else
			isInvincible = false;
	}

	public void showMe()
	{
		show1 = isPlayerDead;
		show2 = isPlayerNeedingReset;
		show3 = playerLives;
		showRestart = damageRestartTimer;

	}
	public void resetTheGame(){
		playerLives = 3;
		isPlayerNeedingReset = false;
		isPlayerDead = false;
		resetGame = false;
	}

	public void resetPlayer(){
		playerHealth = 100;
		isPlayerNeedingReset = false;
	}


}
