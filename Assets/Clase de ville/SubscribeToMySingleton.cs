using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscribeToMySingleton : MonoBehaviour {

	//Suponiendo que esta clase es algo asi como un UI Manager
	public UnityEngine.UI.Text scoreText;

	
	protected void Start(){
		MySingleton.Instance.Initialize();
	}

	//Suscribirme al evento del singleton
	void OnEnable()
	{
		MySingleton.AddScoreHandler += UpdateScoreText;
	}
	void OnDisable(){
		MySingleton.AddScoreHandler -= UpdateScoreText;
	}
	void OnDestroy(){
		MySingleton.AddScoreHandler -= UpdateScoreText;
	}
	
	//Este metodo debe coincidir con la template del Delegado (y el evento)
	public void UpdateScoreText(int newScore)
	{
		scoreText.text = newScore.ToString();
	}
}
