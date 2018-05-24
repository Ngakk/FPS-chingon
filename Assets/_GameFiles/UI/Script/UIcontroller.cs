using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos{
	public class UIcontroller : MonoBehaviour {
		
		public Text currentAmmo;
		public Text maxAmmo;
	
		void Awake()
		{
			StaticManager.uiController = this;
		}
		
		public void SetCurrentAmmo(string _a)
		{
			currentAmmo.text = _a;
		}
		
		public void SetMaxAmmo(string _a)
		{
			maxAmmo.text = _a;
		}
	}
}
