using UnityEngine;
using System.Collections;

public class ControllerBehaviour : MonoBehaviour {

	//Moves the attached "ship" gameObject using the scrollwheel
	GameObject ship;

	// Use this for initialization
	void Start () {
		//Script will act on only the object it is attached to, to allow reuse of code
		ship = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0){

		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			//ship.transform.Translate
		}
	}
}
