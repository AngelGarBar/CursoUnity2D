using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlider : MonoBehaviour {

	
	public float groundSize;

	private Camera mainCamera;
	//Asigna la camara principal a la variable
	void Start () {
		mainCamera = Camera.main;
	}
	
	// Mueve el suelo en funcion de la posicion de la camara
	void Update () {
		if(groundSize<= (mainCamera.transform.position- transform.position).magnitude)
		{
			transform.position = new Vector3(mainCamera.transform.position.x, transform.position.y, transform.position.z);
		}
	}
}
