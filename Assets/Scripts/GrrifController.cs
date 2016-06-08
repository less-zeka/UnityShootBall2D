using UnityEngine;
using System.Collections;

public class GrrifController : MonoBehaviour {

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		var url = "http://grrif.ice.infomaniak.ch/grrif-high.mp3";
		//url = "http://grrif.ice.infomaniak.ch:80/grrif-64.aac";
		//url = "http://statslive.infomaniak.com/playlist/grrif/grrif-64.aac/playlist.m3u";
		var www = new WWW (url);  // start a download of the given URL
		audioSource.clip = www.GetAudioClip(false, true); // 2D, streaming
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
