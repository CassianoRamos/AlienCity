using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {
	//Declara as variaveis de velocidade e de fisica do tiro
	public  Vector2 speed = new Vector2 (25,0);
	private Rigidbody2D rigidbodytiro;

	//Determina a velocidade do tiro e seu ponto de partida
	void Start () {
		rigidbodytiro = GetComponent<Rigidbody2D>();
		rigidbodytiro.velocity = speed * this.transform.localScale.x;
	}
	//Destroi o tiro ao encostar em objetos com tag "Chao"
	void OnTriggerEnter2D(Collider2D objeto)
	{
		if (objeto.gameObject.tag == "Chao") {
			Destroy (gameObject);
		}
	}
}



