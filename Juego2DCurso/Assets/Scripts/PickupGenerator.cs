using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour {

	public GameObject originalPickup;
	public float genProbability;
	// Use this for initialization
	void Start () {
		
	}
	

	void Update()
	{
		DecideIfPickupIsGenerated();
	}
	//Genera aleatoriamente monedas
	private void DecideIfPickupIsGenerated()
	{
		float rand = Random.Range(0.0f, 100.0f);
		if (rand < genProbability)
		{
			GameObject.Instantiate(originalPickup, transform.position, transform.rotation);
		}
	}
}
