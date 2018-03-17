using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {
	public  Vector2 speed = new Vector2 (25,0);
	private Rigidbody2D rigidbodytiro;
	private Animator anim;

	void Start () {
		rigidbodytiro = GetComponent<Rigidbody2D>();
		rigidbodytiro.velocity = speed * this.transform.localScale.x;
		anim.SetTrigger("tiro");
	}
	void OnTriggerEnter2D(Collider2D objeto)
	{
		if (objeto.gameObject.tag == "Chao") {
			Destroy (gameObject);
		}
	}
}



