using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private Rigidbody2D rb2d;
	public float Forcatiro = 1000f;
	public bool tiro;

	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("j")) {
			tiro = true;
		}
	}
	void FixedUpdate(){
	
		if (tiro == true) {
			anim.SetTrigger ("tiro");
			tiro = false;
		}

		else { anim.SetTrigger("sem tiro");
			
		}

	}
  }

