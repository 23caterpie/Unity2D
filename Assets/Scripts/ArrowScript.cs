using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	//The arrow's horizontal speed - Can change this in the Inspector
	public float hSpeed = 30;

	//Where the arrow starts from so we can respawn a new arrow near that location.
	Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		startingPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = gameObject.transform.position;

		//Make sure you scale by Time.deltaTime when doing animation. If you don't, you program will run at different speeds depending on 
		// the speed of the underlying computer.
		newPosition.x -= hSpeed * Time.deltaTime;
		gameObject.transform.position = newPosition;
		if (newPosition.x < -18) { // Bad! Hardcoded the edge of the screen. May want to think about either making this a parameter, a constant, or derive it from the scene
			MakeNewArrow ();
			Destroy (gameObject);
		}
	}

	void MakeNewArrow() {
		//Another hardcoded range. Goes between -3 and +3 on the y-axis when the arrow respawns
		startingPosition.y = Random.value * 6 - 3;
		Object newArrow = Instantiate (this.gameObject, startingPosition, Quaternion.identity);
		//The name gets a little crazy if you don't do this. Like: arrow(Clone)(Clone)(Clone)(CLone)...
		newArrow.name = "arrow";
	}
}
