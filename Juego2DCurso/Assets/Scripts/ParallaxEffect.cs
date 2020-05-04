using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {

	public GameObject[] backgrounds;
	public float[] bgSpeed;
	public float[] size;

	public Renderer[] Waves;
	public float[] waveSpeed;
	
	void Start () {
		
	}
	
	
	void Update () {
		MoveWaves();
		MoveBG();
	}
	//Movimiento de elementos de fondo
	private void MoveBG()
	{
		for (int i = 0; i < backgrounds.Length; i++)
		{
			if (Mathf.Abs(backgrounds[i].transform.localPosition.x) >= size[i])
			{
				backgrounds[i].transform.localPosition = new Vector3(0.0f, backgrounds[i].transform.localPosition.y,transform.localPosition.z);
			}
			else
			{
				float offset = Time.deltaTime * bgSpeed[i];
				backgrounds[i].transform.localPosition += new Vector3(offset, 0.0f);
			}
		}
	}

	private void MoveWaves()
	{
		for (int i = 0; i < Waves.Length; i++)
		{
			float offset = Time.time * waveSpeed[i];
			Waves[i].material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
		}
		
	}
}
