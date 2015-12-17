using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour {

	//Determines starting game speed
	public float speed = 5.0f;

	//Determines frequency of cube spawns
	public float cubeFrequency = 180.0f;
	public float upperBound = 17.0f;
	public float lowerBound = -7.0f;
	public GameObject ship;
	public GameObject Cube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Move ship to the right according to game speed
		transform.Translate(0, 0, speed * Time.deltaTime);

		//Check to see if another block should be made
		var framesPassed = Time.frameCount % (cubeFrequency / speed);

		//If it falls on zero / a certain range, spawn a cube
		if (framesPassed == 0) {
			GameObject newcube = GameObject.Instantiate(Cube);

			Vector3 newPos = new Vector3(Random.Range(lowerBound, upperBound) ,5.0f,ship.transform.position.z + 60.0f);
			newcube.AddComponent(typeof(SelfDestructSequence));

			newcube.transform.position = newPos;
		}
	}
}
