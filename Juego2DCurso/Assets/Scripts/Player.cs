using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	
	void Start () {
		
	}
	
	// Se programa el movimiento en las distintas teclas
	void Update () {
		if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-0.1f,0.0f));
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(0.1f, 0.0f));
		}

		if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,60.0f));
		}
	}
}
