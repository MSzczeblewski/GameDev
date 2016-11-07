using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class CoinSpawner : MonoBehaviour {


	public AudioSource hitNoise;
	public GameObject coinSpawnPoint;
	public Object[] coinPrefabs;


	void Start () {
		this.SpawnCoin ();	
	}

	void SpawnCoin(){
		int random = Random.Range (0, coinPrefabs.Length);
		GameObject coin = Object.Instantiate 
			(coinPrefabs [(Random.Range (0, coinPrefabs.Length))], 
			coinSpawnPoint.transform.position, 
			coinSpawnPoint.transform.rotation) as GameObject;

		hitNoise.Play ();
		coin.GetComponent<Rigidbody2D> ().AddForce (new Vector2 ((Random.Range (-120, 120)), 700));
		
	}
}
