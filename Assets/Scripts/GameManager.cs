using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Transform spherePreFab; 

	private Vector3 spherePos; 
	private Vector3 sphereRotation; 

	// Use this for initialization
	void Start () {
		spherePos = new Vector3(0f, 0f, 0f);
		//sphereRotation = transform.rotation (0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
			Instantiate (spherePreFab, spherePos, transform.rotation);
			spherePreFab.GetComponent<Pathmaker>().resetTiles = 0; 
		}
	}
}
