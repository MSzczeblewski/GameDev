using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadStage : MonoBehaviour {

	public void loadScene (string sceneName){
		SceneManager.LoadScene (sceneName);
//		PlayerHealthManager.isPlayerDead = false;
//		PlayerHealthManager.isPlayerNeedingReset = false;
    }

	public void replayGame (){
//		
//		PlayerHealthManager.isPlayerDead = false;
//		PlayerHealthManager.isPlayerNeedingReset = false;

		SceneManager.LoadScene ("Level01");
	}

	public void quitApplication (){
		Application.Quit ();
	}


}
