using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;

public class MasterCube : MonoBehaviour {

	//Master Cube spawning behaviour
	//Spawns Cube clones using relative ship position, draws vectors around them using Vectrosity
	//Despawns cubes after a certain period of time.

	public GameObject VecCanvas;

	VectorLine cubeLine;


	// Use this for initialization
	void Start () {
		//Generate position in game world according to player and set it

		//Draw vectors in vectrosity according to cube translation
		var cubeLinePoints = new List<Vector3>() { new Vector3(-1.5f, 1.5f, -1.5f), new Vector3(-1.5f, 1.5f, 1.5f), new Vector3(1.5f, 1.5f, 1.5f), new Vector3(-1.5f, 1.5f, 1.5f), new Vector3(1.5f, 1.5f, -1.5f), new Vector3(1.5f, 1.5f, 1.5f), new Vector3(1.5f, 1.5f, -1.5f), new Vector3(-1.5f, 1.5f, -1.5f), new Vector3(1.5f, -1.5f, -1.5f), new Vector3(1.5f, 1.5f, -1.5f), new Vector3(-1.5f, 1.5f, -1.5f), new Vector3(-1.5f, -1.5f, -1.5f), new Vector3(-1.5f, -1.5f, 1.5f), new Vector3(-1.5f, 1.5f, 1.5f), new Vector3(1.5f, 1.5f, 1.5f), new Vector3(1.5f, -1.5f, 1.5f), new Vector3(-1.5f, -1.5f, 1.5f), new Vector3(-1.5f, -1.5f, -1.5f), new Vector3(1.5f, -1.5f, -1.5f), new Vector3(-1.5f, -1.5f, -1.5f), new Vector3(1.5f, -1.5f, -1.5f), new Vector3(1.5f, -1.5f, 1.5f), new Vector3(-1.5f, -1.5f, 1.5f), new Vector3(1.5f, -1.5f, 1.5f) };
		cubeLine = new VectorLine("Line", cubeLinePoints, 1.0f);
		cubeLine.SetCanvas(VecCanvas);
		cubeLine.SetColor(Color.green);
		cubeLine.Draw();
		
		//Select the line colour
		//cubeLine.SetColor(Color.green);

		//cubeLine.drawTransform = this.gameObject.transform;
		
    }
	
	// Update is called once per frame
	void Update () {
		//cubeLine.Draw3D();
	}
}
