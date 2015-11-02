using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour {
	private GameObject scoreDisplay;
	private int totalPoints;

	// Use this for initialization
	void Start () {
		//scoreDisplay = get
		totalPoints = 0;
		scoreDisplay = GameObject.Find("Score Text");
	}
	
	// Update is called once per frame
	void Update () {
		updateScoreDisplay (totalPoints);
	}

	void updateScoreDisplay (int points){
		if(scoreDisplay != null){
			Text display = scoreDisplay.GetComponent<Text>();
			display.text = ("SCORE - " + totalPoints);
		}
	}

	public void addPoints(int earnedPoints){
		totalPoints += earnedPoints;
	}
}
