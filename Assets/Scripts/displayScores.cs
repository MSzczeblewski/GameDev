using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayScores : MonoBehaviour {

	public InputField currentHighScorePlayerName;

	public Canvas highScoreCanvas;

	public Text	playerHighScore1,
				playerHighScore2,
				playerHighScore3,
				playerHighScore4,
				playerHighScore5,
				playerHighScore6,
				playerHighScore7,
				playerHighScore8,
				playerHighScore9,
				playerHighScore10;



	void Start () {
		highScoreCanvas.enabled = false;

		setHighScores ();

		//check to see if player prefs are initialized if not setting default values
		if (PlayerPrefs.GetInt ("playerHighScoreSZ1") == 0) {
			resetHighScores ();
		} 

		//check to see if current sessions score qualifies for a new high score
		if (PlayerPrefs.GetInt("currentSessionScoreSaved") > PlayerPrefs.GetInt("playerHighScoreSZ10")){
			highScoreCanvas.enabled = true;
		}
	}
		
	void Update () 
	{

	
	
	}



	private void setHighScores(){
		playerHighScore1.text = PlayerPrefs.GetString("playerNameHighScoreSZ1") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ1");
		playerHighScore2.text = PlayerPrefs.GetString("playerNameHighScoreSZ2") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ2");
		playerHighScore3.text = PlayerPrefs.GetString("playerNameHighScoreSZ3") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ3");
		playerHighScore4.text = PlayerPrefs.GetString("playerNameHighScoreSZ4") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ4");
		playerHighScore5.text = PlayerPrefs.GetString("playerNameHighScoreSZ5") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ5");
		playerHighScore6.text = PlayerPrefs.GetString("playerNameHighScoreSZ6") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ6");
		playerHighScore7.text = PlayerPrefs.GetString("playerNameHighScoreSZ7") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ7");
		playerHighScore8.text = PlayerPrefs.GetString("playerNameHighScoreSZ8") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ8");
		playerHighScore9.text = PlayerPrefs.GetString("playerNameHighScoreSZ9") + " : " + PlayerPrefs.GetInt("playerHighScoreSZ9");
		playerHighScore10.text = PlayerPrefs.GetString ("playerNameHighScoreSZ10") + " : " + PlayerPrefs.GetInt ("playerHighScoreSZ10");
	}

	private void enterNewHighScore(){
		string tempPlayerName;
		int tempPlayerScore;	

		for (int i=1; i<11; i++){
			if (PlayerPrefs.GetInt("currentSessionScoreSaved") > PlayerPrefs.GetInt("playerHighScoreSZ"+i)){
				tempPlayerScore = PlayerPrefs.GetInt("playerHighScoreSZ"+i);
				PlayerPrefs.SetInt("playerHighScoreSZ"+i, PlayerPrefs.GetInt("currentSessionScoreSaved"));
				PlayerPrefs.SetInt("currentSessionScoreSaved", tempPlayerScore);
				tempPlayerName = PlayerPrefs.GetString("playerNameHighScoreSZ"+i);
				PlayerPrefs.SetString("playerNameHighScoreSZ"+i, PlayerPrefs.GetString("currentHighScorePlayerName"));
				PlayerPrefs.SetString("currentHighScorePlayerName", tempPlayerName);
			}
		}
	}

	private void resetHighScores(){
		for(int i=1; i<11; i++){
			PlayerPrefs.SetString ("playerNameHighScoreSZ"+i, "AAA");
			PlayerPrefs.SetInt ("playerHighScoreSZ"+i, 0);
		}
		setHighScores ();
	}
		
	public void setCurrentHighScorePlayerName(string newName){
		PlayerPrefs.SetString ("currentHighScorePlayerName",newName.ToUpper());
		enterNewHighScore ();
		setHighScores ();
		highScoreCanvas.enabled = false;
	}
		
}
