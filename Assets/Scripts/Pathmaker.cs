using UnityEngine;
using System.Collections;

public class Pathmaker : MonoBehaviour {

	private int counter = 0;
	public Transform floorPrefab;
	public Transform pathmakerSpherePrefab; 

	// Update is called once per frame
	void Update () {
		if (counter < 50) {
			float randomNumber = Random.value;
			if (randomNumber < 0.25f) {
				transform.Rotate (0f, 90f, 0f);
			} else if (randomNumber > 0.25f && randomNumber < 0.5f) {
				transform.Rotate (0, -90f, 0f);
			} else if (randomNumber > 0.99f && randomNumber < 1.0f) {
				Instantiate (pathmakerSpherePrefab, transform.position, transform.rotation);
			}
			Instantiate (floorPrefab, transform.position, transform.rotation);
			transform.Translate (0f, 0f, 5f);
			counter += 1;
		} else {
			Destroy (gameObject);
		}
	}
}
