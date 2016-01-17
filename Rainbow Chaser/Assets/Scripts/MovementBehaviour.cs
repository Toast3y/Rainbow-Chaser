using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovementBehaviour : MonoBehaviour {

	//Determines starting game speed
	public float speed = 5.0f;
	public float speedOT = 0.05f;
	public float cubeFrequencyOT = 1.0f;
	public int cubesMadeOT = 50;
	public int difficultyThreshold = 150;

	//Determines frequency of cube spawns
	public float cubeFrequency = 500.0f;
	public float upperBound = 17.0f;
	public float lowerBound = -7.0f;
	public GameObject ship;
	public GameObject Cube;
	//public GameObject VectorCanvas;

	private int cubesMade;
	private int frameCounter = 0;
	private bool deathState = false;
	private float deathCounter = 0.0f;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Move ship to the right according to game speed
		transform.Translate(0, 0, speed * Time.deltaTime);

		//Count the number of frames passed per second
		frameCounter++;

		//Check if dead. If dead, transition to main menu after 5 seconds
		if (deathState) {
			deathCounter = deathCounter + Time.deltaTime;

			if (deathCounter > 5.0f) {
				SceneManager.LoadScene("Menu");
			}
		}

		//Check to see if another block should be made
		var framesPassed = frameCounter % (cubeFrequency / speed);

		//If it falls on zero / a certain range, spawn a cube and increase game speed
		if (framesPassed >= 0.0f && framesPassed <= 1.0f) {
			//Increase speed and spawn rate over time
			//Add to speed for every block
			speed = speed + speedOT;
			cubesMade++;

			//Draw cube vectors on screen if enough cubes have spawned
			//if (cubesMade % cubesMadeOT / 2 == 0) {
			//	ShapeDrawingManager reference = VectorCanvas.GetComponent<ShapeDrawingManager>();
			//	reference.CallForShapes();
			//}


			//If enough cubes have spawned, reduce frequency to increase spawn rate, up to 270
			if (cubesMade % cubesMadeOT == 0 && cubeFrequency > 350.0f) {
				cubeFrequency = cubeFrequency - cubeFrequencyOT;
			}


			GameObject newcube = GameObject.Instantiate(Cube);

			Vector3 newPos = new Vector3(Random.Range(lowerBound, upperBound) ,5.0f,ship.transform.position.z + 60.0f);
			Quaternion newRot = Random.rotation;
			newcube.AddComponent(typeof(SelfDestructSequence));



			


			//Adds difficulty by allowing cubes to move after they have spawned.
			//Only adds it to certain cubes, to maintain surprise.
			if ((cubesMade > difficultyThreshold) && (Random.Range(0,100) < 34)) {
				newcube.AddComponent(typeof(RandomMove));
			}

			newcube.transform.position = newPos;
			newcube.transform.rotation = newRot;


			//Spawns new cube right beside old cube at periodic intervals
			//Collision detection on cubes can cause the cubes to move around in unique ways. This code encourages this by spawning a cube beside it
			//Discovered by a bug that occasionally spawns two cubes inside one another
			if (Random.Range(0, 100) < 10) {
				GameObject sideCube = GameObject.Instantiate(Cube);
				sideCube.AddComponent(typeof(SelfDestructSequence));
				sideCube.transform.position = newPos;
			}
		}
	}


	public void deathTrigger() {
		deathState = true;
	}
}
