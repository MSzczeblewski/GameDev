using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;

	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (!AnimationManager.isPlayerDead) {
			player.SetDirectionalInput (directionalInput);
			if (Input.GetKeyDown (KeyCode.Space)) {
				player.OnJumpInputDown ();
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				player.OnJumpInputUp ();
			}
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift)) {
				player.moveSpeed = player.runSpeed;
			} 
			else {
				player.moveSpeed = Player.defaultSpeed;
			}
		}
		else {
			directionalInput.x = 0;
			directionalInput.y = 0;
			player.SetDirectionalInput (directionalInput);
		}


		if (Input.GetKeyDown (KeyCode.Escape))
			SceneManager.LoadScene ("High Scores");

	
	}
}
