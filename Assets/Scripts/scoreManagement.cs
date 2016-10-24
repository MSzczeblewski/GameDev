using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreManagement : MonoBehaviour {
	
	public static int currentSessionScore;
	public int currentHighScore;

	public Text currentScoreBox,
				highScoreBox;



	void Start () {
		currentSessionScore = 0;
		if (PlayerPrefs.GetInt ("playerHighScoreSZ1") == 0) {
			resetHighScores ();
		} else {
			currentHighScore = PlayerPrefs.GetInt ("playerHighScoreSZ1");
			highScoreBox.text = currentHighScore + " :High Score";
		}
	}

	void Update () {
		addPoints ();
		
		currentScoreBox.text = "Score: " + currentSessionScore;
		PlayerPrefs.SetInt ("currentSessionScore", currentSessionScore);
		if (currentSessionScore > currentHighScore) 
			highScoreBox.text = currentSessionScore + " :High Score";	
	}



	private void addPoints(){
		//From Previous Project
//		if (!AnimationManager.isPlayerDead) {
//			if (Input.GetKeyDown (KeyCode.LeftArrow))
//				currentSessionScore += 1;
//			if (Input.GetKeyDown (KeyCode.RightArrow))
//				currentSessionScore += 1;
//			if (Input.GetKeyDown (KeyCode.UpArrow))
//				currentSessionScore += 1;
//			if (Input.GetKeyDown (KeyCode.DownArrow))
//				currentSessionScore += 1;
//			if (Input.GetKeyDown (KeyCode.Space))
//				currentSessionScore += 5;
//		}
	}

	private void resetHighScores(){
		for(int i=1; i<11; i++){
			PlayerPrefs.SetString ("playerNameHighScoreSZ"+i, "AAA");
			PlayerPrefs.SetInt ("playerHighScoreSZ"+i, 0);
		}
	}
}
