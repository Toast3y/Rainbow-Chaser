using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracking : MonoBehaviour {

	public GameObject scoreCanvas;
	int totalScore;
	Text score;

	// Use this for initialization
	void Start () {
		score = scoreCanvas.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		totalScore++;

		int calculatedScore = totalScore / 60;

		score.text = calculatedScore.ToString();
	
	}
}
