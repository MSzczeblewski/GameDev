using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadStage : MonoBehaviour {

	public void loadScene (string sceneName){
		SceneManager.LoadScene (sceneName);
		AnimationManager.isPlayerDead = false;
    }

	public void quitApplication (){
		Application.Quit ();
	}


}
