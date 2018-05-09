using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton : MonoBehaviour {

	//=======================Logica de singleton===========
	//Instancia Unica estatica
	private static MySingleton m_instance;
	
	//Propiedad para obtener la referencia al singleton
	public static MySingleton Instance
	{
		get
		{
			//Si no hay instancia de la clase
			if(m_instance == null)
			{
				//Crear objeto que contendra la instancia
				GameObject go = new GameObject("My Singleton");
				go.AddComponent<MySingleton>();
				
				DontDestroyOnLoad(go);
			}
			return m_instance;
		}
	}
	
	void Awake()
	{
		if(m_instance)
		{
			Destroy(gameObject);
		}
		else{
			m_instance = this;
		}
	}
	
	//===================Logica de delegado ================
	
	//Metodo para forzar a que exista el singleton para poderse suscribir
	public void Initialize()
	{
		//Do Nothing
	}
	
	//Delegado funciona como una especie de template
	//Es como un metodo que no hace nada, pero tiene entradas y salidas
	public delegate void IntTemplate (int newInt);
	
	//Para utilizarlo voy a crear eventos con ese template
	//Lo Utilizamos como un Metodo, pero no tiene definicion
	public static IntTemplate AddScoreHandler;
	
	public void AddScore(int newScore){
		AddScoreHandler(newScore);
	}
	
}
