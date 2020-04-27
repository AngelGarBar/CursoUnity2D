using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeletion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Elimina a un enemigo tras un tiempo determinado 
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			col.gameObject.SetActive(false);
			Destroy(col.gameObject, 0.5f);
		}
	}
}
