using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {


	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText parabensText;

	public bool gameOver;
	public bool restart;
	public bool parabens;

	void Start () {
		gameOver = false;
		restart = false;
		parabens = false;
		restartText.text = "";
		gameOverText.text = "";
		parabensText.text = "";

	}
	
	void Update ()
	{
		if (gameOver)
		{
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}


		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene ("cena1", LoadSceneMode.Single);

			}
		}
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void Venceu ()
	{
		parabensText.text = "Voce venceu!!!";
		restartText.text = "Press 'R' for Restart";
		restart = true;
	}

}
