using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void replayGame (){
		PlayerHealthManager.isPlayerDead = false;
		PlayerHealthManager.isPlayerNeedingReset = false;
		SceneManager.LoadScene ("Level01");
	}

	public void resetPlayerPosition(){
		
	}

	public void quitApplication (){
		Application.Quit ();
	}

}
