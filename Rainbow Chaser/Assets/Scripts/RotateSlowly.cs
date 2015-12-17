using UnityEngine;
using System.Collections;

public class RotateSlowly : MonoBehaviour {

	public float rotationSpeed = 5.0f;

	private GameObject attached;

	// Use this for initialization
	void Start() {
		attached = this.gameObject;
	}

	// Update is called once per frame
	void Update() {
		//Rotates the object a little alone the X axis every frame
		attached.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
	}
}
