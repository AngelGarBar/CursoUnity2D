using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject orPlatform;
	public float genProbability;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DecideIfPlatformIsGenerated();
	}

	private void DecideIfPlatformIsGenerated()
	{
		float rand = Random.Range(0.0f, 100.0f);
		if (rand < genProbability)
		{
			GameObject.Instantiate(orPlatform, transform.position, transform.rotation);
		}
	}
}
