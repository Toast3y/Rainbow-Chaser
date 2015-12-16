using UnityEngine;
using System.Collections;

public class ControllerBehaviour : MonoBehaviour {

	//Moves the attached "ship" gameObject using the scrollwheel.
	GameObject ship;
	Animator animator;

	public GameObject animationObject;
	public float moveSpeed = 2.5f;


	// Use this for initialization
	void Start () {
		//Script will act on only the object it is attached to, to allow reuse of code
		ship = this.gameObject;

		animator = animationObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetAxis("Mouse ScrollWheel") < 0 && ship.transform.position.x < 17.0f){
			//Moves ship downwards (to the right)
			animator.Play("bankRight");
			ship.transform.Translate(moveSpeed, 0 , 0);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0 && ship.transform.position.x > -7.0f) {
			//Moves ship upwards (to the left)
			animator.Play("bankLeft");
			ship.transform.Translate(-moveSpeed, 0, 0);
		}
	}
}
