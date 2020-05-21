using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text vidas_txt;
	public Text monedas_txt;

	public Player pc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		vidas_txt.text = pc.Life.ToString();
		monedas_txt.text = pc.Coins.ToString();
	}
}
