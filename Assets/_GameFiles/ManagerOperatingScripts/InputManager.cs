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
				if(Input.GetKeyDown(KeyCode.Y))
					weaponController.ChangeWeapon();
			
				switch (weaponController.weaponState){
				case Weapon.sniper:
					if(Input.GetMouseButtonDown(0))
						weaponController.StartShootAnim();
					break;
				case Weapon.granade:
					if(Input.GetMouseButton(0))
						weaponController.StartGranadeAnim();
					break;
				case Weapon.axe:
					break;
				}
				break;
			default:
				break;
			}
		}
	}
}