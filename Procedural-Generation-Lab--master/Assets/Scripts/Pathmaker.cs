﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Pathmaker : MonoBehaviour {

	public Transform floorPrefab, spikePreFab, treasureChestPreFab;
	public Transform pathmakerSpherePrefab; 
	public int pathmakerLifeTime = 0; 
	public int tilesPerPathmaker; 
	public float spikesOrFloor; 
	public static int numberOfTiles; 

	public static int numberOfPathmakers = 0;

	void Start(){

		tilesPerPathmaker = Random.Range(35, 50);

		spikesOrFloor = Random.Range (0f, 1f);

	}

	// Update is called once per frame
	void Update () {
		if ( numberOfTiles < 500) {
			float randomNumber = Random.value;
			if (randomNumber < 0.25f) {
				transform.Rotate (0f, 90f, 0f);
			} else if (randomNumber > 0.25f && randomNumber < 0.5f) {
				transform.Rotate (0, -90f, 0f);
			} else if (randomNumber > 0.70f && numberOfPathmakers < 5) {
				Instantiate (pathmakerSpherePrefab, transform.position, transform.rotation);
				numberOfPathmakers += 1; 
			}

			if (spikesOrFloor < 0.8f) {
				Instantiate (floorPrefab, transform.position, transform.rotation);
				transform.Translate (0f, 0f, 5f);
				numberOfTiles += 1; 
				pathmakerLifeTime += 1;
			} else if (spikesOrFloor >= .8f) {
				Instantiate (spikePreFab, transform.position, transform.rotation);
				transform.Translate (0f, 0f, 5f);
				numberOfTiles += 1; 
				pathmakerLifeTime += 1;
			}
			if (numberOfTiles > 499) {
				Instantiate (treasureChestPreFab, transform.position, transform.rotation);
				transform.Translate (0f, 0f, 5f);
				numberOfTiles += 1; 
				pathmakerLifeTime += 1;
			}
		} 

		if (pathmakerLifeTime == tilesPerPathmaker || numberOfTiles > 498){
			numberOfPathmakers -= 1;
			Debug.Log (numberOfTiles);
			Destroy (gameObject);
			Debug.Log ("working");
		}
	}
}
