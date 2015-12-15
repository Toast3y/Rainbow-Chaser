using UnityEngine;
using System.Collections;

public class ControllerBehaviour : MonoBehaviour {

	//Moves the attached "ship" gameObject using the scrollwheel, and controls speed.

	//Determines starting game speed
	public float speed = 5.0f;
	GameObject ship;

	

	// Use this for initialization
	void Start () {
		//Script will act on only the object it is attached to, to allow reuse of code
		ship = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		ship.transform.Translate(0, 0, speed * Time.deltaTime);

		if (Input.GetAxis("Mouse ScrollWheel") > 0){
			//ship.transform.Translate
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			//ship.transform.Translate
		}
	}
}
