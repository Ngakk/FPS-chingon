using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class Capsule : MonoBehaviour {
	
		Rigidbody rigi;
		
		void Start(){
			rigi = GetComponent<Rigidbody>();
		}
	
		public void GetHit(HitData hitData)
		{
			switch(hitData.weapon)
			{
			case Weapon.sniper:
				rigi.AddForceAtPosition((hitData.hitPos - hitData.shooterPos).normalized * hitData.power, hitData.hitPos);
				break;
			}
		}
	}
}