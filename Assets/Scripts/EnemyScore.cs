using UnityEngine;
using System.Collections;

public class EnemyScore : MonoBehaviour {
	public int points = 100;
	private ScoreHandler scoreHandler;

	// Use this for initialization
	void Start () {
		scoreHandler = GameObject.Find("ScoreHandler").GetComponent<ScoreHandler>();
		if (scoreHandler == null) {
			Debug.LogError("Score system failed to initialize.");
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void givePoints(){
		scoreHandler.addPoints (points);
	}
}
