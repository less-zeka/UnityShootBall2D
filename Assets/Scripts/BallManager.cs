using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public void StartShoot(){
		this.enabled = !enabled;
	}

	public void Shoot(Vector3 force){
		rb.isKinematic = false;
		rb.AddForce(force);
	}
}
