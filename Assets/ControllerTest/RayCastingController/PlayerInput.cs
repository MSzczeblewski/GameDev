using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;

	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (!AnimationManager.isPlayerDead)
			player.SetDirectionalInput (directionalInput);
		else {
			directionalInput.x = 0;
			directionalInput.y = 0;
			player.SetDirectionalInput (directionalInput);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();	
	}
}
