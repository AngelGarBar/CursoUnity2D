using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGeneration : MonoBehaviour {


	public GameObject orEnemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DecideIfEnemyIsGenerated();
	}

	private void DecideIfEnemyIsGenerated()
    {
		float rand = Random.Range(0.0f, 100.0f);
		if(rand < 1.0f)
		{
			GameObject.Instantiate(orEnemy, transform.position, transform.rotation);
		}
    }
}
