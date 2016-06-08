using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Shoot(Vector3 force){
		rb.isKinematic = false;
		rb.AddForce(force);
	}
}
