using UnityEngine;
using System.Collections;

public class PlayerLocationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
 	// don't rotate!
	void Update () {
			transform.eulerAngles = new Vector3(0, 0, 0);
	}
}
