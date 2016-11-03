using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreManagement : MonoBehaviour {
	
	public static int currentSessionScore;
	public int currentHighScore;
	public bool scoreSaved;

	public Text currentScoreBox;
				//highScoreBox;



	void Start () {
		scoreSaved = false;
		//check to see if first level if not load current player score
		 
		currentSessionScore = PlayerPrefs.GetInt("currentSessionScore");

//		if (SceneManager.GetActiveScene ().name == "Level01" )
//			currentSessionScore = 0;


		if (PlayerPrefs.GetInt ("playerHighScoreSZ1") == 0) {
			resetHighScores ();
		} else {
			currentHighScore = PlayerPrefs.GetInt ("playerHighScoreSZ1");
			//highScoreBox.text = currentHighScore + " :High Score";
		}
	}

	void Update () {

//		try to add a bool to see if I can get the score saved when game over and still displaying while resetting to 0 on retry
//		if (PlayerHealthManager.isPlayerDead == true && !scoreSaved) {
//			PlayerPrefs.SetInt ("currentSessionScoreSaved", currentSessionScore);
//			currentSessionScore = 0;
//			scoreSaved = true;
//		}
//		else if(PlayerHealthManager.isPlayerDead == true)
//		{
//			currentScoreBox.text = "Score: " + PlayerPrefs.GetInt("currentSessionScore");
//		}
//		else{
//			currentScoreBox.text = "Score: " + currentSessionScore;
//			PlayerPrefs.SetInt ("currentSessionScore", currentSessionScore);
		if (PlayerHealthManager.isPlayerDead == true && !scoreSaved) {
			PlayerPrefs.SetInt ("currentSessionScoreSaved", currentSessionScore);
			currentSessionScore = 0;
			scoreSaved = true;
		}
		else {
			currentScoreBox.text = "Score: " + currentSessionScore;
			PlayerPrefs.SetInt ("currentSessionScore", currentSessionScore);
		}
		//if (currentSessionScore > currentHighScore) 
			//highScoreBox.text = currentSessionScore + " :High Score";	
	}
		

	private void resetHighScores(){
		for(int i=1; i<11; i++){
			PlayerPrefs.SetString ("playerNameHighScoreSZ"+i, "AAA");
			PlayerPrefs.SetInt ("playerHighScoreSZ"+i, 0);
		}
	}
}
