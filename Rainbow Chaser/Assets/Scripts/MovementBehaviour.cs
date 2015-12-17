using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovementBehaviour : MonoBehaviour {

	//Determines starting game speed
	public float speed = 5.0f;
	public float speedOT = 0.005f;
	public float cubeFrequencyOT = 1.0f;
	public int cubesMadeOT = 50;

	//Determines frequency of cube spawns
	public float cubeFrequency = 360.0f;
	public float upperBound = 17.0f;
	public float lowerBound = -7.0f;
	public GameObject ship;
	public GameObject Cube;

	private int cubesMade;
	private bool deathState = false;
	private float deathCounter = 0.0f;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Move ship to the right according to game speed
		transform.Translate(0, 0, speed * Time.deltaTime);

		//Check if dead. If dead, transition to main menu after 5 seconds
		if (deathState) {
			deathCounter = deathCounter + Time.deltaTime;

			if (deathCounter > 5.0f) {
				SceneManager.LoadScene("Menu");
			}
		}

		//Check to see if another block should be made
		var framesPassed = Time.frameCount % (cubeFrequency / speed);

		//If it falls on zero / a certain range, spawn a cube and increase game speed
		if (framesPassed >= 0.0f && framesPassed <= 1.0f) {
			//Increase speed and spawn rate over time
			//Add to speed for every block
			speed = speed + speedOT;
			cubesMade++;


			//If enough cubes have spawned, reduce frequency
			if (cubesMade % cubesMadeOT == 0 && cubeFrequency > 270.0f) {
				cubeFrequency = cubeFrequency - cubeFrequencyOT;
			}


			GameObject newcube = GameObject.Instantiate(Cube);

			Vector3 newPos = new Vector3(Random.Range(lowerBound, upperBound) ,5.0f,ship.transform.position.z + 60.0f);
			newcube.AddComponent(typeof(SelfDestructSequence));

			newcube.transform.position = newPos;
		}
	}


	public void deathTrigger() {
		deathState = true;
	}
}
