using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class Box1 : MonoBehaviour {
	
		Rigidbody rigi;
		public float breakingPoint;
		public float forceVariance;
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
				rigi.AddForce((hitData.hitPos - hitData.shooterPos) * hitData.power, ForceMode.Impulse);
				break;
			case Weapon.axe:
				rigi.AddForce((hitData.hitPos - hitData.shooterPos) * hitData.power, ForceMode.Impulse);
				break;
			default:
				break;
			}
		}
	}
}