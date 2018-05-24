using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class TraumaHolder : MonoBehaviour {
	
		// Awake is called when the script instance is being loaded.
		protected void Awake()
		{
			StaticManager.traumaHolder = this;
		}
	}
}
