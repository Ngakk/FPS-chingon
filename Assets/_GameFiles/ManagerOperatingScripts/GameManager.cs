using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class GameManager : MonoBehaviour {
		public Mangos.GameState gameState;
		void Awake(){
			StaticManager.gameManager = this;
		}
	}
}
