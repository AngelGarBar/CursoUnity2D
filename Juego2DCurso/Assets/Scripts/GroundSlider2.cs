using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlider2 : MonoBehaviour {

	public float scrollSpeed;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Mueve el offset del material del suelo, creando el efecto de movimiento del suelo
	void Update () {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex",new Vector2(offset, 0.0f));
	}
}
