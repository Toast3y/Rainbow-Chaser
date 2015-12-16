using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour {

	//Determines starting game speed
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Move ship to the right according to game speed
		transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
