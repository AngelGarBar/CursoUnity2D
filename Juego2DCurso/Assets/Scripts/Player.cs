using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private bool jumping;
	private int life;
	void Start () {
		life = 3;
	}
	
	// Se programa el movimiento en las distintas teclas
	void Update () {
		if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-0.1f,0.0f));
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(0.1f, 0.0f));
		}

		if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
		{
			if(jumping == false)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 300.0f));
				jumping = true;
			}
		}
	}

	//Solo cuando el jugador vuelve a colisionar con el suelo se le vuelve a permitir saltar
	//Se quita vida si el jugador colisiona con un enemigo
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			jumping = false;
		}

		if(col.gameObject.tag == "Enemy")
		{
			col.gameObject.SetActive(false);
			Destroy(col.gameObject,0.5f);
			life--;
			if (life <= 0)
			{
				Debug.Log("El jugador ha muerto");
				gameObject.SetActive(false);
			}
		}
	}
}
