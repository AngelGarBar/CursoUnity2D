using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text vidas_txt;
	public Text monedas_txt;
	public Text record_txt;
	public Text score_txt;

	public GameObject gameOverPanel;

	public Player pc;
	// Use this for initialization
	void Start () {
		gameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		vidas_txt.text = pc.Life.ToString();
		monedas_txt.text = pc.Coins.ToString();

		if(pc.Life <= 0 && gameOverPanel.activeSelf == false)
		{
			gameOverPanel.SetActive(true);
			record_txt.text = PlayerPrefs.GetInt("Coins").ToString();
			score_txt.text = pc.Coins.ToString();
		}
	}

	public void resetGame()
	{
		SceneManager.LoadScene("Main");
	}
}
