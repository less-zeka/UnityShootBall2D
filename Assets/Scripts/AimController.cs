using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

	int width = 0;
	int height = 0;
	Vector3 force;
	BulletController bulletController;

	// Use this for initialization
	void Start () {
		bulletController = GameObject.FindObjectOfType<BulletController> ();
		force = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			height++;
			force = new Vector3( 0.2f, height, 0f );
			transform.localScale = force / 10f;		
		}
		if (Input.GetKey (KeyCode.Return)) {
			bulletController.Shoot (force);
		}
	}

}
