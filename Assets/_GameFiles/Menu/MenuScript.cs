﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mangos{
	public class MenuScript : MonoBehaviour {
	
		Animator anim;
		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	
		public void LoadGame() {
			
		}
		
		public void Options()
		{
			anim.SetTrigger("Options");
		}
	
		public void Quit () {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}
	}
}
