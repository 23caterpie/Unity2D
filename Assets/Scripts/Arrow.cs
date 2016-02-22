using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameObject.transform.position.x <= -19.1)
        {
            Vector3 newPosition = gameObject.transform.position;
            newPosition.y = (Random.value * 4) - 2;
        }
	}
}
