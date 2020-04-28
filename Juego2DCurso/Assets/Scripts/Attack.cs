using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			col.gameObject.SetActive(false);
			Destroy(col.gameObject, 0.5f);
			gameObject.SetActive(false);
			Destroy(gameObject, 0.1f);
		}
	}
}
