using UnityEngine;
using System.Collections;

public class HitObjectController : MonoBehaviour {

	[HideInInspector]  
	public GameObject Instance;

	void OnCollisionEnter(Collision collision) {
		Destroy (this.gameObject);
	}
}