using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaHUD : MonoBehaviour {

	public GameObject Arma1;
	public GameObject Arma2;
	//Começa com segunda arma invisivel no HUD
	void Start(){
		Arma2.gameObject.SetActive(false);
		Arma1.gameObject.SetActive(true);
	}
	void Update () {
		// Troca a visibilidade da arma conforme o botão pressionado
		if (Input.GetKeyDown ("1")) {
			Arma1.gameObject.SetActive(false);
			Arma2.gameObject.SetActive(true);
		} 
		if (Input.GetKeyDown ("2")) {
			Arma2.gameObject.SetActive(false);
			Arma1.gameObject.SetActive(true);
		} 
		
	}
}
