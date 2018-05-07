using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class InputManager : MonoBehaviour {
		
		public WeaponController weaponController;
		void Awake(){
			StaticManager.inputManager = this;
		}
			
		void Update(){
			switch (StaticManager.gameManager.gameState) {
			case GameState.mainGame:
				if(Input.GetMouseButtonDown(0))
					weaponController.StartShootAnim();
				break;
			default:
				break;
			}
		}
	}
}