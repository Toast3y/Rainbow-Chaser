using UnityEngine;
using System.Collections;

public class SelfDestructSequence : MonoBehaviour {

	//Attached object dies once the time limit is reached

	private float timePassed;

	private float timeToDie = 15.0f;

	private GameObject attached;

	// Use this for initialization
	void Start () {
		attached = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		timePassed = timePassed + Time.deltaTime;

		//Once time is up, destroy the attached object
		if (timePassed > timeToDie) {
			Destroy(attached);
		}

	}
}
