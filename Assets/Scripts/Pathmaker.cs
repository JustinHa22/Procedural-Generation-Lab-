using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Pathmaker : MonoBehaviour {

	public Transform floorPrefab, spikePreFab, treasureChestPreFab;
	public Transform pathmakerSpherePrefab; 
	public int pathmakerLifeTime = 0; 
	public int tilesPerPathmaker; 
	public int rotationDecider; 
	public float spikesOrFloor; 
	public static int numberOfTiles; 
	public int resetTiles; 

	public static int numberOfPathmakers = 0;

	void Start(){

		tilesPerPathmaker = Random.Range(35, 50);

		rotationDecider = Random.Range (1, 4);

		numberOfTiles = resetTiles;

	}

	// Update is called once per frame
	void Update () {
		if ( numberOfTiles < 500) {
			float spikesOrFloor = Random.value;
			float randomNumber = Random.value;
			if (randomNumber < 0.25f) {
				transform.Rotate (0f, rotationDecider * 90f, 0f);
			} else if (randomNumber > 0.25f && randomNumber < 0.5f) {
				transform.Rotate (0, rotationDecider * -90f, 0f);
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

		if (pathmakerLifeTime == tilesPerPathmaker || numberOfTiles > 499){
			numberOfPathmakers -= 1;
			Debug.Log (numberOfTiles);
			Destroy (gameObject);
		}
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 

		RaycastHit rayHit = new RaycastHit (); 
	}
}
