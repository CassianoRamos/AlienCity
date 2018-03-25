using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Variaveis de animação e objetos
	private Animator anim;
	private Rigidbody2D rb2d;
	//Variaveis de verificação se player está tocando o chão
	public Transform posPe;
	[HideInInspector] public bool tocaChao = false;

	//Declaração da variaveis do pulo
	public float Velocidade;
	public float ForcaPulo = 1000f;
	[HideInInspector] public bool viradoDireita = true;
	public bool jump;
	//Variaveis de vida do player
	public Image vida;
	private MensagemControle MC;
	//Declaração da variaveis de tiro
	private float tempodetiro = 0.1f;
	private float controledetiro = 0f;
	public Transform posicaotiro;
	public GameObject tiro;
	//Variaveis da troca de armas
	public GameObject arma2;
	public GameObject arma21;
	public bool armas;
	public bool armas1;
	public GameObject Arma1;
	public GameObject Arma2;

	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		arma21.gameObject.SetActive (false);
		arma2.gameObject.SetActive (false);

		GameObject mensagemControleObject = GameObject.FindWithTag ("MensagemControle");
		if (mensagemControleObject != null) {
			MC = mensagemControleObject.GetComponent<MensagemControle> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Verifica se o player está tocando o chão
		tocaChao = Physics2D.Linecast (transform.position, posPe.position, 1 << LayerMask.NameToLayer ("Ground"));
		if ((Input.GetKeyDown("space"))&& tocaChao) {
			jump = true;
				}
        //Verifica se o tiro ja foi efetuado e controla o tempo até outro ser disparado
		if (controledetiro > 0) {
			controledetiro -= Time.deltaTime;
		}
		//Determina a tecla que dispara o tiro 
		if (Input.GetKeyDown ("j")) {
			Tiro ();
			//Determina intervalo entre os tiros
			controledetiro = tempodetiro;
		}
		//faz troca de variaveis conforme o botao que foi pressionado
		if (Input.GetKeyDown ("1")) {
			armas = true;
			armas1 = false;
		} 
		if (Input.GetKeyDown ("2")) {
			armas1 = true;
			armas = false;
		} 

	}
	void FixedUpdate()
	{
		//Movimentação do personagem
		float translationY = 0;
		float translationX = Input.GetAxis ("Horizontal") * Velocidade;
		transform.Translate (translationX, translationY, 0);
		transform.Rotate (0, 0, 0);
		//Define as animações que serão feitas
		if (translationX != 0 && tocaChao) {
			anim.SetTrigger ("run armado");

		} else {
			anim.SetTrigger ("stand armado");
		}

		//Chama a animação do pulo e define sua força
		if (jump == true) {
			anim.SetTrigger ("pula");
			rb2d.AddForce (new Vector2 (0f, ForcaPulo));
			jump = false;
		}
		//Chama as animações pós-pulo
		if (jump == false && translationX != 0 && tocaChao) {
			anim.SetTrigger ("run armado");

		} else {
			anim.SetTrigger ("stand armado");

		}			
		//Define a direção ao qual o player está posicionado
		if (translationX > 0 && !viradoDireita) {
			Flip (); 
		} else if (translationX < 0 && viradoDireita)
			Flip (); 

		if (translationX > 0 && !viradoDireita) {
			Flip ();
		} else if (translationX < 0 && viradoDireita) {
			Flip ();
		  }
		//Troca a visibilidade das armas comforme as condições de parado ou correndo 
		if (armas == true && translationX != 0 && tocaChao) {
				arma21.gameObject.SetActive (false);
				arma2.gameObject.SetActive (true);
			armas1 = false;
			} 
		else if (armas == true && translationX == 0 && tocaChao){
				arma21.gameObject.SetActive (true);
				arma2.gameObject.SetActive (false);
			}
		//Faz troca de visibilidade entre arma 1 e arma 2
		if (armas1 == true) {
			arma21.gameObject.SetActive (false);
			arma2.gameObject.SetActive (false);
			armas = false;
		}
	}


	//Faz o personagem andar para as duas direções
	void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}
	//Método de dano do player
	public void SubtraiVida()
	{
		vida.fillAmount-=0.1f;
		if (vida.fillAmount <= 0) {
			MC.GameOver();
			Destroy(gameObject);
		}
	}
	//Método de instanciação do prefab tiro
	void Tiro(){
		if (controledetiro <= 0f) {
			if (tiro != null) {
				var clonetiro = Instantiate (tiro, posicaotiro.position, Quaternion.identity) as GameObject;
				clonetiro.transform.localScale = this.transform.localScale;
				Destroy (clonetiro,10f);
			}
		}
	}
		
}

