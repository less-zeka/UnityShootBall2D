using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private bool IsShooting = false;
	private Rigidbody rb;
	private Rigidbody rigidBody {
		get{ 
			if (rb == null) {
				rb = GetComponent<Rigidbody> ();
			}
			return rb;
		}
	}
		
	public void Init(){
		rigidBody.isKinematic = true;
		gameObject.SetActive (false);
		transform.position = new Vector3 ();
		IsShooting = false;
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public void StartShoot(Vector3 position){
		if (!IsShooting) {
			transform.position = position;
			IsShooting = true;
			rigidBody.isKinematic = true;
			gameObject.SetActive (true);
		}
	}

	public void Shoot(Vector3 force){
		rigidBody.isKinematic = false;
		rigidBody.AddForce(force);
	}
}
