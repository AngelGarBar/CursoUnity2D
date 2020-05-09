using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject attackOriginal;
	public GameObject attackPosition;

	public Animator animador;

	private bool jumping;
	private bool attacking;
	private int coins;

	private int life;
	void Start () {
		jumping = false;
		attacking = false;
		life = 3;
		coins = 0;
	}
	
	// Se programa el movimiento en las distintas teclas
	void Update () {
		if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-0.2f,0.0f));
		}
		else
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(0.2f, 0.0f));
		}

		if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
		{
			if(jumping == false)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
				jumping = true;
				animador.SetBool("Jumping", jumping);
				
			}
		}
		//Instancia el objeto de ataque en la posicion de ataque establecida
		//Se crea un delay usando el booleano attacking y el metodo Invoke para ejecutar el metodo StopAttacking tras un retraso
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if(attacking == false)
			{
				GameObject.Instantiate(attackOriginal, attackPosition.transform.position, attackPosition.transform.rotation);
				attacking = true;
				animador.SetTrigger("Attacking");
				Invoke("StopAttacking", 0.5f);
			}
			
		}
	}

	private void StopAttacking()
	{
		attacking = false;
	}

	//Solo cuando el jugador vuelve a colisionar con el suelo se le vuelve a permitir saltar
	//Se quita vida si el jugador colisiona con un enemigo
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			jumping = false;
			animador.SetBool("Jumping", jumping);
		}

		if(col.gameObject.tag == "Enemy")
		{
			col.gameObject.SetActive(false);
			Destroy(col.gameObject,0.5f);
			life--;
			animador.SetTrigger("Damaged");
			if (life <= 0)
			{
				Debug.Log("El jugador ha muerto");
				//gameObject.SetActive(false);
				animador.SetBool("Dead", true);
				//Almacena permanentemente la puntuación máxima entre partidas
				int lastRecord = PlayerPrefs.GetInt("Coins");
				if (PlayerPrefs.HasKey("Coins")==false)
				{
					//No hay record guardado
					PlayerPrefs.SetInt("Coins", coins);
					Debug.Log("NEW RECORD! " + coins);
				}
				else
				{
					//Si hay record guardado
					if (lastRecord < coins)
					{
						PlayerPrefs.SetInt("Coins", coins);
						Debug.Log("NEW RECORD! "+coins);
					}
				}
				
			}
		}
	}
	//Controla la recogida de monedas y la puntuacion
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Pickup")
		{
			col.gameObject.SetActive(false);
			Destroy(col.gameObject, 0.5f);
			coins++;
			Debug.Log("Coins: " + coins);
		}
	}
}
