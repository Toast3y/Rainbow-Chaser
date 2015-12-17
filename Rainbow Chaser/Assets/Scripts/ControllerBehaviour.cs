using UnityEngine;
using System.Collections;

public class ControllerBehaviour : MonoBehaviour {

	//Moves the attached "ship" gameObject using the scrollwheel.
	GameObject ship;
	Animator animator;

	public GameObject explosion;
	public AudioSource sfx;
	public GameObject upperLayer;
	public GameObject animationObject;
	public float moveSpeed = 3.0f;
	public float lerpSpeed = 10.0f;
	public float upperBound = 17.0f;
	public float lowerBound = -7.0f;

	private bool direction;
	private bool lerp = false;
	private Vector3 startPosition;
	private Vector3 endPosition;

	// Use this for initialization
	void Start () {
		//Script will act on only the object it is attached to, to allow reuse of code
		ship = this.gameObject;

		animator = animationObject.GetComponent<Animator>();

		//Synchronize the ship and coordinate object on startup
		startPosition = ship.transform.position;
		endPosition = ship.transform.position;
	}



	
	// Update is called once per frame
	void Update () {

		//Keep track of y and z coordinate positions so ship does not wobble off center while lerping
		startPosition = ship.transform.position;
		endPosition.y = startPosition.y;
		endPosition.z = startPosition.z;

		//Animation state trigger based on proximity to endPosition
		if ((endPosition.x - startPosition.x) < 0.25f && (endPosition.x - startPosition.x) > -0.25f) {
			animator.SetBool("lerping", false);
		}
		else {
			animator.SetBool("lerping", lerp);
		}


		if (Input.GetAxis("Mouse ScrollWheel") < 0 && startPosition.x < upperBound){
			//Moves ship downwards (to the right)



			//If changing direction, play the opposing animation
			if (direction == true) {
				animator.Play("bankRight");
				direction = false;
			}



			//If already lerping to another space, adds the resulting jump to the end position
			if (lerp == true && endPosition.x > upperBound) {
				endPosition.x = upperBound;
			}
			else if (lerp == true && endPosition.x < upperBound) {

				endPosition.x = endPosition.x + moveSpeed;


				//Ensure resulting value does not exceed upper bound
				if (endPosition.x > upperBound) {
					endPosition.x = upperBound;
				}


			}
			else {
				lerp = true;
				endPosition.x = endPosition.x + moveSpeed;
				animator.Play("bankRight");
				direction = false;


				//Ensure resulting value does not exceed upper bound
				if (endPosition.x > upperBound) {
					endPosition.x = upperBound;
				}


			}



		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0 && startPosition.x > lowerBound) {
			//Moves ship upwards (to the left)
			//animator.Play("bankLeft");

			//If changing direction, play the opposing animation
			if (direction == false) {
				animator.Play("bankLeft");
				direction = true;
			}

			//If already lerping to another space, adds the resulting jump to the end position.
			if (lerp == true && endPosition.x < lowerBound) {
				endPosition.x = lowerBound;
			}
			else if (lerp == true && endPosition.x > lowerBound) {

				endPosition.x = endPosition.x - moveSpeed;

				//Ensure resulting value does not exceed lower bound
				if (endPosition.x < lowerBound) {
					endPosition.x = lowerBound;
				}
			}
			else {

				lerp = true;
				endPosition.x = endPosition.x - moveSpeed;
				animator.Play("bankLeft");
				direction = true;

				//Ensure resulting value does not exceed lower bound
				if (endPosition.x < lowerBound) {
					endPosition.x = lowerBound;
				}
			}
		}




		//Lerp to the new coordinates
		if (lerp == true){
			//if finished moving, end lerping
			if ((endPosition.x - startPosition.x) < 1.0f && (endPosition.x - startPosition.x) > -1.0f) {
				lerp = false;
			}
			else {
				//Lerp to the new coordinates given
				ship.transform.position = Vector3.Lerp(startPosition, endPosition, lerpSpeed * Time.deltaTime);
			}
		}




	}


	void OnCollisionEnter(Collision col) {
		//Destroys the ship if it collides with a cube
		if (col.gameObject.name == "Cube(Clone)") {
			//Play destroy animations
			GameObject kaboom = (GameObject)Instantiate(explosion, ship.transform.position, ship.transform.rotation);
			sfx.Play();
			//Destroy the ship
			Destroy(ship);
			Destroy(col.gameObject);
		}
	}

}
