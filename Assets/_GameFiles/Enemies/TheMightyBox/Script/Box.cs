using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class Box : MonoBehaviour {
	
		Rigidbody rigi;
		// Use this for initialization
		void Start () {
			rigi = GetComponent<Rigidbody>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		public void GetHit(HitData hitData){
			switch(hitData.weapon){
			case Weapon.sniper:
				rigi.AddForce((hitData.hitPos - hitData.shooterPos).normalized * hitData.power);
				break;
			case Weapon.granade:
				Debug.Log("granadaaa");
				rigi.AddExplosionForce(hitData.power, hitData.shooterPos, 1.5f);
				break;
			}
			
		}
	}
}