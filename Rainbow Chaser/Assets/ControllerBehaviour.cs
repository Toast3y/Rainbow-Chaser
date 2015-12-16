using UnityEngine;
using System.Collections;

public class ControllerBehaviour : MonoBehaviour {

	//Moves the attached "ship" gameObject using the scrollwheel.
	GameObject ship;
	Animator animator;

	public float moveSpeed = 1.0f;


	// Use this for initialization
	void Start () {
		//Script will act on only the object it is attached to, to allow reuse of code
		ship = this.gameObject;

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetAxis("Mouse ScrollWheel") < 0 && ship.transform.position.x < 18.0f){
			//Moves ship downwards
			ship.transform.Translate(moveSpeed, 0 , 0);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0 && ship.transform.position.x > -8.0f) {
			//Moves ship upwards
			ship.transform.Translate(-moveSpeed, 0, 0);
		}
	}
}
