using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

	private bool push = false;
	private bool pushUpwards = false;
	private float timer = 0.0f;
	private float moveTimer = 0.0f;
	private float force = 0.0f;

	private Rigidbody rigidBody;
	private GameObject cube;

	// Use this for initialization
	void Start () {

		cube = this.gameObject;
		rigidBody = cube.GetComponent<Rigidbody>();
		force = Random.Range(-5.0f, 5.0f);

		//Calculate time to move at
		moveTimer = Random.Range(4.5f, 8.5f);

		//Determine what vector to push the cube in. Has a 10% chance to push a cube upwards instead, because it looks hilarious!
		if (Random.Range(0, 100) < 5) {
			pushUpwards = true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		timer = timer + Time.deltaTime;

		if (timer > moveTimer) {
			push = true;
		}

		//Apply force in direction
		if (push == true) {

			if (pushUpwards == true) {
				rigidBody.AddForce(transform.up * force);
			}
			else {
				rigidBody.AddForce(transform.right * force);
			}
			
			
		}
	}
}
