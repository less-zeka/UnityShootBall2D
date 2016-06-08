using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	public GameObject ball;
	private BallController ballController;
	private int level = 1;
	private bool levelDone = false;

	public GameObject HitObjectPrefab;             // Reference to the prefab the players will control.
	public HitObjectController[] hitObjects = new HitObjectController[3];   

	//Awake is always called before any Start functions
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);   
		}

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);

		if (ball == null) {
			Instantiate (ball, new Vector3 (0, 0, 0), Quaternion.identity);
		}
		ballController = ball.GetComponent<BallController> ();// GetComponent<BallController>();
		//InitGame ();
	}

	void Start ()
	{
		StartCoroutine (GameLoop ());
	}

	// This is called from start and will run each phase of the game one after another.
	private IEnumerator GameLoop ()
	{
		// Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
		yield return StartCoroutine (RoundStarting ());

		// Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
		yield return StartCoroutine (RoundPlaying ());

		// Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
		yield return StartCoroutine (RoundEnding ());

		// This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
		if (levelDone) {
			// If there is a game winner, restart the level.
			Application.LoadLevel (Application.loadedLevel);
		} else {
			// If there isn't a winner yet, restart this coroutine so the loop continues.
			// Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
			StartCoroutine (GameLoop ());
		}
	}

	private IEnumerator RoundStarting ()
	{
		// As soon as the round starts reset the game
		ResetGame();

		// ...return on the next frame
		yield return null;
	}

	private IEnumerator RoundPlaying ()
	{
		// While there is not one tank left...
		while (!AllHitObjectsGone())
		{
			// ... return on the next frame.
			yield return null;
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "Level: "+ level.ToString());
	}
	private IEnumerator RoundEnding ()
	{
		level ++;
		// Wait for the specified length of time until yielding control back to the game loop.
		yield return 0;
	}

	private void SpawnHitObjects()
	{
		// For all the tanks...
		for (int i = 0; i < 3; i++)
		{
			// ... create them, set their player number and references needed for control.
			Instantiate(HitObjectPrefab, new Vector3(-2+i*level/2,-2+i*level/2,0), new Quaternion());
			//hitObjects[i].Setup();
		}
	}

	private bool AllHitObjectsGone(){
		return GameObject.FindGameObjectsWithTag ("HitObject").Length <= 0;
	}

	private void DestroyAllHitObjects(){
		foreach (var gameObject in GameObject.FindGameObjectsWithTag ("HitObject")) {
			Destroy(gameObject);
		}
	}

	void ResetGame ()
	{
		DestroyAllHitObjects ();
		firstTouch = true;
		ballController.Init ();
		SpawnHitObjects ();
	}
	
	// Update is called once per frame
	Vector3 shotStart;
	Vector3 shotEnd;
	bool firstTouch = true;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			ResetGame ();
		}
		if (Input.GetMouseButtonDown (0)) {
			var shotPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			shotPosition.z = 0;
			ballController.StartShoot (shotPosition);
			if (firstTouch) {
				shotStart = Input.mousePosition;
				firstTouch = false;
			} 
		}
		if (shotStart.magnitude > 0) {
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 startWorldPos = Camera.main.ScreenToWorldPoint (shotStart); // converting
			Vector3 endWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition); // converting

			Debug.DrawLine (startWorldPos, endWorldPos, Color.red);
		}
		if (Input.GetMouseButtonUp (0)) {
			shotEnd = Input.mousePosition;

			var force = shotStart - shotEnd;
			ballController.Shoot (force);
		}
//		foreach (var touch in Input.touches) {
//			if (touch.phase == TouchPhase.Began) {
//				ballController.StartShoot ();
//			}
//			if (touch.phase == TouchPhase.Ended) {
//				var force = new Vector3 (100, 10, 0);
//				ballController.Shoot (force);
//			}
//		}
	}
}