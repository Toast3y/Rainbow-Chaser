using UnityEngine;
using Vectrosity;
using System.Collections;

public class ShapeDrawingManager : MonoBehaviour {

	private float timer = 0.0f;
	private GameObject VectorCanvas;

	// Use this for initialization
	void Start () {
		VectorCanvas = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		

	}


	public void CallForShapes() {
		//Decide when to draw a shape against the screen
		timer = timer + Time.deltaTime;

		if (timer > 20.0f) {
			DrawShape(Random.Range(3, 5));
		}
	}


	//Draw vector shapes against the canvas while the game is being played
	public void DrawShape(int numShapes) {

		//var 





		//Recursively draw shapes unless the limit is reached
		if (numShapes != 0) {
			DrawShape(numShapes - 1);
		}
		else {
			//Do nothing / resolve stack
		}
	}
}
