using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject playerLocation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//var cameraPosition = new Vector3 (playerLocation.transform.position.x, playerLocation.transform.position.y, transform.position.z);
		var cameraPosition = new Vector3 (playerLocation.transform.position.x, transform.position.y, transform.position.z);

		transform.position = cameraPosition;
		// = new Vector3 (playerLocation.transform.position.x, transform.po, 0);
		//transform.position.x = playerLocation.transform.position.x;

	}
}
