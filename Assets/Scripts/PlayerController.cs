using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private Rigidbody2D rb2d;

	public Transform posPe;
	[HideInInspector] public bool tocaChao = false;

	//Declaração da variaveis do pulo
	public float Velocidade;
	public float ForcaPulo = 1000f;
	[HideInInspector] public bool viradoDireita = true;
	public bool jump;

	public Image vida;
	private MensagemControle MC;

	private float tempodetiro = 0.2f;
	private float controledetiro = 0f;
	public Transform posicaotiro;
	public GameObject tiro;



	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

		GameObject mensagemControleObject = GameObject.FindWithTag ("MensagemControle");
		if (mensagemControleObject != null) {
			MC = mensagemControleObject.GetComponent<MensagemControle> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Verifica se p player está tocando o chão
		tocaChao = Physics2D.Linecast (transform.position, posPe.position, 1 << LayerMask.NameToLayer ("Ground"));
		if ((Input.GetKeyDown("space"))&& tocaChao) {
			jump = true;
				}
		if (controledetiro > 0) {
			controledetiro -= Time.deltaTime;
		}
		if (Input.GetKeyDown ("j")) {
			Tiro ();
			controledetiro = tempodetiro;
		}
	}
	void FixedUpdate()
	{
		float translationY = 0;
		float translationX = Input.GetAxis ("Horizontal") * Velocidade;
		transform.Translate (translationX, translationY, 0);
		transform.Rotate (0, 0, 0);
		if (translationX != 0 && tocaChao) {
			anim.SetTrigger ("run armado");
		} else {
			anim.SetTrigger("stand armado");
		}

			if (jump == true)
			{
				anim.SetTrigger("pula");
			rb2d.AddForce(new Vector2(0f, ForcaPulo));
				jump = false;
			}

		if (jump == false && translationX != 0 && tocaChao){
			anim.SetTrigger ("run armado");
		} else {
			anim.SetTrigger("stand armado");
		}			
			if(translationX>0 && !viradoDireita) 
			{
				Flip(); 
			}
			else if (translationX < 0 && viradoDireita)
				Flip (); 

		if (translationX > 0 && !viradoDireita) {
			Flip ();
		} else if (translationX < 0 && viradoDireita) {
			Flip();
		}

	}
	void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}

	public void SubtraiVida()
	{
		vida.fillAmount-=0.1f;
		if (vida.fillAmount <= 0) {
			MC.GameOver();
			Destroy(gameObject);
		}
	}
	void Tiro(){
		if (controledetiro <= 0f) {
			if (tiro != null) {
				var clonetiro = Instantiate (tiro, posicaotiro.position, Quaternion.identity) as GameObject;
				clonetiro.transform.localScale = this.transform.localScale;
				Destroy (clonetiro, 1f);

			}
		}
	}
	
} 